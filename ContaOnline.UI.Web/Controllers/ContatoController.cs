using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.UI.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

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

                    //if (contatoViewModel.Tipo == PessoaFisicaJuridica.PessoaFisica)
                    //{
                    //    contato = new Pessoa
                    //    {
                    //        RG = contatoViewModel.RG ?? string.Empty,
                    //        CPF = contatoViewModel.CPF ?? string.Empty,
                    //        DataNascimento = contatoViewModel.DataNascimento
                    //    };


                    //}
                    //else if (contatoViewModel.Tipo == PessoaFisicaJuridica.PessoaJuridica)
                    //{
                    //    contato = new Empresa
                    //    {
                    //        CNPJ = contatoViewModel.CNPJ ?? string.Empty
                    //    };
                    //}

                    //_usuarioLogado = ObterUsuarioLogado();
                    //contato.Id = Guid.NewGuid().ToString();
                    //contato.UsuarioId = _usuarioLogado?.Id;
                    //contato.Nome = contatoViewModel.Nome;
                    //contato.Email = contatoViewModel.Email;
                    //contato.Telefone = contatoViewModel.Telefone;
                    //contato.Tipo = contatoViewModel.Tipo;

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
        public ActionResult Alterar(int id)
        {
            return View();
        }

        // POST: ContatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Alterar(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View();
            }
        }

        // GET: ContatosController/Delete/5
        public ActionResult Excluir(int id)
        {
            return View();
        }

        // POST: ContatosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Excluir(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Inicio));
            }
            catch
            {
                return View();
            }
        }

        private Usuario? ObterUsuarioLogado()
        {
            return AppHelper.ObterUsuarioLogado(User);
        }
    }
}
