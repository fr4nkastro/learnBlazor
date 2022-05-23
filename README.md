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


##Compartir Data  
### Parameters  
Definir en el componente hijo (child component), (.\Shared\ConfigurePizzaDialog.razor) los tipos de parámetros. 
Mandar a llamar el componente hijo  definido desde otro componente (parent component),(.\BlazingPizza\Pages\Index.razor) con atributos del tipo de parámetro.  

### AppState
Crear una clase que guarde la lógica del servicio  (.\BlazingPizza\Model\OrderState.cs)
Inyectar el servicio en Program.cs (AddScope<service>)  
Usar el service desde cualquier componente

## Vinculando Controles HTML Con Datos C#
Dentro de un elemento HTML usar la directiva `@bind="variable"` permite vincular el valor del elemento con una variable

Para cambiar el evento onchange por defecto usar: `@bind-event="<variable>"` && `@bind-event:event="<evento>"`
Ejemplo: [ConfigurePizzaDialog.razor](Shared/ConfigurePizzaDialog.razor)

```<input type="range" min="@Pizza.MinimumSize" max="@Pizza.MaximumSize" step="1" @bind="Pizza.Size" @bind:event="oninput" />```


Un el valor de un componente vinculado se puede formatear con `@bind-format="<date format>"` por los momentos solo disponible para formatear fechas.

# Routing 
Usando el NavigationManager podemos extraer atributos para pasar como parámetros a los componentes

`HomePageURI = NavManager.BaseUri` 

Usando los QueryHelpers se puede extraer el valor del atributo preferido
```
@page "/pizzas"
@using Microsoft.AspNetCore.WebUtilities
@inject NavigationManager NavManager

<h1>Buy a Pizza</h1>

<p>I want to order a: @PizzaName</p>

<p>I want to add this topping: @ToppingName</p>

@code {
	[Parameter]
	public string PizzaName { get; set; }
	
	private string ToppingName { get; set; }
	
	protected override void OnInitialized()
	{
		StringValues extraTopping;
		var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
		if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("extratopping", out extraTopping))
		{
			ToppingName = System.Convert.ToString(extraTopping);
		}
	}
}
```

Para redireccionar en código : `NavigationManager.NavigateTo("MyOrders");`
Example:
[Checkout.razor](Pages\Checkout.razor)

Se puede ayudar a visualizar los links usando los navlinks con su propiedad `Match`:
```
<NavLink href=@HomePageUri Match="NavLinkMatch.All">Home Page</NavLink>

@code {

	
	public string HomePageURI { get; set; }
	
	protected override void OnInitialized()
	{
		HomePageURI = NavManager.BaseUri
	}
}
```
Example
[TopBar.razor](Shared/TopBar.razor)
```
   <NavLink href="" class="nav-tab" Match="NavLinkMatch.All">
        <img src="img/pizza-slice.svg" />
        <div>Get Pizza</div>
    </NavLink>
```