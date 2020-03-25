using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Models;

namespace UDS.Business.DTOs
{
    public class DTOTamanhos : Entity
    {
        public string Descricao { get; set; }
        public decimal Volume { get; set; }
        public int TempoPreparo { get; set; }
        public decimal Valor { get; set; }
        public bool Ativo { get; set; }
    }
}
