using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface IDashboardViewModel
    {
        bool isBusy { get; set; }
        Task OnInitialize();
        int total_money { get; set; }
        int average_money { get; set; }
        int total_clients { get; set; }
        int average_clients { get; set; }
        string url_afiliacion { get; set; }


    }

    public class DashboardViewModel : IDashboardViewModel
    {
        public int total_money { get; set; } = 0;
        public int average_money { get; set; } = 0;
        public int total_clients { get; set; } = 0;
        public int average_clients { get; set; } = 0;
        public string url_afiliacion { get; set; } = String.Empty;
        public bool isBusy { get; set; } = false;

        private ClienteAfiliadoService _clienteAfiliadoService;
        private UsuarioAfiliadorService _usuarioAfiliadorService;
        private AuthService _authService;
        private readonly NavigationManager _navManager;
        public DashboardViewModel(AuthService authService,UsuarioAfiliadorService usuarioAfiliadorService, ClienteAfiliadoService clienteAfiliadoService, NavigationManager navManager)
        {
            _navManager = navManager;
            _clienteAfiliadoService = clienteAfiliadoService;
            _authService = authService;
            _usuarioAfiliadorService= usuarioAfiliadorService;
        }


        public async Task OnInitialize()
        {
            isBusy = true;
            if (_authService.user_id.HasValue)
            {
                var clientesList = await _clienteAfiliadoService.GetAfiliadosByAfiliadorIdAsync(_authService.user_id.Value);
                var me = await _usuarioAfiliadorService.GetUserByIdAsync(_authService.user_id.Value);
                var sumaTotalSpent = clientesList.Sum(cliente => cliente.TotalSpent);
                var monthsUntilToday = (CalcularMesesHastaHoy(me.TimeCreated));

				total_money = sumaTotalSpent;
                average_money =  monthsUntilToday == 0 ? 0 : sumaTotalSpent / monthsUntilToday;
                total_clients = clientesList.Count();
                average_clients = monthsUntilToday == 0 ? 0 : clientesList.Count() / monthsUntilToday;
                url_afiliacion = me.UrlAfiliacion;
            }
            else
            {
                throw new NullReferenceException("User id on auth service is null");
            }


            isBusy = false;

        }



        private static int CalcularMesesHastaHoy(DateTime fechaAlmacenada)
        {
            DateTime fechaActual = DateTime.Today;
            int diferenciaMeses = ((fechaActual.Year - fechaAlmacenada.Year) * 12) + fechaActual.Month - fechaAlmacenada.Month;
            return diferenciaMeses;
        }


    }
}