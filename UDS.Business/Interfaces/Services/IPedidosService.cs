using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.DTOs;

namespace UDS.Business.Interfaces.Services
{
    public interface IPedidosService
    {
        Task<DTOPedidosResultado> Adicionar(DTOPedidos pedido);
        Task<bool> Excluir(int id);
        Task<List<DTOPedidosResultado>> ListarTodos();
        Task<DTOPedidosResultado> ObterPorId(int id);
    }
}
