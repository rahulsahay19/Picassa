using System.ComponentModel.DataAnnotations;
using static Picassa.IDP.Data.DataValidationConstants.Picture;

namespace Picassa.IDP.Data.Models
{
    public class Picture
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
