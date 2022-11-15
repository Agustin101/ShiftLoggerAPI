# ShiftLoggerAPI
Una api construida para poder hacer un seguimiento sobre turnos de trabajo.

## Uso de la API
La base de datos fue creada mediante entity framework con un code first aproach y utilizando sql server.

GET: /api/Shifts/getall
GET: /api/Shifts/{id}
POST: /api/Shifts/post
PUT: /api/Shifts/update/{id}
DELETE: /api/Shifts/delete/{id}

## Aplicacion de consola

E - Para salir del programa.
S - Muestra todos los turnos cargados al momento.
A - Agrega un nuevo turno.
U - Edita un turno existente mediante ID.
D - Elimina un turno por id

# Pensamientos finales
Gracias a este proyecto pude terminar de comprender el concepto de un API REST, construyendo diferentes end points y luego consumiendolos desde otra aplicacion.
