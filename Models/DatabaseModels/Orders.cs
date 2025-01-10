using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("orders")]
    public class Orders: BaseModel
  {
    [PrimaryKey("orderid")]
    public int? orderid { get; set; }

    [Column("customerid")]
    public string? Customerid { get; set; }

    [Column("orderdate")]
    public DateTime? Orderdate { get; set; }

    [Column("totalamount")]
    public int? Totalamount { get; set; }
    [Column("status")]
    public string? Status { get; set; }

    [Column("paymentmethodid")]
    public string? Paymentmethodid { get; set; }
    [Column ("shippingaddress")]
    public string? Shippingaddress { get; set; }
  }

