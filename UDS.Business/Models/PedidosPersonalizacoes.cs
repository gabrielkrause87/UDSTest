using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UDS.Business.Models;

namespace UDS.Business.Model
{
    public class PedidosPersonalizacoes : Entity
    {
        public Pedidos Pedidos { get; set; }
        public int PedidosId { get; set; }
        public Personalizacoes Personalizacoes { get; set; }
        public int PersonalizacoesId { get; set; }
        public decimal ValorPersonalizacao { get; set; }
        public int TempoPersonalizacao { get; set; }
    }
}
