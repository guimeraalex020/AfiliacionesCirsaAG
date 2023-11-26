using System;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AfiliacionesCirsa.Models;

namespace AfiliacionesCirsa.Services
{
    public class AuthService
    {
        public bool? isLogged { get; set; } = null;
        public int? user_id { get; set; } = null;
        private UsuarioAfiliadorService usuarioAfiliadorService { get; set; }
        public AuthService(UsuarioAfiliadorService _usuarioAfiliadorService) {
            usuarioAfiliadorService = _usuarioAfiliadorService;
            isLogged = false;
        }

        public async Task Login(string email, string password)
        {
            var user = await usuarioAfiliadorService.GetUserByEmailAsync(email);

            if (user == null || user.Password != password)
            {
                isLogged = false;
            }
            else
            {
                user_id = user.Id;
                isLogged = true;
            }
        }

        public void Logout() { isLogged = false; user_id = null; }

        public async Task Register(string email, string password, string fullname)
        {
            usuarioAfiliadorService.AddUser(email, password, fullname);
            await Login(email, password);
        }

    }
}
