using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using ContaOnline.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class AppController : Controller
    {
       
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View(loginViewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            IUsuarioRepository repositorio = AppHelper.ObterUsuarioRepository();
            Usuario usuario = repositorio.ObterPorEmailSenha(loginViewModel.Email, loginViewModel.Senha);

            if (usuario == null)
            {
                loginViewModel.Mensagem = "Usuário ou senha inválidos.";
                return View(loginViewModel);
            }

            AppHelper.RegistrarUsuario(usuario);

            return RedirectToAction("Inicio");
        }
        /// <summary>
        /// Tela Inicial do aplicativo.
        /// </summary>
        /// <returns></returns>
        public IActionResult Inicio()
        {

            return View();
        }

        /// <summary>
        /// Registro de usuário.
        /// </summary>
        /// <returns></returns>
        public IActionResult Registro()
        {
            var registro = new RegistroViewModel();
            return View(registro);
        }

        /// <summary>
        /// Sobre o aplicativo.
        /// </summary>
        /// <returns></returns>
        public IActionResult Sobre()
        {
            return View();
        }
    }
}
