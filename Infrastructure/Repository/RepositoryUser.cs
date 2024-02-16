using Domain.Interfaces;
using Entity.Entities.Security;
using Entity.Enums;
using Infrastructure.Configs;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryUser : RepositoryGeneric<User>, IUser
    {
        private readonly DbContextOptions<Contexto> _optionsBuilder;
        public RepositoryUser()
        {
            _optionsBuilder = new DbContextOptions<Contexto>();
        }
        public async Task<bool> Add(string username, string password, string telefone, TipoUsuario tipoUsuario)
        {
            try {

                using (var data = new Contexto(_optionsBuilder)) {

                  await data.Users.AddAsync(
                        new User {
                            UserName = username,
                            PasswordHash = password,
                            Telefone = telefone,
                            TipoUsuario = tipoUsuario
                        });
                    await data.SaveChangesAsync();
                }

            }
            catch (Exception) {

                return false;
            }
            return true;
        }

        public async Task<bool> UserExists(string username, string password)
        {
            try {

                using (var data = new Contexto(_optionsBuilder)) {

                    return await data.Users.
                          Where(u => u.UserName.Equals(username) && u.PasswordHash.Equals(password)).
                          AsNoTracking().
                          AnyAsync();
                }

            }
            catch (Exception) {

                return false;
            }
            return true;
        }
    }
}
