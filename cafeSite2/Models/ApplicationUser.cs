using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace cafeSite2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public required string name { get; set; }
        public required string surname { get; set; }
        [NotMapped]
        public string rol { get; set; }

    }
}
