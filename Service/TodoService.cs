using todoapi.Models;

namespace todoapi.Services;

public class TodoService: ITodoService{

  protected readonly TodoContext context;

  public TodoService(TodoContext dbcontext){
    context = dbcontext;
  }


 public IEnumerable<Todo> Get(){
    try
    {
      return context.TodoItems;
    }
    catch (System.Exception)
    {
      throw;
    }
 }

  public Todo GetById(Guid id){
    try
    {
      return context.TodoItems.Find(id);
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  public IEnumerable <Todo> GetByCategory(Guid categoryId){
    return context.TodoItems.Where(t => t.CategoryId == categoryId);
  }

  public async Task<IResult> Create(Todo todo){
    todo.Id = Guid.NewGuid();
    context.TodoItems.Add(todo);
    await context.SaveChangesAsync();
        return Results.Created("Succesfully created", todo);
  }

  public async Task<IResult> Update(Guid todoId, Todo todo){
    var currentTodo = context.TodoItems.Find(todoId);
    if(currentTodo!=null){
      currentTodo.TodoText = todo.TodoText;
      currentTodo.done = todo.done;
      await context.SaveChangesAsync();
      return Results.Ok("Succesfully updated");
    }
        return Results.NotFound();
  }

    public async Task<IResult> Delete(Guid todoId) {
        var currentTodo = context.TodoItems.Find(todoId);
        if (currentTodo != null) {
            context.TodoItems.Remove(currentTodo);
            await context.SaveChangesAsync();
            return Results.Ok("Succesfully deleted");
        }
        return Results.NotFound();
  }

}

public interface ITodoService{
  IEnumerable<Todo> Get();
  Todo GetById(Guid id);
  IEnumerable <Todo> GetByCategory(Guid categoryId);
  Task<IResult> Create(Todo todo);
  Task<IResult> Update(Guid TodoId, Todo todo);
  Task<IResult> Delete(Guid TodoId);
}