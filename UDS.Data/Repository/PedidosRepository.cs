using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Model;
using UDS.Data.Context;

namespace UDS.Data.Repository
{
    public class PedidosRepository : Repository<Pedidos>, IPedidosRepository
    {
        private readonly ApiDbContext db;
        public PedidosRepository(ApiDbContext context) : base(context)
        {
            db = context;
        }

        public async Task<Pedidos> CarregarPorIdCompleto(int id)
        {
            return await db.Pedidos
                .Where(p => p.Id == id)
                .Include(p => p.PedidosPersonalizacoes).ThenInclude(x => x.Personalizacoes)
                .Include(p => p.Sabores)
                .Include(p => p.Tamanhos).FirstOrDefaultAsync();
        }

        public async Task<List<Pedidos>> CarregarTodosCompleto()
        {
            return await db.Pedidos
                .Include(p => p.PedidosPersonalizacoes).ThenInclude(x => x.Personalizacoes)
                .Include(p => p.Sabores)
                .Include(p => p.Tamanhos).ToListAsync();

        }
    }
}
