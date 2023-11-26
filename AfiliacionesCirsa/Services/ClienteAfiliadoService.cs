using System;
using static System.Net.WebRequestMethods;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AfiliacionesCirsa.Models;
using System.Xml.Linq;

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
            for (int i = 0; i < 10000; i++)
            {
                ClientesAfiliados.Add(new ClienteAfiliado
                {
                    Id = i,
                    NombreCompleto = $"Usuario {i + 1}",
                    EmailAddress = $"usuario{i + 1}@example.com",
                    Password = $"Password{i + 1}", // Generar hash para la contraseña,
                    Afiliador_id = random.Next(0, 10),
                    TotalSpent = random.Next(0,30)
            });
            }
        }

        public async Task<List<ClienteAfiliado>> GetAfiliadosByAfiliadorIdAsync(int user_id)
        {
            List<ClienteAfiliado> clientes = new List<ClienteAfiliado>();

            clientes = await Task.FromResult(ClientesAfiliados
                .Where(usuario => usuario.Afiliador_id == user_id)
                .ToList());

            return clientes;
        }

        public async Task<ClienteAfiliado> GetClienteByIdAsync(int user_id)
        {
            var user = await Task.FromResult(ClientesAfiliados
                .Where(usuario => usuario.Id == user_id)
                .FirstOrDefault());
            if (user == null) throw new NullReferenceException("Cliente con esta id no existe");

            return user;
        }

        public List<string> GetDateIntervals()
        {
            return new List<string>
            {
                "",
                "Hoy",
                "Ultimas 48 Horas",
                "Ultima Semana",
                "Ultimo Mes",
                "Ultimo Trimestre",
                "Ultimo Año",
                "Ultimos 2 Años"
            };
        }

        public async Task<List<ClienteAfiliado>> Filter(string date, string name, string email)
        {
            //Calculamos la fecha segun el string
            DateTime fechaComparativa;
            switch (date)
            {
                case "Hoy":
                    fechaComparativa = DateTime.Today;
                    break;
                case "Ultimas 48 Horas":
                    fechaComparativa = DateTime.Now.AddDays(-2);
                    break;
                case "Ultima Semana":
                    fechaComparativa = DateTime.Now.AddDays(-14);
                    break;
                case "Ultimo Mes":
                    fechaComparativa = DateTime.Now.AddMonths(-1);
                    break;
                case "Ultimo Trimestre":
                    fechaComparativa = DateTime.Now.AddMonths(-3);
                    break;
                case "Ultimo Año":
                    fechaComparativa = DateTime.Now.AddYears(-1);
                    break;
                case "Ultimos 2 años":
                    fechaComparativa = DateTime.Now.AddYears(-2);
                    break;
                // ... y así sucesivamente para cada opción
                default:
                    fechaComparativa = DateTime.Now.AddYears(-10);
                    break;
            }

            return await Task.FromResult(ClientesAfiliados
            .Where(usuario =>
                (string.IsNullOrWhiteSpace(email) || usuario.EmailAddress == email) &&
                (string.IsNullOrWhiteSpace(name) || usuario.NombreCompleto == name) &&
                (usuario.TimeCreated >= fechaComparativa))
            .ToList());

            return await Task.FromResult(ClientesAfiliados
            .Where(usuario =>
                usuario.EmailAddress == email ||
                usuario.NombreCompleto == name)
            .ToList());
                }
    }
}
