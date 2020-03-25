using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Models;

namespace UDS.Business.DTOs
{
    public class DTOPedidos : Entity
    {
        public int Tamanho { get; set; }
        public int Sabor { get; set; }
        public List<int> Personalizacoes { get; set; }
    }
}
