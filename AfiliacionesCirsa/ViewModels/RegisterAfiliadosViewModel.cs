using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface IRegisterAfiliadosViewModel
    {
        bool showModal { get; set; }
        bool isBusy { get; set; }
        Task RegisterAfiliados();
        string email { get; set; }
        string fullName { get; set; }
        string password { get; set; }

    }

    public class RegisterAfiliadosViewModel : IRegisterAfiliadosViewModel
    {
        public bool isBusy { get; set; } = false;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool showModal { get; set; } = false;
        public string fullName { get; set; } = string.Empty;

        private readonly NavigationManager _navManager;
        private readonly ClienteAfiliadoService _clienteAfiliadoService;
        public RegisterAfiliadosViewModel(NavigationManager navManager, ClienteAfiliadoService clienteAfiliadoService)
        {
            _navManager = navManager;
            _clienteAfiliadoService = clienteAfiliadoService;
        }


        public async Task RegisterAfiliados()
        {
            isBusy = true;
            await _clienteAfiliadoService.RegisterAfiliados(email, password, fullName);
            _navManager.NavigateTo("/ClientPresentation");
            isBusy = false;
        }




    }
}