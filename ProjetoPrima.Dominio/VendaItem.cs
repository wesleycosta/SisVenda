namespace ProjetoPrima.Dominio
{
    public class VendaItem
    {
        public int Id { get; set; }
        public string Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public bool Ativo { get; set; } = true;
        public decimal ValorTotal => ValorUnitario * Quantidade;

        public virtual Venda Venda { get; set; } 
    }
}
