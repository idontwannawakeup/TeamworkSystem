﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TeamworkSystem.WebClient.ViewModels;

namespace TeamworkSystem.WebClient.Interfaces
{
    public interface IRatingsService
    {
        Task<IEnumerable<RatingViewModel>> GetByRatedUserId(string userId);
    }
}
