using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using Microsoft.AspNetCore.Http;
namespace ContaOnline.UI.Web
{
    public static class AppHelper
    {

        private static IHttpContextAccessor? _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }      

        public static void RegistrarUsuario(Usuario usuario)
        {
            _httpContextAccessor?.HttpContext?.Session.SetString("usuario", usuario.Email);            
        }

        public static Usuario? ObterUsuarioLogado()
        {
            return (Usuario)_httpContextAccessor?.HttpContext?.Session.GetString("usuario");
        }

        public static UsuarioRepository ObterUsuarioRepository()
        {
            return new UsuarioRepository();
        }
    }
}