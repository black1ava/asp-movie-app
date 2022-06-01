using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models {
  public enum Subtitles {
    English,
    Khmer
  };
  public enum MovieTypes {
    Action,
    Horror,
    Adventure,
    Science
  };
  public enum Languages {
    English,
    Khmer,
    Chinese
  };
  public class Movie {
    public int Id { get; set; }
    [Required]
    public String Title { get; set; } = String.Empty;
    [Required]
    [Display(Name = "Duration (in minutes)")]
    public int Duration { get; set; }
    public String? Subtitle { get; set; }
    [Required]
    [DataType(DataType.Date)]
    [Display(Name = "Release date")]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public String Language { get; set; } = String.Empty;
    [Required]
    [Display(Name = "Movie type")]
    public String MovieType { get; set; } = String.Empty;
  }
}