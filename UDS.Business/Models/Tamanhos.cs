using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UDS.Business.Models;

namespace UDS.Business.Model
{
    public class Tamanhos : Entity
    {
        [MaxLength(100)]
        public string Descricao { get; set; }
        public decimal Volume { get; set; }
        public int TempoPreparo { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }

        public List<Pedidos> Pedidos { get; set; }
    }
}
