using MeuAluguelDeCarros.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MeuAluguelDeCarros.Models.Data
{
    public class CarroData
    {
        internal void Cadastrar(Carro carro)
        {
            using (var ctx = new BancoContext())
            {
                ctx.Carros.Add(carro);
                ctx.SaveChanges();
            }
        }

        internal List<Carro> ListarTodosCarros()
        {
            using (var ctx = new BancoContext())
            {
                return ctx.Carros.ToList();
            }
        }

        internal void Excluir(int id)
        {
            using (var ctx = new BancoContext())
            {
                var carro = ctx.Carros.Single(x => x.Id == id);
                ctx.Carros.Remove(carro);
                ctx.SaveChanges();
            }
        }

        internal void Editar(Carro carro)
        {
            using (var ctx = new BancoContext())
            {
                ctx.Carros.AddOrUpdate(carro);
                ctx.SaveChanges();
            }
        }
    }
}