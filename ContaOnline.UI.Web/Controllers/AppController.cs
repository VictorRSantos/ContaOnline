using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Repository;
using ContaOnline.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

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

            AppHelper.RegistrarUsuario(HttpContext, usuario);

            return RedirectToAction("Inicio");
        }
        /// <summary>
        /// Tela Inicial do aplicativo.
        /// </summary>
        /// <returns></returns>
        public IActionResult Inicio()
        {           
            var usuario = AppHelper.ObterUsuarioLogado(HttpContext);
            if (usuario == null)
                return RedirectToAction("Login");

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

        [HttpPost]
        public IActionResult Registro(RegistroViewModel registro)
        {
            if (string.IsNullOrEmpty(registro.Email))
            {
                ModelState.AddModelError("Email", "O email deve ser informado");
            }

            if (string.IsNullOrEmpty(registro.Senha))
            {
                ModelState.AddModelError("Sennha", "A senha deve ser informado");
            }
            else
            {
                if (registro.Senha != registro.ConfirmarSenha)
                {
                    ModelState.AddModelError("ConfirmarSenha", "As senhas não coincidem.");
                }
            }

            if (ModelState.IsValid)
            {               

                var usuarioRepositorio = AppHelper.ObterUsuarioRepository();
                var novoUsuario = new Usuario
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = registro.Nome,
                    Email = registro.Email,
                    Senha = registro.Senha
                };

                usuarioRepositorio.Incluir(novoUsuario);
                AppHelper.RegistrarUsuario(HttpContext, novoUsuario);

                return RedirectToAction("Inicio");
            }


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
