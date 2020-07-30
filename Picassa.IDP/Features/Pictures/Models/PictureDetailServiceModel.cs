namespace Picassa.IDP.Features.Pictures.Models
{
    //TODO:- Extend the model for audit info.
    public class PictureDetailServiceModel : PictureListServiceModel
    {
        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
