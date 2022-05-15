# RetoBackend

Se ha resuelto el nivel 1 del reto. Las rutas para poder realizar las operaciones de este nivel son:

GET /vehiculos                       --> Se listan todos los vehículos <br />
GET /pedidos                         --> Se listan todos los pedidos <br />
GET /vehiculo{id}/ubicacion          --> Se obtiene la ubicación del vehículo <br />
PUT /vehiculos/{id}/ubicacion        --> Se actualiza la ubicación del vehículo y se le añade esa ubicación al historial <br />
POST /vehiculos/{id}                 --> Se crea un nuevo pedido y se le asocia a ese vehículo <br />
DELETE /vehiculos/{id}/borrarPedido  --> Se elimina el pedido asociado al vehículo <br />

*Para insertar una ubicación de un vehículo, se ha optado por hacer el PUT espeficicado anteriormente*

Además se incluyen los métodos de GET, PUT, POST y DELETE de las entidades Vehiculo y Pedido.
