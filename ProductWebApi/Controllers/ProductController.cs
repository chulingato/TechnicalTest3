using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Models;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext productDbContext)
        {
            _dbContext = productDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return _dbContext.Products;
        }

        [HttpGet("{productId:int}")]
        public async Task<ActionResult<Product>> GetById(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            return product;
        }

        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Product product)
        {
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{productId:int}")]
        public async Task<ActionResult> Delete(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{productId}/stock/{quantity}")]
        public async Task<IActionResult> UpdateStock(string productId, int quantity)
        {
            Product product = await _dbContext.Products.FindAsync(productId); ;
               
            if (product.ProductStock <= 0)
            {
                return BadRequest("Stock insuficiente");
            }
            product.ProductStock = quantity;
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{productId:int}/quantity")]
        public async Task<ActionResult<int>> GetQuantity(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            if (product == null) return NotFound();
            return product.ProductStock;
        }

    }
}