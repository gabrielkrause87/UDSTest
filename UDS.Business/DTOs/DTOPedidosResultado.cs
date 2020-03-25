using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Models;

namespace UDS.Business.DTOs
{
    public class DTOPedidosResultado : Entity
    {
        public DetalhesAcai Detalhes { get; set; }
        public ResumoAcai Resumo { get; set; }
    }
    public class DetalhesAcai
    {
        public DetalhesTamanho Tamanho { get; set; }
        public DetalhesSabor Sabor { get; set; }
        public List<DetalhesPersonalizacao> ListaPersonalizacoes { get; set; }
    }
    public class DetalhesTamanho
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TempoPreparo { get; set; }
        public decimal Valor { get; set; }
    }
    public class DetalhesSabor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TempoPreparo { get; set; }
        public decimal Valor { get; set; }
    }
    public class DetalhesPersonalizacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int TempoPreparo { get; set; }
        public decimal Valor { get; set; }
    }
    public class ResumoAcai
    {
        public TimeSpan TempoPreparo { get; set; }
        public decimal ValorTotal { get; set; }

    }
}
