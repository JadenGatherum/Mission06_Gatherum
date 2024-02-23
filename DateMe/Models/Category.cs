using System.ComponentModel.DataAnnotations;

namespace Mission06_Gatherum.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string category { get; set; }
    }
}
