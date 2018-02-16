using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MeuAluguelDeCarros.Models.Entities
{
    [Table("Aluguel")]
    public class Aluguel
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NomeDoContratante")]
        public string NomeDoContratante { get; set; }

        [Column("PlacaDoVeiculo")]
        public string PlacaDoVeiculo { get; set; }

        [Column("IdCarro")]
        public int IdCarro { get; set; }

    }
}