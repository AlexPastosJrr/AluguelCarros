using MeuAluguelDeCarros.Models.Entities;
using MeuAluguelDeCarros.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace MeuAluguelDeCarros.Controllers
{
    public class CarroController : Controller
    {
        // GET: Carro
        public ActionResult Index()
        {
            var service = new CarroService();
            IEnumerable<Carro> todosCarros = service.ListarTodosCarros();


            return View(model: todosCarros);
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Carro carro)
        {
            var service = new CarroService();

            if (carro.Id == 0)
            {
                service.Cadastrar(carro);
            }
            else
            {
                service.Editar(carro);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            var service = new CarroService();
            service.Excluir(id);
            //TempData["MensagemDeSucesso"] = "Carro excluido com sucesso !!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Alterar(int id)
        {
            var service = new CarroService();
            var CarroAlterado = service.ListarCarro(id);
            return View(CarroAlterado);
        }

        [HttpPost]
        public ActionResult Alterar(int id, Carro carro)
        {
            carro.Id = id;
            return Novo(carro);
        }

        [WebMethod]
        public JsonResult ListarTodos()
        {
            var service = new CarroService();

            var todosCarros = service.ListarTodosCarros();
            return Json(new { data = todosCarros }, JsonRequestBehavior.AllowGet);
        }
    }
}