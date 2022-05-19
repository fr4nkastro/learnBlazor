namespace BlazingPizza.Data;

public class Pizza2
{
    public static readonly int DefaultSize= 12;
    public static readonly int MinimumSize = 6;
    public static readonly int MaximumSize = 18;
    public int PizzaId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public bool Vegetarian { get; set; }
    
    public bool Vegan { get; set; }

    public PizzaSpecial Special { get; set; }
    public int SpecialId { get; set; }  
    public int Size { get; set; }
public string GetFormattedTotalPrice() => (Special.BasePrice += Special.BasePrice * (decimal)0.15).ToString("0.00");
}