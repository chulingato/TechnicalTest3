## Endpoints Documentation

### Microservices Product and Order solution

#### GET /api/products

Get all products.

#### GET /api/products/{id}

Get a product by ID.

#### POST /api/products

Create a new product.

##### Request Body

```json
{
    "name": "Product Name",
    "price": 10.5,
    "stock": 100
}
```

### Create Product

Crea un nuevo producto.

**Endpoint:** `/api/product`

**Método HTTP:** POST

#### Parámetros de solicitud

| Parámetro | Tipo   | Descripción |
| --------- | ------ | ----------- |
| name      | string | Nombre del producto |
| description  | string | Descripción del producto |
| price  | number | Precio del producto |
| stock | number | Cantidad en stock del producto |

**Ejemplo de solicitud:**

```json
{
  "name": "[nombre]",
  "description": "[descripcion]",
  "price": [precio],
  "stock": [stock]
}
```

#### Respuesta exitosa

**Código de estado HTTP:** 201

**Ejemplo de respuesta:**

```json
{
  "id": "[id]",
  "name": "[nombre]",
  "description": "[descripcion]",
  "price": [precio],
  "stock": [stock]
}
```

### Update Product

Actualiza un producto existente.

**Endpoint:** `/api/product/:id`

**Método HTTP:** PUT

#### Parámetros de solicitud

| Parámetro | Tipo   | Descripción |
| --------- | ------ | ----------- |
| name      | string | Nombre del producto |
| description  | string | Descripción del producto |
| price  | number | Precio del producto |
| stock | number | Cantidad en stock del producto |

**Ejemplo de solicitud:**

```json
{
  "name": "[nombre]",
  "description": "[descripcion]",
  "price": [precio],
  "stock": [stock]
}
```

#### Respuesta exitosa

**Código de estado HTTP:** 200

**Ejemplo de respuesta:**

```json
{
  "id": "[id]",
  "name": "[nombre]",
  "description": "[descripcion]",
  "price": [precio],
  "stock": [stock]
}
```

### Delete Product

Elimina un producto existente.

**Endpoint:** `/api/product/:id`

**Método HTTP:** DELETE

#### Respuesta exitosa

**Código de estado HTTP:** 204

## Order API

### Get Orders

Obtiene todas las órdenes de compra.

**Endpoint:** `/api/order`

**Método HTTP:** GET

#### Respuesta exitosa

**Código de estado HTTP:** 200

**Ejemplo de respuesta:**

```json
[{
  "id": "[id]",
  "userId": "[userId]",
  "items": [
    {
      "productId": "[productId]",
      "quantity": [quantity]
    }
  ],
  "total": [total]
}]
```

### Create Order

Crea una nueva orden de compra.

**Endpoint:** `/api/order`

**Método HTTP:** POST

#### Parámetros de solicitud

| Parámetro | Tipo   | Descripción |
| --------- | ------ | ----------- |
| userId      | string | ID del usuario que realiza la orden |
| items  | array | Arreglo de objetos que contienen el ID del producto y la cantidad |
| total  |

## Customer API

### Get Customers

Obtiene todos los clientes.

**Endpoint:** `/api/customer`

**Método HTTP:** GET

#### Respuesta exitosa

**Código de estado HTTP:** 200

**Ejemplo de respuesta:**

```json
[{
  "customerId": 1,
  "customerName": "Juan Perez",
  "mobileNumber": "1234567890",
  "email": "juan.perez@example.com"
}]
```
## Get Customer by Id
### Obtiene un cliente por su identificador.

**Endpoint:** `/api/customer/{customerId}`

**Método HTTP:** GET

### Respuesta exitosa
**Código de estado HTTP:** 200

**Ejemplo de respuesta:**
```json
{
  "customerId": 1,
  "customerName": "Juan Perez",
  "mobileNumber": "1234567890",
  "email": "juan.perez@example.com"
}
```

## Create Customer
### Crea un nuevo cliente.

**Endpoint:** `/api/customer`

**Método HTTP:** POST

**Cuerpo de solicitud**
```json
{
  "customerName": "Juan Perez",
  "mobileNumber": "1234567890",
  "email": "juan.perez@example.com"
}
```

## Update Customer
### Actualiza un cliente existente.

**Endpoint:** `/api/customer`

**Método HTTP:** PUT

**Cuerpo de solicitud**
```json
{
  "customerId": 1,
  "customerName": "Juan Perez",
  "mobileNumber": "1234567890",
  "email": "juan.perez@example.com"
}
```

## Delete Customer
### Elimina un cliente existente.

**Endpoint:** `/api/customer/{customerId}`

**Método HTTP:** DELETE

**Respuesta exitosa**
**Código de estado HTTP:** 200

