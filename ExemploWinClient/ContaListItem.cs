using System;

namespace ExemploWinClient
{
    public enum PagarReceber
    {
        Pagar = 1,
        Receber = 2
    }

    public class ContaListItem
    {        
        public DateTime Data { get; set; }
        public PagarReceber Tipo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Contato { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Valor { get; set; }        
    }
}
