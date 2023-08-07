using System.Text.Json.Serialization;

namespace todoapi.Models;

public class Todo{
  public Guid Id { get; set; }

  public string TodoText { get; set; }=string.Empty;

  public bool done{get; set; }

  public Guid CategoryId { get; set; }

  [JsonIgnore]
  public virtual Category? category { get; set; }
}