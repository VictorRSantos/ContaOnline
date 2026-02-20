using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaCorrenteController : Controller
    {
        private IContaCorrenteRepository repositorio;

        public ContaCorrenteController()
        {
            repositorio = AppHelper.ObterContaCorrenteRepository();
        }

        [HttpPost]
        public IActionResult Excluir(string id, IFormCollection form)
        {
            repositorio.Excluir(id);
            return RedirectToAction("Inicio");
        }

        public IActionResult Excluir(string id)
        {
            var contaCorrente = repositorio.ObterPorId(id);
            return View(contaCorrente);
        }

        [HttpPost]
        public IActionResult Alterar(ContaCorrente contaCorrente)
        {
            if (string.IsNullOrWhiteSpace(contaCorrente.Descricao))
            {
                ModelState.AddModelError("Descricao", "A descrição é obrigatória.");
            }
            if (!ModelState.IsValid)
            {
                return View(contaCorrente);
            }
            repositorio.Alterar(contaCorrente);
            return RedirectToAction("Inicio");
        }

        public IActionResult Alterar(string id)
        {
            var contaCorrente = repositorio.ObterPorId(id);

            return View(contaCorrente);
        }

        [HttpPost]
        public IActionResult Incluir(ContaCorrente contaCorrente)
        {


            if (string.IsNullOrWhiteSpace(contaCorrente.Descricao))
            {
                ModelState.AddModelError("Descricao", "A descrição é obrigatória.");
            }


            if (!ModelState.IsValid)
            {
                var usuario = AppHelper.ObterUsuarioLogado(User);
                if (usuario == null) return RedirectToAction("Login", "App");
                contaCorrente.Id = Guid.NewGuid().ToString();
                contaCorrente.UsuarioId = usuario.Id;

                repositorio.Incluir(contaCorrente);
                return RedirectToAction("Inicio");
            }

            return View(contaCorrente);
        }

        public IActionResult Incluir()
        {
            var contaCorrente = new ContaCorrente();

            return View(contaCorrente);
        }

        public IActionResult Inicio()
        {
            var usuario = AppHelper.ObterUsuarioLogado(User);
            if (usuario == null) return RedirectToAction("Login", "App");

            var lista = repositorio.ObterTodos(usuario.Id);
            return View(lista);
        }
    }
}
