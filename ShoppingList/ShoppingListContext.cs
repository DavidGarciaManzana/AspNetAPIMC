using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;

namespace ShoppingList;

public class ShoppingListContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    
    public ShoppingListContext(DbContextOptions<ShoppingListContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilderParameter)
    {
        modelBuilderParameter.Entity<Item>(itemparameter =>
        {
            itemparameter.ToTable("Shopping List");
            itemparameter.HasKey(p => p.ItemId);

            itemparameter.Property(p => p.Name).IsRequired();
            itemparameter.Property(p => p.Quantity).IsRequired();
            itemparameter.Property(p => p.State).IsRequired().HasDefaultValue("Pending");

        });
    }
}