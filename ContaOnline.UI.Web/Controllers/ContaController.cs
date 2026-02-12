using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;
using ContaOnline.Repository;
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
                return RedirectToAction("Login", "App");
            }

            var lista = _contaRepository.ObterPorUsuario(_usuario.Id);
            return View(lista);
        }

        public IActionResult Incluir()
        {
            _usuario = AppHelper.ObterUsuarioLogado(User);
            if (_usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();

            PreencherViewModel(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Incluir(ContaViewModel viewModel)
        {
            _usuario = AppHelper.ObterUsuarioLogado(User);
            if (_usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = _usuario.Id;
                viewModel.ContaInstancia.Id =Guid.NewGuid().ToString();
                _contaRepository.Incluir(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao incluir a conta. Tente novamente.");
            }
            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        public IActionResult Alterar(string id)
        {
            _usuario = AppHelper.ObterUsuarioLogado(User);
            if (_usuario == null) return RedirectToAction("Login", "App");
            var viewModel = new ContaViewModel();
            viewModel.ContaInstancia = _contaRepository.ObterPorId(id);
            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Alterar(ContaViewModel viewModel)
        {
            _usuario = AppHelper.ObterUsuarioLogado(User);
            if (_usuario == null) return RedirectToAction("Login", "App");
            try
            {
                viewModel.ContaInstancia.UsuarioId = _usuario.Id;                
                _contaRepository.Alterar(viewModel.ContaInstancia);
                return RedirectToAction("Inicio");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao incluir a conta. Tente novamente.");
            }
            PreencherViewModel(viewModel);
            return View(viewModel);
        }

        private void PreencherViewModel(ContaViewModel viewModel)
        {
            var contaCorrenteRepository = AppHelper.ObterContaCorrenteRepository();
            viewModel.ContaCorrenteList = contaCorrenteRepository.ObterTodos(_usuario.Id).ToList();

            var contaCategoriaRepository = AppHelper.ObterContaCategoriaRepository();
            viewModel.ContaCategoriaList = contaCategoriaRepository.ObterTodos(_usuario.Id).ToList();

            var contatoRepository = AppHelper.ObterContatoRepository();
            viewModel.ContatoList = contatoRepository.ObterTodos(_usuario.Id).ToList();
        }
    }
}
