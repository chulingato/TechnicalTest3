[{
  "id": "[id]",
  "name": "[nombre]",
  "description": "[descripcion]",
  "price": [precio],
  "stock": [stock]
}]```

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
}```

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
}```

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
}```

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
}```

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
}]```

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
