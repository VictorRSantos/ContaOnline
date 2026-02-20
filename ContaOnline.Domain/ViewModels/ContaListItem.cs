using ContaOnline.Domain.Models;

namespace ContaOnline.Domain.ViewModels
{
    public class ContaListItem
    {
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public PagarReceber Tipo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Contato { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string CategoriaId { get; set; }
        public string ContaCorrenteId { get; set; }
    }
}
