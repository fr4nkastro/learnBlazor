/*
    Usando el package Microsoft.EntityFrameworkCore
    Crear una clase DbContext con sus respectivas Entities (DbSet)
*/

using Microsoft.EntityFrameworkCore;

namespace BlazingPizza;

public class PizzaStoreContext : DbContext
{
    public PizzaStoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PizzaSpecial> Specials { get; set; }
}