using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("product")]
public class Product : BaseModel
{
    [PrimaryKey("productid")]
    public int productid { get; set; }
    [Column("productname")]
    public string? Productname { get; set; }
    [Column("description")]
    public string? Description { get; set; }
    [Column("Price")]
    public float? Price { get; set; }
    [Column("stockquantity")]
    public int? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [Column("roles_id")]
    public int? RoleId { get; set; }
    [Column("user_uid")]
    public string? UserUid { get; set; }
}