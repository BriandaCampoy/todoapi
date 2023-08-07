using System.Text.Json.Serialization;

namespace todoapi.Models;

public class Category{

  public Guid CategoryId { get; set; }
  public string name { get; set; }

  [JsonIgnore]
  public virtual ICollection<Todo>? todos { get; set; }

}