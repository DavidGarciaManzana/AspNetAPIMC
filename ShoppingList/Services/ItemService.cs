using ShoppingList.Models;

namespace ShoppingList.Services;

public class ItemService : IItemService
{
    private ShoppingListContext context;

    public ItemService(ShoppingListContext dbContextParameter)
    {
        context = dbContextParameter;
    }

    public IEnumerable<Item> Get()
    {
        return context.Items;
    }

    public async Task Save(Item itemParameter)
    {
        context.Add(itemParameter);
        await context.SaveChangesAsync();
    }

    public async Task Update(int id,Item itemParameter)
    {
        var actualItem = context.Items.Find(id);
        if (actualItem != null)
        {
            // actualItem.Name = itemParameter.Name;
            // actualItem.Quantity = itemParameter.Quantity;
            actualItem.State = itemParameter.State;

            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(int id)
    {
        var actualItem = context.Items.Find(id);
        if (actualItem != null)
        {
            context.Remove(actualItem);

            await context.SaveChangesAsync();
        }
    }
}

public interface IItemService
{
    IEnumerable<Item> Get();
    Task Save(Item itemParameter);
    Task Update(int id,Item itemParameter);
    Task Delete(int id);
    
}