using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Api.Models
{
    public class ClientModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string Company { get; set; }
    }
}
