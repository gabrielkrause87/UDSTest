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
using UDS.Business.Model;

namespace UDS.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sabores")]
    public class SaboresController : MainController
    {
        private readonly ISaboresService _saboresService;
        private readonly ISaboresRepository _saboresRepository;

        public SaboresController(ISaboresService saboresService, ISaboresRepository saboresRepository,
            INotificador notificador, IUser user) : base(notificador, user)
        {
            _saboresRepository = saboresRepository;
            _saboresService = saboresService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DTOSabores>>> ListarSabores()
        {
            var t = await _saboresService.ObterTodos();
            return CustomResponse(t);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DTOSabores>> ListarSabor(int id)
        {
            var t = await _saboresService.ObterPorId(id);
            return CustomResponse(t);
        }
        [HttpPost]
        public async Task<ActionResult<DTOSabores>> AdicionarSabor(DTOSabores sabores)
        {
            var t = await _saboresService.Adicionar(sabores);
            return CustomResponse(t);
        }
        [HttpPut]
        public async Task<ActionResult<DTOSabores>> AtualizarSabor(DTOSabores sabores)
        {
            var t = await _saboresService.Atualizar(sabores);
            return CustomResponse(t);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> RemoverSabor(int id)
        {
            var t = await _saboresService.Excluir(id);
            return CustomResponse(t);
        }
    }
}