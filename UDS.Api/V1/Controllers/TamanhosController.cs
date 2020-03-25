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
    [Route("api/v{version:apiVersion}/tamanhos")]
    public class TamanhosController : MainController
    {
        private readonly ITamanhosService _fService;
        private readonly ITamanhosRepository _fRepository;

        public TamanhosController(ITamanhosService fService, ITamanhosRepository fRepository,
            INotificador notificador, IUser user) : base(notificador, user)
        {
            _fRepository = fRepository;
            _fService = fService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DTOTamanhos>>> ListarTodos()
        {
            var t = await _fService.ObterTodos();
            return CustomResponse(t);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DTOTamanhos>> ObterPorId(int id)
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
        [HttpPut]
        public async Task<ActionResult<DTOTamanhos>> Atualizar(DTOTamanhos tamanhos)
        {
            var t = await _fService.Atualizar(tamanhos);
            return CustomResponse(t);
        }
        [HttpPost]
        public async Task<ActionResult<DTOTamanhos>> Adicionar(DTOTamanhos tamanhos)
        {
            var t = await _fService.Adicionar(tamanhos);
            return CustomResponse(t);
        }
    }
}