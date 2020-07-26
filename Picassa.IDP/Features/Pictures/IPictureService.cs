﻿using System.Collections.Generic;
namespace Picassa.IDP.Features.Pictures
{
    using Models;
    using System.Threading.Tasks;
    public interface IPictureService
    {
        Task<int> Create(string imageUrl, string description, string userId);
        Task<IEnumerable<PictureListServiceModel>> GetPicturesByUserId(string userId);
        Task<PictureDetailServiceModel> GetPictureDetailsById(int id);
    }
}
