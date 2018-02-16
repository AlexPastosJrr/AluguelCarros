using MeuAluguelDeCarros.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeuAluguelDeCarros.Models.Data
{
    public class AluguelData
    {
        internal void Cadastrar(Aluguel aluguel)
        {
            using (var ctx = new BancoContext())
            {
                ctx.Aluguel.Add(aluguel);
                ctx.SaveChanges();
            }
        }

        internal object ListarCarroAlugado(string PlacaDoVeiculo)
        {
            using (var ctx = new BancoContext())
            {
               return ctx.Carros.Where(x => x.PlacaDoVeiculo == PlacaDoVeiculo).Single();
            }
        }

        internal object ListarAluguel(string data)
        {
            using (var ctx = new BancoContext())
            {
                return ctx.Aluguel.Where(x => x.PlacaDoVeiculo == data).Single();
            }
        }

        internal void Excluir(string data)
        {
            using (var ctx = new BancoContext())
            {
                var aluguel = ctx.Aluguel.Single(x => x.PlacaDoVeiculo == data);
                ctx.Aluguel.Remove(aluguel);
                ctx.SaveChanges();
            }
        }
    }
}