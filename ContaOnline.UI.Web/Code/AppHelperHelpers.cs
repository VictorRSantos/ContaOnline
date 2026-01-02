using ContaOnline.Domain.Models;

namespace ContaOnline.UI.Web
{
    internal static class AppHelperHelpers
    {

        public static Usuario? ObterUsuarioLogado(HttpContext httpContext = null)
        {
            var usuario = httpContext.Session.GetString("usuario");
            if (string.IsNullOrEmpty(usuario))
            {
                return null;
            }

            return new Usuario { Email = usuario };
        }
    }
}