using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface IRecentClientsViewModel
    {
        bool isBusy { get; set; }
        Task OnInitialize();
        void verDetalle(int parametro);
        List<ClienteAfiliado>? clientesAfiliados {  get; set; }

    }

    public class RecentClientsViewModel : IRecentClientsViewModel
    {
        public List<ClienteAfiliado>? clientesAfiliados { get; set; }
        public bool isBusy { get; set; } = false;

        private ClienteAfiliadoService _clienteAfiliadoService;
        private UsuarioAfiliadorService _usuarioAfiliadorService;
        private AuthService _authService;
        private readonly NavigationManager _navManager;
        public RecentClientsViewModel(AuthService authService, UsuarioAfiliadorService usuarioAfiliadorService, ClienteAfiliadoService clienteAfiliadoService, NavigationManager navManager)
        {
            _navManager = navManager;
            _usuarioAfiliadorService = usuarioAfiliadorService;
            _clienteAfiliadoService = clienteAfiliadoService;
            _authService = authService;
        }


        public async Task OnInitialize()
        {
            isBusy = true;
            if (_authService.user_id.HasValue)
            {
                var clientes = await (_clienteAfiliadoService.GetAfiliadosByAfiliadorIdAsync(_authService.user_id.Value));
                clientesAfiliados = clientes.GetRange(0,10);
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