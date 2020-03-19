using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvShowWebApp.Data;
using TvShowWebApp.Models;

namespace TvShowWebApp.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly TvShowWebAppContext _context;
        public GenericRepository<TvShow> TvShow { get;  set; }
       
        public UnitOfWork(TvShowWebAppContext context)
        {
            _context = context;
            TvShow = new GenericRepository<TvShow>(_context);
          
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
