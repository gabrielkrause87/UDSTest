using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.Model;

namespace UDS.Business.Interfaces.Repositories
{
    public interface IPedidosRepository : IRepository<Pedidos>
    {
        Task<List<Pedidos>> CarregarTodosCompleto();
        Task<Pedidos> CarregarPorIdCompleto(int id);
    }
}
