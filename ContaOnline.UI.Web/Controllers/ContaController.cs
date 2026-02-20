using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;
using ContaOnline.UI.Web.Models;
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

            var viewModel = new ContaListViewModel();
            viewModel.Filtro.UsuarioId = _usuario.Id;
            viewModel.ContaList = _contaRepository.ObterPorUsuario(_usuario.Id).ToList();
            PreencherContaListViewModel(viewModel);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Inicio(ContaListViewModel viewModel)
        {
            _usuario = AppHelper.ObterUsuarioLogado(User);

            if (_usuario == null) return RedirectToAction("Login", "App");

            viewModel.Filtro.UsuarioId = _usuario.Id;
            viewModel.ContaList = _contaRepository.ObterPorFiltro(viewModel.Filtro).ToList();

            PreencherContaListViewModel(viewModel);

            return View(viewModel);
        }

        private void PreencherContaListViewModel(ContaListViewModel viewModel)
        {
            var catRep = AppHelper.ObterContaCategoriaRepository();
            viewModel.CategoriaList = catRep.ObterTodos(_usuario.Id).ToList();

            var contaCorrenteRep = AppHelper.ObterContaCorrenteRepository();
            contaCorrenteRep.ObterTodos(_usuario.Id).ToList();

            viewModel.CategoriaList.Insert(0, new ContaCategoria { Id = string.Empty, Nome = string.Empty });
            viewModel.ContaCorrenteList.Insert(0, new ContaCorrente { Id = string.Empty, Descricao = string.Empty });
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
                viewModel.ContaInstancia.Id = Guid.NewGuid().ToString();
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

        public IActionResult Excluir(string id)
        {
            _usuario = AppHelper.ObterUsuarioLogado(User);
            if (_usuario == null) return RedirectToAction("Login", "App");
            try
            {
                var conta = _contaRepository.ObterExibirPorId(id);
                return View(conta);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao excluir a conta. Tente novamente.");
            }
            return RedirectToAction("Inicio");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(string id, IFormCollection collection)
        {
            try
            {
                _contaRepository.Excluir(id);
                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View();
            }
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
