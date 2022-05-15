# Manipulación de Datos  
## Creación del DB Context  
`BlazingPizza\PizzaStoreContext.cs`

## Creación de un API controller  
`BlazingPizza\SpecialsController.cs`  
Añadir HTTP requests pipelines  
`BlazingPizza\Program.cs` at `line 27`

## Inicialización de data  
-Crear clase estática que ingrese datos a la database através de un db context  
`BlazingPizza\SeedData.cs`  
  
-Crear un service scope para el dbContext  
`BlazingPizza\Program.cs` at line `31`    

  
-Llamar la clase estática con el dbcontext

## Uso del API Controller  
-Dentro de un metodo async de un componente razor llamar al HTTP Client con la el route configurado  
`BlazingPizza\Pages\Index.razor` at line `28`  





