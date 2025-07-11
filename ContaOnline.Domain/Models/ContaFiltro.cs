﻿namespace ContaOnline.Domain.Models
{
    public class ContaFiltro
    {
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public PagarReceber? Tipo { get; set; }
        public string ContaCategoriaId { get; set; }
        public string ContatoId { get; set; }
        public string UsuarioId { get; set; }
    }
}
