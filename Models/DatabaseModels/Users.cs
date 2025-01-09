using Newtonsoft.Json;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace CappypopMVC.Models.DatabaseModels;

[Table("user")]
public class Users : BaseModel
{
    [PrimaryKey("id")]
    public int Id { get; set; }
    [Column("email")]
    public string? Email { get; set; }
    [Column("password_hash")]
    public string? PasswordHash { get; set; }
    [Column("full_name")]
    public string? FullName { get; set; }
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }
    [Column("created_at", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? CreatedAt { get; set; }
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }
    [Column("roles_id")]
    public string? RoleId { get; set; }
    [Column("user_uid")]
    public string? UserUid { get; set; }
}