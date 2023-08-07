using Microsoft.AspNetCore.Mvc;
using todoapi.Models;
using todoapi.Services;

namespace todoapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase{

  ICategoryService categoryService;
  protected readonly TodoContext context;

  public CategoryController(ICategoryService service, TodoContext dbcontext){
    categoryService = service;
    context = dbcontext;
  }

  [HttpGet]
  public IActionResult Get(){
    try
    {
      return Ok(categoryService.Get());
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  [HttpPost]
  public async Task<ActionResult> Post([FromBody] Category category){
    try
    {
      var resultMessage = await categoryService.Create(category);
      return Ok(resultMessage);
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(Guid id){
    try
    {
      await categoryService.Delete(id);
      return Ok();
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

}