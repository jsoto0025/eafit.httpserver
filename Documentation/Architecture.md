
## Descripción del procesamiento

1. Primeramente se crea un socket en la combinación IP y puerto en la que escucharemos por peticiones
2. Al momento de recibir una conexión, convertimos el stream de unos y ceros en una cadena de text que luego podrá ser parseada
3. Parseammos la cadena para generar un objeto que contenga la información de la petición
4. Logueamos la petición recibida
5. Creamos una respuesta con código 200
5. Enviamos la respuesta al cliente


### Diagramas

 - Diagrama de clases
 - Diagrama de componentes
 - Diagrama de actividades
