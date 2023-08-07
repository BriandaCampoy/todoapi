using todoapi.Models;

namespace todoapi.Services;

public class CategoryService:ICategoryService{

  protected readonly TodoContext context;

  public CategoryService(TodoContext dbcontext){
    context = dbcontext;
  }

  public IEnumerable<Category> Get(){
    try
    {
      return context.CategoryItems;
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  public async Task<IResult> Create(Category category){
    try
    {
      category.CategoryId = Guid.NewGuid();
      Console.WriteLine("Creating  "+"" +category.name + " "+category.CategoryId);
      context.CategoryItems.Add(category);
      await context.SaveChangesAsync();
            return Results.Created("CratedSuccesfull", category);
    }
    catch (System.Exception)
    {
      
      throw;
    }
  }

  public async Task Delete(Guid id){
    var currentCategory = context.CategoryItems.Find(id);
    if(currentCategory != null){
      context.CategoryItems.Remove(currentCategory);
      await context.SaveChangesAsync();
    }
  }

}

public interface ICategoryService{
    IEnumerable<Category> Get();
    Task<IResult> Create(Category category);
    Task Delete(Guid id);
}