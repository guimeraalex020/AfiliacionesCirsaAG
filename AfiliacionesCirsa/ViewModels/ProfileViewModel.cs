using AfiliacionesCirsa.Models;
using AfiliacionesCirsa.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace AfiliacionesCirsa.ViewModels 
{ 

    public interface IProfileViewModel
    {
        bool isBusy { get; set; }
        Task OnInitialize();
        UsuarioAfiliador my_user {  get; set; }


    }

    public class ProfileViewModel : IProfileViewModel
    {
        public bool isBusy { get; set; } = false;
        public UsuarioAfiliador my_user { get; set; } = new UsuarioAfiliador();

        private AuthService _authService;
        private readonly NavigationManager _navManager;
        private UsuarioAfiliadorService _usuarioAfiliadorService;
        public ProfileViewModel(AuthService authService, NavigationManager navManager, UsuarioAfiliadorService usuarioAfiliadorService)
        {
            _navManager = navManager;
            _authService = authService;
            _usuarioAfiliadorService = usuarioAfiliadorService;
        }

        public async Task OnInitialize()
        {
            await getUserProfile();
        }

        public async Task getUserProfile()
        {
            if (_authService.user_id.HasValue)
            {
                int current_user_id = _authService.user_id.Value;
                my_user = await _usuarioAfiliadorService.GetUserByIdAsync(current_user_id);
            }
            else
            {
                throw new NullReferenceException("User id on auth service is null");
            }
        }








    }
}