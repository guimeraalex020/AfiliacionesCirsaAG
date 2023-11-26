using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AfiliacionesCirsa.ViewModels 
{
    public interface IClienteSearchViewModel
    {
        ObservableCollection<ClienteAfiliado> clientes { get; set; }
        List<String> dateOptions { get; set; }
        bool isBusy { get; set; }
        Task OnInitialize();
        Task Filter(string date, string name, string mail);


    }

    public class ClienteSearchViewModel : IClienteSearchViewModel
    {
        public bool isBusy { get; set; } = false;
        public ObservableCollection<ClienteAfiliado> clientes{ get; set;}
        public List<string> dateOptions { get; set; } = new List<string>();

        private AuthService _authService;
        private readonly NavigationManager _navManager;
        private readonly ClienteAfiliadoService _clienteAfiliadoService;
        public ClienteSearchViewModel(AuthService authService, NavigationManager navManager, ClienteAfiliadoService clienteAfiliadoService)
        {
            _navManager = navManager;
            _authService = authService;
            _clienteAfiliadoService = clienteAfiliadoService;
        }


        public async Task OnInitialize()
        {
            isBusy = true;
            if (_authService.user_id.HasValue)
            {
                dateOptions = _clienteAfiliadoService.GetDateIntervals();
                var clientesList = await _clienteAfiliadoService.GetAfiliadosByAfiliadorIdAsync(_authService.user_id.Value);
                clientes = new ObservableCollection<ClienteAfiliado>(clientesList);
            }
            else
            {
                throw new NullReferenceException("User id on auth service is null");
            }


            isBusy = false;

        }

        public async Task Filter(string date, string name, string mail)
        {
            isBusy = true;
            var clientesListFiltered = await _clienteAfiliadoService.Filter(date, name, mail);
            clientes = new ObservableCollection<ClienteAfiliado>(clientesListFiltered);
            isBusy = false;
        }





    }
}