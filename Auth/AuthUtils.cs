// JWT

// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using EmployeeManagement.StaticHelper;
// using EmployeeManagement.models.ApplicationUserTables;
// using Microsoft.Extensions.Options;
// using Microsoft.IdentityModel.Tokens;
//
// namespace EmployeeManagement.Auth;
//
// public class AuthUtils()
// {
//     public static string GenerateToken(User user, IOptions<JwtSection> jwtSection)
//     {
//         var handler = new JwtSecurityTokenHandler();
//         var key = Encoding.ASCII.GetBytes(jwtSection.Value.Key);
//         var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
//
//         var tokenDescriptor = new SecurityTokenDescriptor
//         {
//             Subject = GenerateClaims(user),
//             IssuedAt = DateTime.Now,
//             Expires = DateTime.UtcNow.AddHours(1),
//             Audience = jwtSection.Value.Audience,
//             SigningCredentials = credentials,
//         };
//
//         var token = handler.CreateToken(tokenDescriptor);
//         return handler.WriteToken(token);
//     }
//
//     private static ClaimsIdentity GenerateClaims(User user)
//     {
//         var claims = new List<Claim>
//         {
//             new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
//             new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
//             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//         };
//
//         claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.RoleName)));
//
//         return new ClaimsIdentity(claims);
//     }
// }