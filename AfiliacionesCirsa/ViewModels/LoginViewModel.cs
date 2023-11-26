using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface ILoginViewModel
    {
        bool showModal { get; set; }
        bool isBusy { get; set; }
        void OnInitialize();
        Task Login();
        string email { get; set; }
        string password { get; set; }

    }

    public class LoginViewModel : ILoginViewModel
    {
        public bool isBusy { get; set; } = false;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool showModal { get; set; } = false;

        private AuthService _authService;
        private readonly NavigationManager _navManager;
        public LoginViewModel(AuthService authService, NavigationManager navManager)
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
                _navManager.NavigateTo("/home");
            }
        }

        public async Task Login()
        {
            if (isAllowed())
            {
                isBusy = true;
                await _authService.Login(email, password);
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
                _navManager.NavigateTo("/home");
            }
        }




    }
}