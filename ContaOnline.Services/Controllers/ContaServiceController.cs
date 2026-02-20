using ContaOnline.Domain.Interfaces;
using ContaOnline.Domain.Models;
using ContaOnline.Domain.ViewModels;
using ContaOnline.Repository;
using ContaOnline.UI.Web;
using Microsoft.AspNetCore.Mvc;

namespace ContaOnline.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaServiceController : ControllerBase
    {
        private Usuario _usuario;
        private IContaRepository _contaRepository;

        public ContaServiceController()
        {
            _contaRepository = AppHelper.ObterContaRepository();
        }

        [HttpGet]
        public List<ContaListItem> Get()
        {
            var repositorio = new ContaRepository();
            ContaListViewModel viewModel = new ContaListViewModel();
            viewModel.Filtro.UsuarioId = "d818797e-abe1-42c5-927b-ef28fc291a39";
            viewModel.Filtro.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            viewModel.Filtro.DataFinal = DateTime.Now.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
            viewModel.ContaList = repositorio.ObterPorFiltro(viewModel.Filtro).ToList();            
            return viewModel.ContaList;

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
        //public List<ContaListItem> Get(string id)
        //{
        //    var lista = new List<ContaListItem>();
        //    lista.Add(new ContaListItem
        //    {
        //        Id = "1",
        //        Data = DateTime.Now,
        //        Tipo = PagarReceber.Pagar,
        //        Descricao = "Conta de Luz",
        //        Contato = "Eletropaulo",
        //        Categoria = "Casa",
        //        Valor = 150.00m,
        //        CategoriaId = "1",
        //        ContaCorrenteId = "1"
        //    });
        //    lista.Add(new ContaListItem
        //    {
        //        Id = "2",
        //        Data = DateTime.Now,
        //        Tipo = PagarReceber.Receber,
        //        Descricao = "Salário",
        //        Contato = "Empresa XYZ",
        //        Categoria = "Trabalho",
        //        Valor = 3000.00m,
        //        CategoriaId = "2",
        //        ContaCorrenteId = "1"
        //    });
        //    return lista.Where(x => x.Id == id).ToList();
        //}
    }
}
