using AddressBook.WebApi.Data.Entities;
using System;
using System.Collections.Generic;

namespace AddressBook.WebApi.Data.Repos.Mock
{
    public static class StaticData
    {
        public static List<Client> Clients = new List<Client>
            {
                new Client
                {
                    Id = 1,
                    Name = "Jack",
                    Surname = "Sparrow",
                    Company = "Black Pearl",
                    ContactNumber = "0105555225",
                    Email = "jack.sparrow@black-pearl.ss",
                    Created = new DateTime(1860, 5, 13)
                },
                new Client
                {
                    Id = 2,
                    Name = "Mike",
                    Surname = "Tyson",
                    Company = "Pro Boxing",
                    ContactNumber = "0105556453",
                    Email = "mike.tyson@pro-box.usa",
                    Created = new DateTime(1966, 6, 30)
                }
            };
        public static List<User> Users = new List<User>
            {
                new User
                {
                    Username = "jj.hannes.swanepoel@gmail.com",
                    FirstName = "Hannes",
                    LastName = "Swanepoel",
                    Password = "P@ssw0rd123"
                }
            };
    }
}
