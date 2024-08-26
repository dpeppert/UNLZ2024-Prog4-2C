# UNLZ2024-Prog4-2C
Repositorio para Programación 4 de UNLZ


# Clase 1

Definición de Lógica de Negocio: 
Logística de Containers: 
    Contexto: El país necesita saber información de sus containers. El país cuenta con un stock de containers que diariamente viajan por todo el país. De dichos containers necesita tener información sobre el container, Viajes realizados, si tiene viajes en cursos, si están llenos o vacíos. Ubicacion actual del container. 

    Los containers viajan por todo el país y los mismos se hospedan en hangares, los containers viajan de hangar en hangar. Se desea que nuestro sistema trackee desde donde vienen, hacia donde van, en que momento salen, en que momento llegan  


    A dichos hangares están vinculados los usuarios, que podrán cargar los containers y contribuir al stock de containers del país. Todos los containers cargados por el usuario, se cargarán con el hangar al que está vinculado el usuario. 
    
    Los usuarios pueden enviar containers de un hangar a otro. 
    Un container debe ser aceptado por un usuario para confirmar la finalización del viaje. 


    
##Lo visto en clase 1: 

Definiciones de clases en c#

Creación de Proyecto .NET del tipo librería de clases

Definicion de Contructor { get; set; }
Nueva Instancia de la clase Container 

Definición de clases Container, Hangar, Usuario, Viaje 

Definición de clases Managers (Orquestadores de nuestra lógica de negocio)

Definición de Clase Padre Audit para poder trackear todos los movimientos de nuestra base de datos. Se aplicó herencia 

Creación de Proyecto ASP.NET MVC con .NET 8

Objetos ViewBag y ViewData


