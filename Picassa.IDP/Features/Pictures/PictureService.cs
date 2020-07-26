namespace Picassa.IDP.Features.Pictures
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    public class PictureService : IPictureService
    {
        private readonly PicassaDbContext _dbContext;

        public PictureService(PicassaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var picture = new Picture
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };
            _dbContext.Add(picture);
            await _dbContext.SaveChangesAsync();
            return picture.Id;
        }
    }
}
