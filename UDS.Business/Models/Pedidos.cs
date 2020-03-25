using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UDS.Business.Models;

namespace UDS.Business.Model
{
    public class Pedidos : Entity
    {
        public DateTime DtPedido { get; set; }
        public string Cliente { get; set; }
        public int TamanhosId { get; set; }
        public int SaboresId { get; set; }
        public Tamanhos Tamanhos { get; set; }
        public Sabores Sabores { get; set; }
        public decimal ValorTamanho { get; set; }
        public decimal ValorSabor { get; set; }
        public int TempoTamanho { get; set; }
        public int TempoSabor { get; set; }

        public ICollection<PedidosPersonalizacoes> PedidosPersonalizacoes { get; set; }
    }
}
