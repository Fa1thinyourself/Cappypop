using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("products")]
public class Products : BaseModel
{
    [PrimaryKey("productid")]
    public int? productid { get; set; }
    [Column("productname")]
    public string? Productname { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("price")]
    public float? Price { get; set; }
    [Column("stockquantity")]
    public int? Stockquantity { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [Column("categoryid")]
    public int? Categoryid { get; set; }
    [Column("createat")]
    public DateTime? CreatedAt { get; set; }
}