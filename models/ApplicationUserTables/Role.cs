// using System.ComponentModel.DataAnnotations;
// using Microsoft.AspNetCore.Identity;
//
// namespace EmployeeManagement.models.ApplicationUserTables;
//
// public class Role : IdentityRole
// {
//     [Required]
//     [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
//     [StringLength(30)]
//     public string RoleName { get; set; } = null!;
//
//
//     public Role()
//     {
//     }
//
//     public Role(string roleName) : base(roleName)
//     {
//     }
// }