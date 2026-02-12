using ContaOnline.Domain.Models;

namespace ContaOnline.Domain.ViewModels
{
    public class ContaViewModel
    {
        public ContaViewModel()
        {
            this.ContaCorrenteList = new List<ContaCorrente>();
            this.ContaCategoriaList = new List<ContaCategoria>();
            this.ContatoList = new List<Contato>();
            this.ContaInstancia = new Conta();

            this.ContaInstancia.DataVencimento = DateTime.Now;
            this.ContaInstancia.Tipo = PagarReceber.Pagar;
        }

        public Conta ContaInstancia { get; set; }
        public List<ContaCorrente> ContaCorrenteList { get; set; }
        public List<ContaCategoria> ContaCategoriaList { get; set; }
        public List<Contato> ContatoList { get; set; }

    }
}
