using System.ComponentModel.DataAnnotations;

namespace ETSFlixAPI.Model;
public class Movie
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
    [Required]
    [MaxLength(10)]
    public string Genre { get; set; }
    [Required]
    public string Duration { get; set; }

}