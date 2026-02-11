using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaController : Controller
    {
        private IContaRepository _contaRepository;
        private Usuario _usuario;

        public ContaController()
        {
            _contaRepository = AppHelper.ObterContaRepository();
            
        }
        public IActionResult Inicio()
        {
            _usuario = AppHelper.ObterUsuarioLogado(User);
            if (_usuario == null)
            {
                return  RedirectToAction("Login","App");
            }

            var lista = _contaRepository.ObterPorUsuario(_usuario.Id);
            return View(lista);
        }
    }
}
