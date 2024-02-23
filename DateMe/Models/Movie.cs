using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Gatherum.Models
{
    // Represents a movie entity with properties defining its attributes.
    public class Movie
    {
        // Primary key for the Movie entity.
        [Key]
        [Required]
        public int MovieId { get; set; }

        // Foreign key for the Category entity.
        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        // Navigation property for the Category entity.
        public Category? Category { get; set; }

        // The title of the movie.
        [Required]
        public string Title { get; set; }

        // The release year of the movie, constrained between 1888 and 2024.
        [Required]
        [Range(1888, 2024)]
        public int Year { get; set; }

        // The director of the movie.
        public string? Director { get; set; }

        // The rating of the movie.
        public string? Rating { get; set; }

        // Indicates whether the movie has been edited.
        [Required]
        public bool Edited { get; set; }

        // Information about to whom the movie is lent.
        public string? LentTo { get; set; }

        // The number of copies of the movie stored in Plex.
        [Required]
        public int CopiedToPlex { get; set; }

        // Additional notes about the movie, limited to 25 characters.
        [StringLength(25)]
        public string? Notes { get; set; }
    }
}