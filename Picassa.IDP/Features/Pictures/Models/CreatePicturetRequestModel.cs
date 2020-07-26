namespace Picassa.IDP.Features.Pictures.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataValidationConstants.Picture;
    public class CreatePicturetRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
