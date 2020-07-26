namespace Picassa.IDP.Features.Pictures
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using Models;
    using Controllers;
    using Infrastructure.Extensions;
    using static Infrastructure.WebConstants;

    [Authorize]
    public class PicturesController : ApiController
    {
        private readonly IPictureService _pictureService;

        public PicturesController(IPictureService pictureService) => _pictureService = pictureService;

        /// <summary>
        /// Method to post a picture. It takes picture description and url.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Create(CreatePicturetRequestModel model)
        {
            var userId = User.GetId();
            var id = await _pictureService.Create(model.ImageUrl, model.Description, userId);
            return CreatedAtAction("Create", id);
        }

        /// <summary>
        /// Method to list pictures by UserId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<PictureListServiceModel>> FetchPicturesByUserId()
        {
            var userId = User.GetId();
            return await _pictureService.GetPicturesByUserId(userId);
        }

        /// <summary>
        /// Method to return details of the picture
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route(Id)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PictureDetailServiceModel>> FetchPictureDetails(int id)
            => await _pictureService.GetPictureDetailsById(id);
        //return picture.OrNotFound();
        /// <summary>
        /// Method to update picture
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> Update(UpdatePictureRequestModel model)
        {
            var userId = User.GetId();
            var updated = await _pictureService.UpdatePicture(model.Id, model.Description, userId);
            if (!updated)
            {
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Method to delete picture
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(Id)]
        public async Task<ActionResult> DeletePicture(int id)
        {
            var userId = User.GetId();
            var deleted = await _pictureService.DeletePicture(id, userId);
            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
