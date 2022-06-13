using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.WebApi.Data.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string ContactNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
