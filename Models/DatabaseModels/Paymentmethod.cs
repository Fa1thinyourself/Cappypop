using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("paymentmethods")]
public class Paymentmethodid : BaseModel
{
    [PrimaryKey("id")]
    public int? Id { get; set; }

    [Column("methodname")]
    public string? Methodname  { get; set; }

    [Column("customerid")]
    public int? Customerid { get; set; }

}
