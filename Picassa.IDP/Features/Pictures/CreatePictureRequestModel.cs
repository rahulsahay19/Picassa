using System.ComponentModel.DataAnnotations;
namespace Picassa.IDP.Features.Pictures
{
    using static Data.DataValidationConstants.Picture;
    public class CreatePictureRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
