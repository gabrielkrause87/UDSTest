using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Interfaces;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Interfaces.Services;

namespace UDS.Business.Services
{
    public class PedidosPersonalizacoesService : BaseService, IPedidosPersonalizacoesService
    {
        private readonly IPedidosPersonalizacoesRepository _pedidosPersonalizacoes;
        public PedidosPersonalizacoesService(IPedidosPersonalizacoesRepository pedidosPersonalizacoes, INotificador notificador) : base(notificador)
        {
            _pedidosPersonalizacoes = pedidosPersonalizacoes;
        }
    }
}
