using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("blog")]
public class Cappylife : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    [Column("name")]
    public string? Name { get; set; }

    [Column("createat")]
    public DateTime? CreatedAt { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("photoURL")]
    public string? PhotoURL { get; set; }

    [Column("context")]
    public string? Context { get; set; }
    [Column("description")]
    public string? Description { get; set; }
}
