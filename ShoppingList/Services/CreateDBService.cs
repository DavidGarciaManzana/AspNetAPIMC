namespace ShoppingList.Services;

public class CreateDBService : ICreateDBService
{
    public string GetCreateDB()
    {
        return "DB Created";
    }
}

public interface ICreateDBService
{
    string GetCreateDB();
}