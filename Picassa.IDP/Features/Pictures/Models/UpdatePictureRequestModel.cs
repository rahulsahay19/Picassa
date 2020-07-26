namespace Picassa.IDP.Features.Pictures.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataValidationConstants.Picture;
    public class UpdatePictureRequestModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
