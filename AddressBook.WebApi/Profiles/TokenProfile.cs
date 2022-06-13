using AddressBook.WebApi.Data.Entities;
using AddressBook.WebApi.Data.Models;
using AutoMapper;

namespace AddressBook.WebApi.Profiles
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            this.CreateMap<User, TokenModel>();
        }
    }
}
