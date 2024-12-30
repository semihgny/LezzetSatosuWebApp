using System.ComponentModel.DataAnnotations;

namespace cafeSite2.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

    }
}
