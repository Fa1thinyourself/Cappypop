using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("oderitems")]
public class Orderitems : BaseModel
{
    [PrimaryKey("orderitemid")]
    public int? Orderitemid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("productid")]
    public int? Productid { get; set; }
    [Column("quantity")]
    public int? Quantity { get; set; }
    [Column("price")]
    public float? Price { get; set; }
}