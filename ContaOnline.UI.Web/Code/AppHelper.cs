using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using Microsoft.AspNetCore.Http;
using System.Drawing.Printing;
using System.Security.Claims;
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

        public static ContaRepository ObterContaRepository()
        {
            return new ContaRepository();
        }

        public static ContatoRepository ObterContatoRepository()
        {
            return new ContatoRepository();
        }

        public static ContaCategoriaRepository ObterContaCategoriaRepository()
        {
            return new ContaCategoriaRepository();
        }

        public static ContaCorrenteRepository ObterContaCorrenteRepository()
        {
            return new ContaCorrenteRepository();
        }

        public static Usuario? ObterUsuarioLogado(ClaimsPrincipal principal)
        {
            // Busca cada informação pela sua respectiva Claim
            var id = principal.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = principal.FindFirstValue(ClaimTypes.Email);
            var nome = principal.FindFirstValue(ClaimTypes.Name);

            // Se não houver ID ou Email, consideramos que não há usuário válido
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return new Usuario
            {
                Id = id,
                Email = email,
                Nome = nome
            };
        }

        public static UsuarioRepository ObterUsuarioRepository()
        {
            return new UsuarioRepository();
        }
    }
}