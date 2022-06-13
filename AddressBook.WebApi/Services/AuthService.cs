using AddressBook.WebApi.Data.Entities;
using AddressBook.WebApi.Data.Models;
using AddressBook.WebApi.Settings;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.WebApi.Services
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

        public Token GenerateJwtToken(User user)
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

            Token authToken = this._mapper.Map<Token>(user, options =>
                options.AfterMap((object s, Token t) => t.AccessToken = tokenValue));

            return authToken;
        }
    }
}
