using AddressBook.Data.Entities;
using AddressBook.Api.Models;
using AutoMapper;

namespace AddressBook.Data.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            this.CreateMap<Client, ClientModel>()
                //.ForMember(c => c.Id, o => o.Ignore())
                .ReverseMap();

            // Necessary for MVC project which deals with entities directly
            this.CreateMap<Client, Client>();
        }
    }
}
