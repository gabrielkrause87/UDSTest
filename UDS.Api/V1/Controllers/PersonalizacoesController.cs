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
    [Route("api/v{version:apiVersion}/personalizacoes")]
    public class PersonalizacoesController : MainController
    {
        private readonly IPersonalizacoesRepository _fRepository;
        private readonly IPersonalizacoesService _fService;
        public PersonalizacoesController(IPersonalizacoesRepository fRepository, IPersonalizacoesService fService, INotificador notificador, IUser user) : base(notificador, user)
        {
            _fRepository = fRepository;
            _fService = fService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DTOPersonalizacoes>>> ListarTodos()
        {
            var t = await _fService.ListarTodos();
            return CustomResponse(t);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<DTOPersonalizacoes>> ObterPorId(int id)
        {
            var t = await _fService.ObterPorId(id);
            return CustomResponse(t);
        }
        [HttpPost]
        public async Task<ActionResult<DTOPersonalizacoes>> Adicionar(DTOPersonalizacoes personalizacoes)
        {
            var t = await _fService.Adicionar(personalizacoes);
            return CustomResponse(t);
        }
        [HttpPut]
        public async Task<ActionResult<DTOPersonalizacoes>>Atualizar(DTOPersonalizacoes personalizacoes)
        {
            var t = await _fService.Atualizar(personalizacoes);
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