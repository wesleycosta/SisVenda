using System.Linq;
using System.Collections.Generic;

namespace ProjetoPrima.RepositorioEF
{
    using Dominio;

    public class VendaRepositorioEF
    {
        private readonly ContextoDB contexto = new ContextoDB();

        #region VENDA

        public void Salvar(Venda venda)
        {
            if (venda?.Id > 0)
            {
                var vendaItem = contexto.Vendas.FirstOrDefault(x => x.Id == venda.Id);

                vendaItem.NumeroDoPedido = venda.NumeroDoPedido;
                vendaItem.Cliente = venda.Cliente;
                vendaItem.Data = venda.Data;
                vendaItem.ValorTotal = venda.ValorTotal;
            }
            else
                contexto.Vendas.Add(venda);

            contexto.SaveChanges();
        }

        public void Remover(Venda venda)
        {
            var vendaItem = contexto.Vendas.FirstOrDefault(x => x.Id == venda.Id);
            vendaItem.Ativo = false;

            contexto.VendaItens.Where(x => x.Venda.Id == venda.Id).ToList().
                                ForEach(x => x.Ativo = false);

            contexto.SaveChanges();
        }

        public Venda CarregarPorId(int id) =>
             contexto.Vendas.FirstOrDefault(x => x.Id == id);

        public List<Venda> CarregarTodos() =>
             contexto.Vendas.Where(x => x.Ativo).ToList();

        #endregion

        #region VENDA ITEM

        public void Salvar(VendaItem vendaItem)
        {
            if (vendaItem.Id > 0)
            {
                var itemVenda = contexto.VendaItens.FirstOrDefault(x => x.Id == vendaItem.Id);

                itemVenda.Produto = vendaItem.Produto;
                itemVenda.Quantidade = vendaItem.Quantidade;
                itemVenda.ValorUnitario = vendaItem.ValorUnitario;
            }
            else
                contexto.VendaItens.Add(vendaItem);

            contexto.SaveChanges();
        }

        public void Remover(VendaItem vendaItem)
        {
            var itemVenda = contexto.Clientes.FirstOrDefault(x => x.Id == vendaItem.Id);
            itemVenda.Ativo = false;

            contexto.SaveChanges();
        }

        public VendaItem CarregarVendaItemPorId(int id) =>
             contexto.VendaItens.FirstOrDefault(x => x.Id == id);

        public List<VendaItem> CarregarTodosVendaItem() =>
             contexto.VendaItens.Where(x => x.Ativo).ToList();

        public List<VendaItem> CarregarVendaItemPorIdVenda(int id) =>
          contexto.VendaItens.Where(x => x.Venda.Id == id).ToList();

        #endregion

        #region CLIENTE
        public Cliente CarregarCliente(int id) =>
          contexto.Clientes.FirstOrDefault(x => x.Id == id);

        #endregion
    }
}
