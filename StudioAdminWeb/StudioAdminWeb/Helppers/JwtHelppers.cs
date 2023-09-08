using Microsoft.IdentityModel.Tokens;
using StudioAdminData.Models.Business;
using StudioAdminData.Models.JWT;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace StudioAdminWeb.Helppers
{
    public static class JwtHelppers
    {
        private static Roles CurrentRol { get; set; }

        public static IEnumerable<Claim> GetClaims(this UserToken UserAcounts, Guid Id)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", UserAcounts.Id.ToString()),
                new Claim(ClaimTypes.Name, UserAcounts.UserName),
                new Claim(ClaimTypes.Email, UserAcounts.EmailId),
                new Claim(ClaimTypes.NameIdentifier, Id.ToString()),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddDays(1).ToString("MMM ddd dd yyyy HH:mm:ss tt"))
            };
            switch (CurrentRol)
            {
                case Roles.Admin:
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                    break;
                case Roles.Medium:
                    claims.Add(new Claim(ClaimTypes.Role, "Medium"));
                    break;
                default:
                    claims.Add(new Claim(ClaimTypes.Role, "User")); // usuario básico
                    break;
            }
            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserToken UserAcounts, out Guid Id)
        {
            Id = Guid.NewGuid();
            return UserAcounts.GetClaims(Id);
        }

        public static UserToken GenerateTokenKey(UserToken model, JwtSettings jwtSettings, Roles currentRol)
        {
            try
            {
                CurrentRol = currentRol;
                var UserToken = new UserToken();
                if (model == null)
                {
                    throw new ArgumentNullException(nameof(model));
                }
                // Obtener Clave Secreta
                var Key = System.Text.Encoding.ASCII.GetBytes(jwtSettings.IsUserSigninKey);
                // Expira en un día
                DateTime expiredTime = DateTime.Now.AddDays(1);
                // Validez
                UserToken.Validity = expiredTime.TimeOfDay;
                // Genero JWT de
                var jwtToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIsUser,
                    audience: jwtSettings.ValidAudience,
                    claims: model.GetClaims(out Guid Id),
                    notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                    expires: new DateTimeOffset(expiredTime).DateTime,
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(Key),
                        SecurityAlgorithms.HmacSha256));

                UserToken.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                UserToken.UserName = model.UserName;
                UserToken.Id = model.Id;
                UserToken.GuidId = Id;

                return UserToken;
            }
            catch (Exception ex)
            {
                throw new Exception("Error generando JWTToken", ex);
            }
        }
    }
}
