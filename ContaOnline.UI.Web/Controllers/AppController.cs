using ContaOnline.UI.Web.Views;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class AppController : Controller
    {
        public ActionResult Login()
        {
            var loginViewModel = new LoginViewModel();
            return View();
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
            return View();
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
