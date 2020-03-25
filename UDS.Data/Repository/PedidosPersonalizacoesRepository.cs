using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Model;
using UDS.Data.Context;

namespace UDS.Data.Repository
{
    public class PedidosPersonalizacoesRepository : Repository<PedidosPersonalizacoes>, IPedidosPersonalizacoesRepository
    {
        public PedidosPersonalizacoesRepository(ApiDbContext context) : base(context)
        {

        }
    }
}
