using System;

namespace ContaOnline.Domain.Models
{
    public class Pessoa : Contato
    {
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
