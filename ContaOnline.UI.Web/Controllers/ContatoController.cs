using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using NuGet.Protocol.Core.Types;

namespace ContaOnline.UI.Web.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepository _contatoRepository;
        private Usuario? _usuarioLogado;

        public ContatoController()
        {
            _contatoRepository = AppHelper.ObterContatoRepository();
        }
        // GET: ContatosController
        public ActionResult Inicio()
        {
            _usuarioLogado = ObterUsuarioLogado();
            if (_usuarioLogado == null) return RedirectToAction("Login", "App");
            var lista = _contatoRepository.ObterTodos(_usuarioLogado.Id);
            return View(lista);
        }


        // GET: ContatosController/Create
        public ActionResult Incluir()
        {
            var contato = new ContatoViewModel();
            return View(contato);
        }

        // POST: ContatosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(ContatoViewModel contatoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioLogado = ObterUsuarioLogado();
                    Contato contato = new Contato()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UsuarioId = _usuarioLogado?.Id,
                        Nome = contatoViewModel.Nome,
                        Email = contatoViewModel.Email,
                        Telefone = contatoViewModel.Telefone,
                        Tipo = contatoViewModel.Tipo,
                        RG = contatoViewModel.RG ?? string.Empty,
                        CPF = contatoViewModel.CPF ?? string.Empty,
                        DataNascimento = contatoViewModel.DataNascimento,
                        CNPJ = contatoViewModel.CNPJ ?? string.Empty
                    };

                    _contatoRepository.Incluir(contato);

                }
                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContatosController/Edit/5
        public ActionResult Alterar(string id)
        {
            var contato = _contatoRepository.ObterPorId(id);
            var contatoViewModel = new ContatoViewModel()
            {
                Id = contato.Id,
                Nome = contato.Nome,
                Email = contato.Email,
                Telefone = contato.Telefone,
                Tipo = contato.Tipo
            };

            if (contato is Empresa)
            {
                contatoViewModel.CNPJ = contato.CNPJ;
            }
            else
            {
                contatoViewModel.CPF = contato.CPF;
                contatoViewModel.RG = contato.RG;
                contatoViewModel.DataNascimento = contato.DataNascimento;
            }

            return View(contato);
        }

        // POST: ContatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(Contato contatoRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contatoRequest);
                }
                _contatoRepository.Alterar(contatoRequest);

                return RedirectToAction("Inicio");
            }
            catch
            {
                return View();
            }
        }

        // GET: ContatosController/Delete/5
        public ActionResult Excluir(string id)
        {
            var contato = _contatoRepository.ObterPorId(id);
            return View(contato);
        }

        // POST: ContatosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(string id, Contato contato)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(contato);
                }

                _contatoRepository.Excluir(id);
                
                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View(contato);
            }
        }

        private Usuario? ObterUsuarioLogado()
        {
            return AppHelper.ObterUsuarioLogado(User);
        }
    }
}
