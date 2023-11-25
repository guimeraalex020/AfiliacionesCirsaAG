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
        UsuarioAfiliador current_user { get; set; }
        List<ClienteAfiliado>? clientesAfiliados {  get; set; }

    }

    public class FetchDataViewModel : IFetchDataViewModel
    {
        public UsuarioAfiliador current_user { get; set; } = new UsuarioAfiliador();
        public List<ClienteAfiliado>? clientesAfiliados { get; set; }
        public bool isBusy { get; set; } = false;

        private ClienteAfiliadoService _clienteAfiliadoService;
        private UsuarioAfiliadorService _usuarioAfiliadorService;
        private readonly NavigationManager _navManager;
        public FetchDataViewModel(UsuarioAfiliadorService usuarioAfiliadorService, ClienteAfiliadoService clienteAfiliadoService, NavigationManager navManager)
        {
            _navManager = navManager;
            _usuarioAfiliadorService = usuarioAfiliadorService;
            _clienteAfiliadoService = clienteAfiliadoService;
        }

        public async Task OnInitialize()
        {
            isBusy = true;
            current_user = await _usuarioAfiliadorService.GetUserByIdAsync(2);
            clientesAfiliados = await _clienteAfiliadoService.GetAfiliadosByAfiliadorIdAsync(2);
            isBusy = false;
        }



        public void verDetalle(int parametro)
        {
            _navManager.NavigateTo("/DataDetail/2");
        }


        
    }
}