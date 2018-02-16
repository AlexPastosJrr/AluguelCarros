using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuAluguelDeCarros.Models.Entities
{
    [Table("Carro")]
    public class Carro
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Descricao")]
        public string Descricao { get; set; }
        [Column("Cor")]
        public string Cor { get; set; }
        [Column("Combustivel")]
        public int Combustivel { get; set; }
        [Column("Ano")]
        public string Ano { get; set; }
        [Column("Marca")]
        public string Marca { get; set; }
        [Column("IsAlugado")]
        public bool IsAlugado { get; set; }
        [Column("PlacaDoVeiculo")]
        public string PlacaDoVeiculo { get; set; }
    }
}