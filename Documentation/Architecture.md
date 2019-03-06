# Marcos y Patrones

# Contenido

* [Objetivo](#objetivo)

* [Descripción del procesamiento](#descripción-del-procesamiento)

* [Desiciones de diseño](#desiciones-de-diseño)

* [Diagramas](#diagramas)

  * [Diagramas estructurales](#diagramas-estructurales)
  
    * [Diagrama de Componentes](#diagrama-de-componentes)
    * [Diagrama de clases](#diagrama-de-clases)
    * [Diagrama de despliegue](#diagrama-de-despliegue)
  
  * [Diagramas de Comportamiento](#diagramas-de-comportamiento)
  
    * [Diagrama de actividades](#diagrama-de-actividades)
    
## Objetivo
Ejecutar actividades de diseño detallado de software mediante la implementación de un servidor
http básico de prueba basado en el [RFC 2616](https://tools.ietf.org/html/rfc2616)

## [Podcast - decisiones de arquitectura](https://youtu.be/R6HdAe7WgFg)
 ![image.jpg](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/podcast002.JPG)

## [Podcast - discusión inicial](https://youtu.be/uAXitENOrKI)
 ![image.jpg](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/podcast001.JPG)

## Descripción del procesamiento

1. Primeramente se crea un socket en la combinación IP y puerto en la que escucharemos por peticiones
2. Al momento de recibir una conexión, convertimos el stream de unos y ceros en una cadena de texto que luego podrá ser parseada
3. Parseamos la cadena para generar un objeto que contenga la información de la petición
4. Logueamos la petición recibida
5. Creamos una respuesta con código 200
5. Enviamos la respuesta al cliente

## Desiciones de diseño

Se decidió crear tres componentes principales con responsabilidades específicas, uno que convertirá la información binaria en texto, otra para crear objetos con la información de la peticion 
que luego sera enviada al pipeline para ser procesada por cada uno de los procesadores configurados

El diseño fue enfocado para tener un mecanismo escalable que permitiera añadir capas de procesamiento a la petición, tales como realizar logging de las peticiones, autenticación o algún otro tipo de procesamiento

## Diagramas

### Diagramas estructurales

#### [Diagrama de Componentes](https://drive.google.com/file/d/1f8nMRdii9rgghjJXw1yMWbSsWKuabmQg/view?usp=sharing)
 ![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-componentes-diagram-b.png)

#### Diagrama de clases

[Servidor](https://drive.google.com/file/d/1vFhEw-44pBMuWKQeXJMHlMY-JCUOKLbf/view?usp=sharing)

![Server diagram](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-diagrama-server.png)

[ConnectionManager](https://drive.google.com/file/d/1vFhEw-44pBMuWKQeXJMHlMY-JCUOKLbf/view?usp=sharing)

![Connection manager diagram](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-diagrama-connection-manager.png)

[RequestParser](https://drive.google.com/file/d/1vFhEw-44pBMuWKQeXJMHlMY-JCUOKLbf/view?usp=sharing)

![Request parser](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-clases-diagramB.png)

[Pipeline](https://drive.google.com/file/d/1vFhEw-44pBMuWKQeXJMHlMY-JCUOKLbf/view?usp=sharing)

![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-diagrama-ipeline.png)

#### [Diagrama de despliegue](https://drive.google.com/file/d/1y0OHZs0uo-muBTQ1z-5_3zR6ZHKDHd_m/view?usp=sharing)
 ![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-diagrama-despliegueC.png)

### Diagramas de Comportamiento

#### [Diagrama de actividades](https://drive.google.com/file/d/1sMBNNXBy4c5ZmWnw5LiROM3euaW3x4Zv/view?usp=sharing)
 ![image.png](https://raw.githubusercontent.com/jsoto0025/eafit.httpserver/master//Documentation/images/uml-diagrama-actividadesB.png)

### [Forma de uso](https://github.com/jsoto0025/eafit.httpserver/blob/master/Documentation/FormaDeUso.md) 