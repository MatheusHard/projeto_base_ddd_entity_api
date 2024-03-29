﻿using Application.Interfaces;
using Domain.Interfaces;
using Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Applications
{
    public class ApplicationUser : IApplicationUser
    {
        IUser _user;

        public ApplicationUser(IUser user)
        {
            _user = user;
        }

        public async Task<bool> AddUser(string username, string password, string telefone, TipoUsuario tipoUsuario)
        {
            return await _user.AddUser(username, password, telefone, tipoUsuario);
        }

        public async Task<string> GetIdUser(string username)
        {
            return await _user.GetIdUser(username);
        }

        public async Task<bool> UserExists(string username, string password)
        {
            return await _user.UserExists(username, password);
        }
    }
}
