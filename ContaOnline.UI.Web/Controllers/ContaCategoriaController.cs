using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContaCategoriaController : Controller
    {
        private IContaCategoriaRepository repositorio;
        private Usuario usuario;

        public ContaCategoriaController()
        {
            repositorio = AppHelper.ObterContaCategoriaRepository();
        }

        // GET: ContaCategoriaController
        public ActionResult Inicio()
        {
            var usuario = AppHelper.ObterUsuarioLogado(User);
            if (usuario == null) return RedirectToAction("Login", "App");

            var lista = repositorio.ObterTodos(usuario.Id);
            return View(lista);
        }


        // GET: ContaCategoriaController/Create
        public ActionResult Incluir()
        {
            var contaCategoria = new ContaCategoria();
            return View(contaCategoria);
        }

        // POST: ContaCategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(ContaCategoria contaCategoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = AppHelper.ObterUsuarioLogado(User);
                    contaCategoria.Id = Guid.NewGuid().ToString();
                    contaCategoria.UsuarioId = usuario.Id;
                    contaCategoria.Nome = contaCategoria.Nome.Trim();
                    repositorio.Incluir(contaCategoria);
                }

                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContaCategoriaController/Edit/5
        public ActionResult Alterar(string id)
        {
            var contaCategoria = repositorio.ObterPorId(id);
            return View(contaCategoria);
        }

        // POST: ContaCategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(ContaCategoria contaCategoria, IFormCollection collection)
        {
            try
            {
                repositorio.Alterar(contaCategoria);
                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContaCategoriaController/Delete/5
        public ActionResult Excluir(string id)
        {
            var contaCategoria = repositorio.ObterPorId(id);
            return View(contaCategoria);
        }

        // POST: ContaCategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(string id, IFormCollection collection)
        {
            try
            {
                repositorio.Excluir(id);
                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View();
            }
        }
    }
}
