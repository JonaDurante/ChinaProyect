using Microsoft.IdentityModel.Tokens;
<<<<<<< Updated upstream
using StudioAdminData.Models.DataModels.JWT;
=======
using StudioAdminData.Models.Business;
using StudioAdminData.Models.JWT;
>>>>>>> Stashed changes
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace StudioAdminData.Helppers
{
    public static class JwtHelppers
    {
<<<<<<< Updated upstream
=======
        private static Roles CurrentRol { get; set; }
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream

            if (UserAcounts.UserName == "Karo")
=======
            switch (CurrentRol)
>>>>>>> Stashed changes
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            else 
            {
                claims.Add(new Claim(ClaimTypes.Role, "User")); // usuario básico
                claims.Add(new Claim("UserOnly", "User 1")); 
            }

            return claims;
        }

        public static IEnumerable<Claim> GetClaims(this UserToken UserAcounts, out Guid Id) 
        {
            Id = Guid.NewGuid();
            return GetClaims(UserAcounts, Id);
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
                Guid Id;
                // Expira en un día
                DateTime expiredTime = DateTime.Now.AddDays(1); 
                // Validez
                UserToken.Validity = expiredTime.TimeOfDay;
                // Genero JWT de
                var jwtToken = new JwtSecurityToken(
                    issuer: jwtSettings.ValidIsUser,
                    audience: jwtSettings.ValidAudience,
                    claims: GetClaims(model, out Id),
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
