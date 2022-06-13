using AddressBook.WebApi.Data.Entities;
using AddressBook.WebApi.Data.Models;
using AutoMapper;

namespace AddressBook.WebApi.Profiles
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
