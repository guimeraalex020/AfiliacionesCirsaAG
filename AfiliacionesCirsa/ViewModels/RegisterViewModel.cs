using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface IRegisterViewModel
    {
        bool showModal { get; set; }
        bool isBusy { get; set; }
        void OnInitialize();
        Task Register();
        string email { get; set; }
        string fullName { get; set; }
        string password { get; set; }

    }

    public class RegisterViewModel : IRegisterViewModel
    {
        public bool isBusy { get; set; } = false;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool showModal { get; set; } = false;
        public string fullName { get; set; } = string.Empty;

        private AuthService _authService;
        private readonly NavigationManager _navManager;
        public RegisterViewModel(AuthService authService, NavigationManager navManager)
        {
            _navManager = navManager;
            _authService = authService;
        }

        public bool isAllowed()
        {
            if (_authService.isLogged == true) return false;
            else return true;
        }

        public void OnInitialize()
        {
            if (!isAllowed())
            {
                _navManager.NavigateTo("/");
            }
        }

        public async Task Register()
        {
            if (isAllowed())
            {
                isBusy = true;
                await _authService.Register(email, password, fullName);
                if (_authService.isLogged == true)
                {
                    _navManager.NavigateTo("/home");
                }
                else
                {
                    showModal = true;
                }
                isBusy = false;
            }

            else
            {
                _navManager.NavigateTo("/");
            }
        }




    }
}