using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface IFetchDataViewModel
    {
        bool isBusy { get; set; }
        Task OnInitialize();
        void verDetalle(int parametro);
        int current_user_id { set; }
        UsuarioAfiliador current_user { get; set; }
        List<ClienteAfiliado>? clientesAfiliados {  get; set; }

    }

    public class FetchDataViewModel : IFetchDataViewModel
    {
        public UsuarioAfiliador current_user { get; set; } = new UsuarioAfiliador();
        public List<ClienteAfiliado>? clientesAfiliados { get; set; }
        public bool isBusy { get; set; } = false;
        public int current_user_id { set; get;  }

        private ClienteAfiliadoService _clienteAfiliadoService;
        private UsuarioAfiliadorService _usuarioAfiliadorService;
        private AuthService _authService;
        private readonly NavigationManager _navManager;
        public FetchDataViewModel(AuthService authService, UsuarioAfiliadorService usuarioAfiliadorService, ClienteAfiliadoService clienteAfiliadoService, NavigationManager navManager)
        {
            _navManager = navManager;
            _usuarioAfiliadorService = usuarioAfiliadorService;
            _clienteAfiliadoService = clienteAfiliadoService;
            _authService = authService;
        }


        public async Task OnInitialize()
        {
            isBusy = true;
            current_user = await _usuarioAfiliadorService.GetUserByIdAsync(current_user_id);
            clientesAfiliados = await _clienteAfiliadoService.GetAfiliadosByAfiliadorIdAsync(current_user_id);
            isBusy = false;
            
        }


        public void verDetalle(int parametro)
        {
            _navManager.NavigateTo("/DataDetail/2");
        }


        
    }
}