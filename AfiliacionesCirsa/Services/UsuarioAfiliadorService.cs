using System;
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
            Random random = new Random();
            DateTime fechaActual = DateTime.Now.AddMonths(-1);
            DateTime fechaMinima = fechaActual.AddYears(-2);

            int diasAleatorios = random.Next((fechaActual - fechaMinima).Days); // Rango de días entre hace dos años y hoy
            DateTime fechaAleatoria = fechaActual.AddDays(-diasAleatorios); // Fecha aleatoria dentro del rango

            for (int i = 0; i < 10; i++)
            {
                ClientesAfiliados.Add(new UsuarioAfiliador
                {
                    Id = i,
                    NombreCompleto = $"Usuario {i + 1}",
                    EmailAddress = $"usuario{i + 1}@example.com",
                    Password = $"Password{i + 1}", // Generar hash para la contraseña
                    TimeCreated = fechaAleatoria,
                    UrlAfiliacion = $"urldeprueba.estoesunaprueba/{i}"
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
            var user = await Task.FromResult(ClientesAfiliados
                .Where(usuario => usuario.Id == user_id)
                .FirstOrDefault());
            if (user == null) throw new NullReferenceException("Usuario con esta id no existe");

            return user;
        }

        public async Task<UsuarioAfiliador?> GetUserByEmailAsync(string email)
        {
            var user = await Task.FromResult(ClientesAfiliados
                .Where(usuario => usuario.EmailAddress == email)
                .FirstOrDefault());

            return user;
        }

        public void AddUser(string email, string password, string fullname)
        {
            var newUser = new UsuarioAfiliador
            {
                Id = ClientesAfiliados.Last().Id + 1,
                NombreCompleto = fullname,
                EmailAddress = email,
                Password = password,
                UrlAfiliacion = $"urldeprueba.estoesunaprueba/{ClientesAfiliados.Last().Id + 1}"
			};

            ClientesAfiliados.Add(newUser);
        }

    }
}
