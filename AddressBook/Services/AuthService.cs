using AddressBook.Api.Models;
using AddressBook.Data.Entities;
using AddressBook.Settings;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AddressBook.Services
{
    public class AuthService
    {
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AuthService(IOptions<AppSettings> appSettings, IMapper mapper)
        {
            this._appSettings = appSettings.Value;
            this._mapper = mapper;
        }

        public TokenModel GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this._appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(this._appSettings.TokenTTL),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenValue = tokenHandler.WriteToken(token);

            TokenModel authToken = this._mapper.Map<TokenModel>(user, options =>
                options.AfterMap((object s, TokenModel t) => t.AccessToken = tokenValue));

            return authToken;
        }
    }
}
