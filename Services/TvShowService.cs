using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvShowWebApp.Data;
using TvShowWebApp.Models;
using TvShowWebApp.Repository;

namespace TvShowWebApp.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly TvShowWebAppContext _context;
        private readonly UnitOfWork _repo;
 
        public TvShowService(TvShowWebAppContext context)
        {
            _context = context;
            _repo = new UnitOfWork(_context);
        }

        public IEnumerable<TvShow> GetAllList()
        {          
                return _repo.TvShow.GetAll();     
        }

        public TvShow GetDetailsById(Int32 Id)
        {
            return _repo.TvShow.GetById(Id);
        }


        public async Task<TvShow> CreateEntry(TvShow model)
        {
            try
            {
                var order = new TvShow();

                if (model.Id == 0)
                {

                    order = new TvShow
                    {
                        Title = model.Title,
                        Rating = model.Rating,
                        ImageUrl = model.ImageUrl,
                        ImdbUrl = model.ImdbUrl,
                        Genre = model.Genre,
                        Id = model.Id
                    };
                    await _repo.TvShow.AddAsync(order);
                    await _repo.SaveAsync();

                }
                else if(model.Id > 0)
                {

                    order = new TvShow
                    {
                        Title = model.Title,
                        Rating = model.Rating,
                        ImageUrl = model.ImageUrl,
                        ImdbUrl = model.ImdbUrl,
                        Genre = model.Genre,
                        Id = model.Id
                    };
                    await _repo.TvShow.UpdateAsync(order);
                    await _repo.SaveAsync();

                }
                    return new TvShow
                    {
                        Title = order.Title,
                        Rating = order.Rating,
                        ImageUrl = order.ImageUrl,
                        ImdbUrl = order.ImdbUrl,
                        Genre = order.Genre,
                        Id = order.Id
                    };
                    
                
            }

            catch (Exception ex)
            {
                return new TvShow
                {
                 
                };
            }
        }

        public async Task<TvShow> Delete(TvShow order)
        {
            _repo.TvShow.Remove(order);
            await _repo.SaveAsync();
            return new TvShow
            {
                Title = order.Title,
                Rating = order.Rating,
                ImageUrl = order.ImageUrl,
                ImdbUrl = order.ImdbUrl,
                Genre = order.Genre,
                Id = order.Id
            };
        }
    }
}
