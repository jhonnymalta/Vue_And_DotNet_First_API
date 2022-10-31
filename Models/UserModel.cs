
using Dapper.Contrib.Extensions;

namespace api.Models;

[Table("User")]
public class UserModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
};