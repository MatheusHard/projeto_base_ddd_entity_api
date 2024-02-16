using Domain.Interfaces.Generics;
using Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics
{
    public class RepositoryGeneric<T> : IGenerics<T>, IDisposable where T : class
    {
        private bool disposedValue;
        private readonly DbContextOptions<Contexto> _optionsBuilder;  


        public RepositoryGeneric() 
        {
            _optionsBuilder = new DbContextOptions<Contexto>();       
        
        }  
        public async Task Add(T obj)
        {
            using (var data = new Contexto(_optionsBuilder)) 
            {
                await data.Set<T>().AddAsync(obj);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T obj)
        {
            using (var data = new Contexto(_optionsBuilder)) {
                data.Set<T>().Remove(obj);
                await data.SaveChangesAsync();
            }
        }
     
        public async Task<List<T>> GetAll()
        {
            using (var data = new Contexto(_optionsBuilder))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var data = new Contexto(_optionsBuilder)) {
               return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task Update(T obj)
        {
            using (var data = new Contexto(_optionsBuilder)) {
                data.Set<T>().Update(obj);
                await data.SaveChangesAsync();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue) {
                if (disposing) {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RepositoryGeneric()
        // {
        //     // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // Não altere este código. Coloque o código de limpeza no método 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
