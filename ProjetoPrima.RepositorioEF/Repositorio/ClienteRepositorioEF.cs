using System.Linq;
using System.Collections.Generic;

namespace ProjetoPrima.RepositorioEF
{
    using Dominio;

    public class ClienteRepositorioEF
    {
        private readonly ContextoDB contexto = new ContextoDB();

        public void Salvar(Cliente cliente)
        {
            if (cliente?.Id > 0)
            {
                var clienteItem = contexto.Clientes.FirstOrDefault(x => x.Id == cliente.Id);

                clienteItem.Nome = cliente.Nome;
                clienteItem.CPF = cliente.CPF;
                clienteItem.DataNascimento = cliente.DataNascimento;
                clienteItem.Email = cliente.Email;
                clienteItem.Telefone = cliente.Telefone;
            }
            else
                contexto.Clientes.Add(cliente);

            contexto.SaveChanges();
        }

        public void Remover(Cliente cliente)
        {
            var clienteItem = contexto.Clientes.FirstOrDefault(x => x.Id == cliente.Id);
            clienteItem.Ativo = false;

            contexto.SaveChanges();
        }

        public Cliente CarregarPorId(int id) =>
             contexto.Clientes.FirstOrDefault(x => x.Id == id);

        public List<Cliente> CarregarTodos() =>
            contexto.Clientes.Where(x => x.Ativo).ToList();
    }
}
