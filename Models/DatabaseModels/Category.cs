using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("categories")]
    public class Category: BaseModel
  {
    [PrimaryKey("categoryid")]
    public int Categoryid { get; set; }

    [Column("categoryname")]
    public string? Categoryname { get; set; }

    [Column("description")]
    public string? Description { get; set; }
  }

