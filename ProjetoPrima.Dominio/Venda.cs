using System;
using System.Collections.Generic;

namespace ProjetoPrima.Dominio
{
    public class Venda
    {
        public int Id { get; set; }
        public string NumeroDoPedido { get; set; }
        public virtual Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
