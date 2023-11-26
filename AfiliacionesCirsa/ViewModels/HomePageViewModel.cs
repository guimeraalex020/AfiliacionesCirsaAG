using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface IHomePageViewModel
    {
        bool isBusy { get; set; }
        void OnInitialize();
        void goRegister();
        void goLogin();

    }

    public class HomePageViewModel : IHomePageViewModel
    {
        public bool isBusy { get; set; } = false;

        private AuthService _authService;
        private readonly NavigationManager _navManager;
        public HomePageViewModel(AuthService authService, NavigationManager navManager)
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
                _navManager.NavigateTo("/fetchdata");
            }
        }

        public void goRegister()
        {
            _navManager.NavigateTo("/register");
        }
        public void goLogin()
        {
            _navManager.NavigateTo("/login");
        }







    }
}