﻿using Pet.Services.Models.Vk;
using System.Threading.Tasks;

namespace Pet.Services.Interfaces
{
    public interface IVkService
    {
        Task<BaseItemListResponse<PhotoInfo>> GetPhotosAsync(decimal lat, decimal lon, int count, long offset, int radius);
    }
}
