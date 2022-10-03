namespace ShoppingList.Models;

public class Item
{
    public int ItemId { get; set; }
    public string Name { get; set; }
    public int Quantity  { get; set; }
    
    public string State { get; set; }
}