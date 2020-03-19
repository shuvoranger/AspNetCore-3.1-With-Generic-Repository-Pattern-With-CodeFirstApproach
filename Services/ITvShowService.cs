using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvShowWebApp.Models;

namespace TvShowWebApp.Services
{
    public interface ITvShowService
    {
        IEnumerable<TvShow> GetAllList();

        TvShow GetDetailsById(Int32 Id);

        Task<TvShow> CreateEntry(TvShow model);

        Task<TvShow> Delete(TvShow model);


    }
}
