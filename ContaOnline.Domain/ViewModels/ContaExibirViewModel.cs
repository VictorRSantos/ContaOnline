using ContaOnline.Domain.Models;

namespace ContaOnline.Domain.ViewModels
{
    public class ContaExibirViewModel : Conta
    {
        public string ContaCorrenteDescricao { get; set; }
        public string CategoriaNome { get; set; }
        public string ContatoNome { get; set; }
    }
}
