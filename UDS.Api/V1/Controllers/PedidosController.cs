using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UDS.Api.Controllers;
using UDS.Business.DTOs;
using UDS.Business.Interfaces;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Interfaces.Services;

namespace UDS.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/pedidos")]
    public class PedidosController : MainController
    {
        private readonly IPedidosService _fService;
        public PedidosController(IPedidosService fService, INotificador notificador, IUser user) : base(notificador, user)
        {
            _fService = fService;
        }
        [HttpPost]
        public async Task<ActionResult<DTOPedidosResultado>> AdicionarPedido(DTOPedidos pedido)
        {
            var t = await _fService.Adicionar(pedido);
            return CustomResponse(t);
        }
        [HttpGet]
        public async Task<ActionResult<List<DTOPedidosResultado>>> ListarTodos()
        {
            var t = await _fService.ListarTodos();
            return CustomResponse(t);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DTOPedidosResultado>> ObterPorId(int id)
        {
            var t = await _fService.ObterPorId(id);
            return CustomResponse(t);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> Excluir(int id)
        {
            var t = await _fService.Excluir(id);
            return CustomResponse(t);
        }
    }
}