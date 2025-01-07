using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace MvcSupabaseDb.Models.DatabaseModels;

[Table("user")]
public class Users : BaseModel
{
	[PrimaryKey("id")]
	public int Id { get; set; }
	[Column("username")]
	public string? Username { get; set; }
	[Column("email")]
	public string? Email { get; set; }
	[Column("password_hash")]
	public string? PasswordHash { get; set; }
	[Column("full_name")]
	public string? FullName { get; set; }
	[Column("phone_number")]
	public string? PhoneNumber { get; set; }
	[Column("created_at")]
	public DateTime? CreatedAt { get; set; }
	[Column("updated_at")]
	public DateTime? UpdatedAt { get; set; }
}