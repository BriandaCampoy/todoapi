using Microsoft.AspNetCore.Mvc;
using todoapi.Services;
using todoapi.Models;

namespace todoapi.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class TodoController : ControllerBase{

  ITodoService todoService;
  protected readonly TodoContext context;

  public TodoController(ITodoService service, TodoContext dbcontext){
    todoService = service;
    context = dbcontext;
  }

  [HttpGet]
  [Route("createdb")]
  public IActionResult CreateDatabase(){
    context.Database.EnsureCreated();
    return Ok();
  }

  [HttpGet]
  public IActionResult Get(){
    try
    {
      return Ok(todoService.Get());
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  [HttpGet("{id}")]
  public IActionResult GetById(Guid id){
    try
    {
      return Ok(todoService.GetById(id));
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  [HttpGet("category/{id}")]
  public IActionResult GetByCategory(Guid id){
    return Ok(todoService.GetByCategory(id));
  }

  [HttpPost]
  public async Task<IActionResult> Post([FromBody]Todo todo){
    try
    {
      var result = await todoService.Create(todo);
            return Ok(result);
     }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(Guid id, [FromBody]Todo todo){
    try
    {
      var result = await todoService.Update(id, todo);
      return Ok(result);
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
      var result = await todoService.Delete(id);
      return Ok(result);
    }
    catch (System.Exception)
    {
      
      throw;
    }
  } 

}