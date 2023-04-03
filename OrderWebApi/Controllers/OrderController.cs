using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using OrderWebApi.Models;
using ProductWebApi.Models;
using System.Net.Http;
using Newtonsoft.Json;
using MySqlX.XDevAPI;


namespace OrderWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderController()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            var dbName = Environment.GetEnvironmentVariable("DB_NAME");
            var connectionString = $"mongodb://{dbHost}:27017/{dbName}";

            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            _orderCollection = database.GetCollection<Order>("order");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _orderCollection.Find(Builders<Order>.Filter.Empty).ToListAsync();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetById(string orderId)
        {
            var filterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            return await _orderCollection.Find(filterDefinition).SingleOrDefaultAsync();
        }

        /*[HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
            return Ok();
        }*/

        [HttpPost]
        public async Task<ActionResult> Create(Order order)
        {
            var productUrl = $"http://localhost:18004";
            foreach (OrderDetail item in order.OrderDetails)
            {
                // Verificar si hay stock disponible del producto solicitado
                var productQuantityUrl = $"{productUrl}/api/product/{item.ProductId}/quantity";
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(productQuantityUrl);
                    if (!response.IsSuccessStatusCode)
                    {
                        return BadRequest("No se pudo verificar la cantidad disponible del producto.");
                    }
                    var quantity = await response.Content.ReadAsStringAsync();
                    if (item.Quantity > Int32.Parse(quantity))
                    {
                        return BadRequest("No hay suficiente stock disponible para el producto solicitado.");
                    }
                }
                order.status = "PENDIENTE";
                await _orderCollection.InsertOneAsync(order);
                using (var client = new HttpClient())
                {
                    // Actualizar la cantidad de productos
                    var response = await client.PutAsync($"{productUrl}/api/product/{item.ProductId}/stock/{item.Quantity}", null);
                }
                    
            }

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Order order)
        {
            var filterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, order.OrderId);
            await _orderCollection.ReplaceOneAsync(filterDefinition, order);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<ActionResult> Delete(string orderId)
        {
            var filterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            await _orderCollection.DeleteOneAsync(filterDefinition);
            return Ok();
        }

        private async Task<Product> GetProductById(int productId)
        {
            var httpClient = new HttpClient();
            var productUrl = $"http://productwebapi/api/product/{productId}";
            var response = await httpClient.GetAsync(productUrl);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(responseContent);
            return product;
        }

        [HttpPut("{orderId}/status")]
        public async Task<ActionResult> UpdateStatus(string orderId)
        {
            var filterDefinition = Builders<Order>.Filter.Eq(x => x.OrderId, orderId);
            Order order = await _orderCollection.Find(filterDefinition).SingleOrDefaultAsync();
            order.status = "ENTREGADO";
            await _orderCollection.ReplaceOneAsync(filterDefinition, order);
            return Ok();

        }
    }
    }