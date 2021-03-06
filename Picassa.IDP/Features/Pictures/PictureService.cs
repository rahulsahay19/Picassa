﻿namespace Picassa.IDP.Features.Pictures
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models;
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

        public async Task<IEnumerable<PictureListServiceModel>> GetPicturesByUserId(string userId)
            => await _dbContext
                .Pictures
                .Where(p => p.UserId == userId)
                .Select(p => new PictureListServiceModel
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl
                }).ToListAsync();

        public async Task<PictureDetailServiceModel> GetPictureDetailsById(int id)
            => await _dbContext
                .Pictures
                .Where(p => p.Id == id)
                .Select(p => new PictureDetailServiceModel
                {
                    Id=p.Id,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    UserId = p.UserId,
                    UserName = p.User.UserName
                }).FirstOrDefaultAsync();

        public async Task<bool> UpdatePicture(int id, string description, string userId)
        {
            var picture = await GetByIdAndByUserId(id, userId);
            if (picture == null)
            {
                return false;
            }

            picture.Description = description;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePicture(int id, string userId)
        {
            var picture = await GetByIdAndByUserId(id, userId);
            if (picture == null)
            {
                return false;
            }

            _dbContext.Pictures.Remove(picture);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        private async Task<Picture> GetByIdAndByUserId(int id, string userId)
            => await _dbContext
                .Pictures
                .Where(p => p.Id == id && p.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
