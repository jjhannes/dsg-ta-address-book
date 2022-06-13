using AddressBook.Data.Entities;
using AddressBook.Api.Models;
using AutoMapper;

namespace AddressBook.Api.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            this.CreateMap<Client, ClientModel>()
                //.ForMember(c => c.Id, o => o.Ignore())
                .ReverseMap();
        }
    }
}
