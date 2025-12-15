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

        public static void RegistrarUsuario(HttpContext httpContext, Usuario usuario)
        {
            httpContext.Session.SetString("usuario", usuario.Email);
        }

        public static Usuario? ObterUsuarioLogado(HttpContext httpContext)
        {
            var usuario = httpContext.Session.GetString("usuario");
            if (string.IsNullOrEmpty(usuario))
            {
                return null;
            }
            
            return new Usuario { Email = usuario };
        }

        public static UsuarioRepository ObterUsuarioRepository()
        {
            return new UsuarioRepository();
        }
    }
}