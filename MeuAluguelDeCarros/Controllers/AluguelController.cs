using MeuAluguelDeCarros.Models.Entities;
using MeuAluguelDeCarros.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeuAluguelDeCarros.Controllers
{
    public class AluguelController : Controller
    {
        // GET: Aluguel
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Novo(Aluguel aluguel)
        {
            var service = new AluguelService();
            var serviceCarro = new CarroController();
            var carro = new Carro();           
            var carroAlugado = service.ListarCarroAlugado(aluguel);
            carro = (Carro)carroAlugado;


            carro.IsAlugado = true;
            serviceCarro.Novo(carro);

            try
            {
                service.Cadastrar(new Aluguel
                {
                    NomeDoContratante = aluguel.NomeDoContratante,
                    PlacaDoVeiculo = aluguel.PlacaDoVeiculo,
                    IdCarro = carro.Id
                });

            }
            catch (Exception)
            {
                throw;
            }

        

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Devolver(string data)
        {
            var service = new AluguelService();
            var serviceCarro = new CarroController();
            var aluguelListado = service.ListarAluguel(data);
            var carro = new Carro();
            var aluguel = new Aluguel();
            aluguel = (Aluguel)aluguelListado;

            var carroAlugado = service.ListarCarroAlugado(aluguel);

            carro = (Carro)carroAlugado;

            carro.IsAlugado = false;

            serviceCarro.Novo(carro);

            service.ExcluirAluguel(data);

            return RedirectToAction("Index");
        }
    }
}