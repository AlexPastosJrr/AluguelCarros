using MeuAluguelDeCarros.Models.Data;
using MeuAluguelDeCarros.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuAluguelDeCarros.Models.Service
{
    public class CarroService
    {
        internal void Cadastrar(Carro carro)
        {
            var data = new CarroData();
            data.Cadastrar(carro);
        }

        internal List<Carro> ListarTodosCarros()
        {
            var data = new CarroData();
            var teste = new Carro();

            var carros = data.ListarTodosCarros();

            return carros;
                             
        }

        internal void Excluir(int id)
        {
            var data = new CarroData();
            data.Excluir(id);
        }

        internal void Editar(Carro carro)
        {
            var data = new CarroData();
            data.Editar(carro);
        }

        internal object ListarCarro(int id)
        {
            var data = new CarroData();
            var carros = data.ListarTodosCarros();
            return carros.Where(x => x.Id == id).Single();

        }
    }
}