using System;
using static AfiliacionesCirsa.Pages.FetchData;
using static System.Net.WebRequestMethods;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AfiliacionesCirsa.Models;

namespace AfiliacionesCirsa.Services
{
    public class UsuarioAfiliadorService
    {
        private static readonly List<UsuarioAfiliador> ClientesAfiliados = new List<UsuarioAfiliador>();

        public UsuarioAfiliadorService() {
            LoadInitialData();
        }


        public void LoadInitialData()
        {
            // ... Código previo para agregar objetos WeatherForecast

            // Agregar 10 objetos UsuarioAfiliador a UsuariosAfiliadores
            for (int i = 0; i < 10; i++)
            {
                ClientesAfiliados.Add(new UsuarioAfiliador
                {
                    Id = i,
                    NombreCompleto = $"Usuario {i + 1}",
                    EmailAddress = $"usuario{i + 1}@example.com",
                    Password = $"Password{i + 1}" // Generar hash para la contraseña
                });
            }
        }
        /*
        public async Task<List<UsuarioAfiliador>> GetAfiliadoresAsync()
        {
            await Task.Delay(5000);
            return await Task.FromResult(ClientesAfiliados.ToList());
        }*/

        public async Task<UsuarioAfiliador> GetUserByIdAsync(int user_id)
        {
            await Task.Delay(5000);
            var user = await Task.FromResult(ClientesAfiliados
                .Where(usuario => usuario.Id == user_id)
                .FirstOrDefault());
            if (user == null) throw new NullReferenceException("Usuario con esta id no existe");

            return user;
        }

    }
}
