namespace Picassa.IDP.Features.Pictures
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataValidationConstants.Picture;
    public class PictureListResponseModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        
    }
}
