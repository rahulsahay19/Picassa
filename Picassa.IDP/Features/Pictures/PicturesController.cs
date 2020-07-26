using System.Collections.Generic;

namespace Picassa.IDP.Features.Pictures
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Controllers;
    using Infrastructure;
        
    public class PicturesController : ApiController
    {
        private readonly IPictureService _pictureService;
        
        public PicturesController(IPictureService pictureService) => _pictureService = pictureService;

        /// <summary>
        /// Method to post a picture. It takes picture description and url.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Create(CreatePictureRequestModel model)
        {
            var userId = User.GetId();
            var id = await _pictureService.Create(model.ImageUrl, model.Description, userId);
            return CreatedAtAction("Create", id);
        }

        /// <summary>
        /// Method to list pictures by UserId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PictureListResponseModel>> FetchPicturesByUserId()
        {
            var userId = User.GetId();
            return await _pictureService.GetPicturesByUserId(userId);
        }
    }
}
