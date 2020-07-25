using System.ComponentModel.DataAnnotations;
using static Picassa.IDP.Data.DataValidationConstants.Picture;

namespace Picassa.IDP.Models.Pictures
{
    public class CreatePictureRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
