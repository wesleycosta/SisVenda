using System.Web.Mvc;

namespace ProjetoPrima.Controllers
{
    using Dominio;
    using RepositorioEF;

    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            var repositorio = new ClienteRepositorioEF();

            return View(repositorio.CarregarTodos());
        }

        #region CADASTRAR

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var repositorio = new ClienteRepositorioEF();
                repositorio.Salvar(cliente);

                return RedirectToAction("Index");
            }
            else
                return View(cliente);
        }

        #endregion

        #region EDITAR

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var repositorio = new ClienteRepositorioEF();
                repositorio.Salvar(cliente);

                return RedirectToAction("Index", true);
            }
            else
                return EditarCliente(cliente);
        }

        [HttpGet, ActionName("Editar")]
        public ActionResult EditarCliente(Cliente cliente)
        {
            var repositorio = new ClienteRepositorioEF();
            var c = repositorio.CarregarPorId(cliente.Id);
            cliente = c;

            return View(cliente);
        }

        #endregion

        #region REMOVER

        public ActionResult Remover(int id)
        {
            var repositorio = new ClienteRepositorioEF();
            var cliente = repositorio.CarregarPorId(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmado(int id)
        {
            var repositorio = new ClienteRepositorioEF();
            var cliente = repositorio.CarregarPorId(id);
            repositorio.Remover(cliente);

            return RedirectToAction("Index");
        }

        #endregion
    }
}