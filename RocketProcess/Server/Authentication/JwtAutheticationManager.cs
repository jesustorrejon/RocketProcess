﻿using Microsoft.IdentityModel.Tokens;
using RocketProcess.Shared.Seguridad;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RocketProcess.Server.Authentication
{
    public class JwtAutheticationManager
    {
        public const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;

        private UserAccountService _userAccountService;

        public JwtAutheticationManager(UserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        public UserSession? GenerateJwtToken(string correo, string password)
        {
            if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(password))
                return null;
            
            // Validacion las credenciales de usuario
            var userAcoount = _userAccountService.GetUserAccountByUserName(correo, password).GetAwaiter().GetResult();
            if (userAcoount == null || userAcoount.Password.ToUpper() != password.ToUpper())
                return null;

            // Generando JWT Token
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim("Id", userAcoount.Id.ToString()),
                new Claim(ClaimTypes.Name, userAcoount.UserName),
                new Claim(ClaimTypes.Role, userAcoount.Role),
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            //Retornarmos el objeto UserSession
            var userSession = new UserSession
            {
                Id = userAcoount.Id,
                UserName = userAcoount.UserName,
                Role = userAcoount.Role,
                Token = token,
                Permisos = "cualquiera",
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            };

            return userSession;
        }
    }
}
