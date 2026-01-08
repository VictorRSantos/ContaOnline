namespace ContaOnline.Domain.Models
{
    public class Pessoa : Contato
    {
        public string CPF { get; set; } = string.Empty;
        public string RG { get; set; } = string.Empty;
        public DateTime? DataNascimento { get; set; }
    }
}