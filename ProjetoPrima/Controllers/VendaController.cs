using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

namespace ProjetoPrima.Controllers
{
    using Dominio;
    using RepositorioEF;

    public class VendaController : Controller
    {
        public ActionResult Index()
        {
            TempData.Remove("Carrinho");

            return View(new VendaRepositorioEF().CarregarTodos());
        }

        #region CADASTRAR

        public ActionResult Cadastrar()
        {
            TempData.Keep("Carrinho");

            ViewBag.ClienteId = new SelectList
            (
                new ClienteRepositorioEF().CarregarTodos(),
                "Id",
                "Nome"
            );

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(string submit)
        {
            if (submit == "Adicionar")
            {
                TempData.Keep("Carrinho");
                MantemCarrinho();
                CarregarClienteSelecionado();
            }
            else if (submit.Contains("Remover"))
            {
                MantemRemoverCarrinho(submit);
                CarregarClienteSelecionado();
            }
            else if (submit == "Gravar")
            {
                MantemVenda();
                return RedirectToAction("Index");
            }

            return View();
        }

        #endregion

        #region VENDA

        private void MantemVenda()
        {
            var repositorioVenda = new VendaRepositorioEF();
            var cliente = repositorioVenda.CarregarCliente(int.Parse(Request.Params["ClienteId"]));
            var listaCarrinho = GetCarrinho();

            var venda = new Venda
            {
                Cliente = cliente,
                Data = DateTime.Now,
                NumeroDoPedido = Request?.Params["NumeroDoPedido"],
                ValorTotal = listaCarrinho.Sum(x => x.ValorTotal),
                Ativo = true
            };

            listaCarrinho.ForEach(x => x.Id = 0);

            repositorioVenda.Salvar(venda);
            listaCarrinho.ForEach(x => x.Venda = venda);
            listaCarrinho.ForEach(x => repositorioVenda.Salvar(x));
        }

        private List<VendaItem> GetCarrinho()
        {
            if (TempData["Carrinho"] != null)
                return TempData["Carrinho"] as List<VendaItem>;

            return new List<VendaItem>();
        }

        private void CarregarClienteSelecionado()
        {
            ViewBag.ClienteId = new SelectList
                                (
                                    new ClienteRepositorioEF().CarregarTodos(),
                                    "Id",
                                    "Nome",
                                    Request.Params["ClienteId"]
                                );
        }

        #endregion

        #region CARRINHO

        private void MantemCarrinho()
        {
            var vendaItem = GetVendaItem();

            if (vendaItem != null)
                AdicionarAoCarrinho(vendaItem);
        }

        private void MantemRemoverCarrinho(string submit)
        {
            var id = int.Parse(submit.Split(';')[1]);
            RemoverCarrinho(id);
        }

        private void AdicionarAoCarrinho(VendaItem vendaItem)
        {
            if (TempData["Carrinho"] != null)
            {
                var carrinho = TempData["Carrinho"] as List<VendaItem>;
                vendaItem.Id = carrinho.Count + 1;
                carrinho.Add(vendaItem);
                TempData["Carrinho"] = carrinho;
            }
            else
                TempData["Carrinho"] = new List<VendaItem>
                {
                    vendaItem
                };
        }

        private void RemoverCarrinho(int id)
        {
            if (TempData["Carrinho"] != null)
            {
                var carrinho = TempData["Carrinho"] as List<VendaItem>;
                var prod = carrinho.FirstOrDefault(x => x.Id == id);
                carrinho.Remove(prod);

                TempData["Carrinho"] = carrinho;
            }
        }

        private VendaItem GetVendaItem()
        {
            decimal valorUnitario = 0;
            if (decimal.TryParse(Request.Params["ValorUnitario"], out valorUnitario))
                return new VendaItem
                {
                    Produto = Request.Params["Produto"],
                    Quantidade = int.Parse(Request.Params["Quantidade"]),
                    ValorUnitario = valorUnitario
                };
            else
                return null;
        }

        #endregion

        #region REMOVER

        public ActionResult Remover(int id)
        {
            var repositorio = new VendaRepositorioEF();
            var venda = repositorio.CarregarPorId(id);

            if (venda == null)
                return HttpNotFound();

            return View(venda);
        }


        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmado(int id)
        {
            var repositorio = new VendaRepositorioEF();
            var venda = repositorio.CarregarPorId(id);
            repositorio.Remover(venda);

            return RedirectToAction("Index");
        }

        #endregion

        #region DETALHE

        public ActionResult Detalhe(int id)
        {
            var repositorio = new VendaRepositorioEF();
            var venda = repositorio.CarregarPorId(id);
            ViewData["VendaItem"] = repositorio.CarregarVendaItemPorIdVenda(id);

            return View(venda);
        }

        #endregion
    }
}