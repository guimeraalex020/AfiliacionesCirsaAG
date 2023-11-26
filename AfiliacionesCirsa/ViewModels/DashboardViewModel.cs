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


    }

    public class DashboardViewModel : IDashboardViewModel
    {
        public int total_money { get; set; } = 0;
        public int average_money { get; set; } = 0;
        public int total_clients { get; set; } = 0;
        public int average_clients { get; set; } = 0;
        public bool isBusy { get; set; } = false;

        private ClienteAfiliadoService _clienteAfiliadoService;
        private AuthService _authService;
        private readonly NavigationManager _navManager;
        public DashboardViewModel(AuthService authService, ClienteAfiliadoService clienteAfiliadoService, NavigationManager navManager)
        {
            _navManager = navManager;
            _clienteAfiliadoService = clienteAfiliadoService;
            _authService = authService;
        }


        public async Task OnInitialize()
        {
            isBusy = true;
            if (_authService.user_id.HasValue)
            {
                total_money = 0;
                average_money = 0;
                total_clients = 0;
                average_clients = 0;
            }
            else
            {
                throw new NullReferenceException("User id on auth service is null");
            }


            isBusy = false;

        }


        public void verDetalle(int parametro)
        {
            _navManager.NavigateTo("/DataDetail/2");
        }


        
    }
}