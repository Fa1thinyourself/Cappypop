using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("reviews")]
public class Review : BaseModel
{
    [PrimaryKey("reviewid")]
    public int Reviewid { get; set; }
    [Column("productid")]
    public string? Productid { get; set; }
    [Column("customerid")]
    public string? Customerid { get; set; }
    [Column("rating")]
    public int?  Rating { get; set; }
    [Column("reviewtext")]
    public string? Reviewtext { get; set; }
    [Column("createat")]
    public DateTime? CreatedAt { get; set; }
}