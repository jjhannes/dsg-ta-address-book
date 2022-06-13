using AddressBook.Data.Entities;
using AddressBook.Api.Models;
using AutoMapper;

namespace AddressBook.Data.Profiles
{
    public class TokenProfile : Profile
    {
        public TokenProfile()
        {
            this.CreateMap<User, TokenModel>();
        }
    }
}
