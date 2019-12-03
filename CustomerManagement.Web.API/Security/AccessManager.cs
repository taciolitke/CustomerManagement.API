using System;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using CustomerManagement.Web.API.Model.Login;
using CustomerManagement.Web.Domain.Interfaces.Services;
using CustomerManagement.Web.Domain.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CustomerManagement.Web.API.Security
{
    public class AccessManager
    {
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IAutenticationService _autenticationService;
        private readonly IUserService _userService;

        public AccessManager(
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations,
            IAutenticationService autenticationService,
             IUserService userService
            )
        {
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _autenticationService = autenticationService;
            _userService = userService;
        }

        public bool ValidateCredentials(UserLoginRequest user)
        {
            bool credenciaisValidas = false;
            if (user != null && !String.IsNullOrWhiteSpace(user.Email) && !String.IsNullOrWhiteSpace(user.Password))
            {
                credenciaisValidas = _autenticationService.CheckPasswordSignIn(user.Email, user.Password);
            }

            return credenciaisValidas;
        }

        public Token GenerateToken(UserLoginRequest user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Email, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        new Claim(ClaimTypes.Role, _userService.GetBy(x => x.Email.Equals(user.Email)).Role),
                }
            );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao,
                
            });
            var token = handler.WriteToken(securityToken);

            return new Token()
            {
                Authenticated = true,
                Created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK",
            };
        }
    }
}
