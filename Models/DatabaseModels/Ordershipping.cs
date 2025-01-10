using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("ordershipping")]
public class Ordershipping : BaseModel
{
    [PrimaryKey("ordershippingid")]
    public int? Ordershippingid { get; set; }

    [Column("orderid")]
    public int? Orderid { get; set; }

    [Column("shippingmethodid")]
    public int? Shippingmethodid { get; set; }
}
