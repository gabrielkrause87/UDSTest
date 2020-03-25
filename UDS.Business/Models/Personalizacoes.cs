using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UDS.Business.Models;

namespace UDS.Business.Model
{
    public class Personalizacoes : Entity
    {
        [MaxLength(100)]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public int TempoPreparo { get; set; }
        public bool Ativo { get; set; }
        public PedidosPersonalizacoes PedidosPersonalizacoes { get; set; }
    }
}
