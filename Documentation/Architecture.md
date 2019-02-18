# Marcos y Patrones

## Objetivo
Ejecutar actividades de diseño detallado de software mediante la implementación de un servidor
http básico de prueba

## Descripción del procesamiento

1. Primeramente se crea un socket en la combinación IP y puerto en la que escucharemos por peticiones
2. Al momento de recibir una conexión, convertimos el stream de unos y ceros en una cadena de text que luego podrá ser parseada
3. Parseammos la cadena para generar un objeto que contenga la información de la petición
4. Logueamos la petición recibida
5. Creamos una respuesta con código 200
5. Enviamos la respuesta al cliente


## Diagramas

### Diagramas estructurales

#### [Diagrama de Componentes](https://drive.google.com/file/d/1f8nMRdii9rgghjJXw1yMWbSsWKuabmQg/view?usp=sharing)
 ![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-componentes-diagram-b.png)

#### [Diagrama de clases](https://drive.google.com/file/d/1vFhEw-44pBMuWKQeXJMHlMY-JCUOKLbf/view?usp=sharing)
 ![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-clases-diagramB.png)

#### [Diagrama de despliegue](https://drive.google.com/file/d/1y0OHZs0uo-muBTQ1z-5_3zR6ZHKDHd_m/view?usp=sharing)
 ![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-diagrama-despliegueB.png)

### Diagramas de Comportamiento

#### [Diagrama de actividades](https://drive.google.com/file/d/1sMBNNXBy4c5ZmWnw5LiROM3euaW3x4Zv/view?usp=sharing)
 ![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-diagrama-actividades.png)

