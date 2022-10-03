using Microsoft.AspNetCore.Mvc;
using ShoppingList.Services;

namespace ShoppingList.Controllers;

[ApiController]
[Route("api/create")]
public class CreateDBController : ControllerBase
{
    private ICreateDBService CreateDBService;
    private ShoppingListContext dbContext;

    public CreateDBController(ICreateDBService createDBParameter, ShoppingListContext db)
    {
        CreateDBService = createDBParameter;
        dbContext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(CreateDBService.GetCreateDB());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbContext.Database.EnsureCreated();
        return Ok();
    }
}