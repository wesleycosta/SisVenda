using System;

namespace ProjetoPrima.Teste
{
    using Dominio;
    using RepositorioEF;

    class Program
    {
        public static Venda GetVenda()
        {
            var rVenda = new VendaRepositorioEF();
            var v = rVenda.CarregarPorId(1);

            Console.WriteLine(v?.NumeroDoPedido);
            Console.WriteLine(v?.Cliente.Nome);

            return v;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("APP INICIADO");
            Console.WriteLine();

            try
            {
                //var contexto = new VendaRepositorioEF();

                //var v = contexto.CarregarPorId(1);

                //for (int i = 0; i < 2; i++)
                //{
                //    var venItem = new VendaItem
                //    {
                //        Venda = v,
                //        Produto = "CHOCOLATE " + (i + 1),
                //        Quantidade = 1,
                //        ValorUnitario = 5,
                //        Ativo = true
                //    };

                //    contexto.Salvar(venItem);

                //    Console.WriteLine(venItem.Id.ToString());
                //}

                //Console.WriteLine(v.Id.ToString());


                //var ctx = new ClienteRepositorioEF();

                //var cli = new Cliente
                //{
                //    Nome = "ANA",
                //    Ativo = true,
                //    DataNascimento = DateTime.Now,
                //    Email = "ADASD",
                //    Telefone = "12 993123",
                //    CPF = "123",
                //};

                //ctx.Salvar(cli);

                //Console.WriteLine(cli.Id + "");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            Console.WriteLine();
        }
    }
}
