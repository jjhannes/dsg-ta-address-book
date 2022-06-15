using AddressBook.Data.Entities;
using System;
using System.Collections.Generic;

namespace AddressBook.Data.Repos.Mock
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
                },
                new Client
                {
                    Id = 3,
                    Name = "Pope",
                    Surname = "Francis",
                    Company = "The Roman Catholic Church",
                    ContactNumber = "0105557673",
                    Email = "pope.francis@trcc.ita",
                    Created = new DateTime(1936, 12, 17)
                },
                new Client
                {
                    Id = 3,
                    Name = "Jane",
                    Surname = "Doe",
                    Company = "Doe Inc.",
                    ContactNumber = "0105555263",
                    Email = "jane.doe@doeinc.io",
                    Created = new DateTime(1982, 10, 3)
                },
                new Client
                {
                    Id = 3,
                    Name = "Cloe",
                    Surname = "Vermuth",
                    Company = "Borderlands Records",
                    ContactNumber = "0105553563",
                    Email = "cloe.vermuth@blreckords.pda",
                    Created = new DateTime(2567, 7, 12)
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
