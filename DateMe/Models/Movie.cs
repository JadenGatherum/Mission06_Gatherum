using System.ComponentModel.DataAnnotations;

namespace Mission06_Gatherum.Models
{
    public class Movie
    {
        [Required]
        public string Category { get; set; }

        [Key]
        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string? Lent { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
        


    }
}
