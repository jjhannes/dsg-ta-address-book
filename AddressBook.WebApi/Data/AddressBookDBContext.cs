using AddressBook.WebApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AddressBook.WebApi.Data
{
    public class AddressBookDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Client> Clients { get; set; }

        public AddressBookDBContext(DbContextOptions<AddressBookDBContext> options)
            : base(options)
        {

        }
    }
}
