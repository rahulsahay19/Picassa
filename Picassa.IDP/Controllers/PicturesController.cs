using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Picassa.IDP.Data;
using Picassa.IDP.Data.Models;
using Picassa.IDP.Infrastructure;
using Picassa.IDP.Models.Pictures;

namespace Picassa.IDP.Controllers
{
    public class PicturesController : ApiController
    {
        private readonly PicassaDbContext _dbContext;

        public PicturesController(PicassaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(CreatePictureRequestModel model)
        {
            var userId = User.GetId();
            var picture = new Picture
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };
            _dbContext.Add(picture);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction("Create", picture.Id);
        }
    }
}
