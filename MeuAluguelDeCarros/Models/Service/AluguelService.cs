using MeuAluguelDeCarros.Models.Data;
using MeuAluguelDeCarros.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuAluguelDeCarros.Models.Service
{
    public class AluguelService
    {
        internal void Cadastrar(Aluguel aluguel)
        {
            var data = new AluguelData();
            data.Cadastrar(aluguel);
        }

        internal object ListarCarroAlugado(Aluguel aluguel)
        {
            var data = new AluguelData();
            return data.ListarCarroAlugado(aluguel.PlacaDoVeiculo);

          
        }

        internal object ListarAluguel(string data)
        {
            var data1 = new AluguelData();
            return data1.ListarAluguel(data);
        }

        internal void ExcluirAluguel(string data)
        {
            var data1 = new AluguelData();
            data1.Excluir(data);
        }
    }
}