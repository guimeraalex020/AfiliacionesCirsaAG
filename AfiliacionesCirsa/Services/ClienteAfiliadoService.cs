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
    public class ClienteAfiliadoService
    {
        private static readonly List<ClienteAfiliado> ClientesAfiliados = new List<ClienteAfiliado>();

        public ClienteAfiliadoService()
        {
            LoadInitialData();
        }


        public void LoadInitialData()
        {
            // ... Código previo para agregar objetos WeatherForecast

            // Agregar 10 objetos UsuarioAfiliador a UsuariosAfiliadores
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                ClientesAfiliados.Add(new ClienteAfiliado
                {
                    Id = i,
                    NombreCompleto = $"Usuario {i + 1}",
                    EmailAddress = $"usuario{i + 1}@example.com",
                    Password = $"Password{i + 1}", // Generar hash para la contraseña,
                    Afiliador_id = random.Next(0, 10)
            });
            }
        }

        public async Task<List<ClienteAfiliado>> GetAfiliadosByAfiliadorIdAsync(int user_id)
        {
            await Task.Delay(5000);
            List<ClienteAfiliado> clientes = new List<ClienteAfiliado>();

            clientes = await Task.FromResult(ClientesAfiliados
                .Where(usuario => usuario.Afiliador_id == user_id)
                .ToList());

            return clientes;
        }

        public async Task<ClienteAfiliado> GetClienteByIdAsync(int user_id)
        {
            await Task.Delay(5000);
            var user = await Task.FromResult(ClientesAfiliados
                .Where(usuario => usuario.Id == user_id)
                .FirstOrDefault());
            if (user == null) throw new NullReferenceException("Cliente con esta id no existe");

            return user;
        }

    }
}
