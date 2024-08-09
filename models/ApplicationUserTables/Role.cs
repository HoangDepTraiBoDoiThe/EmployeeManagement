using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.models.ApplicationUserTables;

public class Role
{
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(30)]
    public string RoleName { get; set; } = null!;

    // Many-to-many Users
    public List<User> Users { get; } = [];

    public Role()
    {
    }

    public Role(int id, string roleName)
    {
        Id = id;
        RoleName = roleName;
    }
}