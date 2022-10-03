using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ShoppingList.Models;
using ShoppingList.Services;

namespace ShoppingList.Controllers;

[Route("api/[controller]")]
public class ItemController : ControllerBase
{ 
    IItemService itemServiceParameter;

    public ItemController(IItemService itemparameter)
    {
        itemServiceParameter = itemparameter;
    }
    [EnableCors("Policy1")]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(itemServiceParameter.Get());
    }
    [EnableCors("Policy1")]
    [HttpPost]
    public IActionResult Post([FromBody] Item itemParameter)
    {
        itemServiceParameter.Save(itemParameter);
        return Ok();
    }
    [EnableCors("Policy1")]
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Item itemParameter)
    {
        itemServiceParameter.Update(id, itemParameter);
        return Ok();
    }
    [EnableCors("Policy1")]
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        itemServiceParameter.Delete(id);
        return Ok();
    }
}