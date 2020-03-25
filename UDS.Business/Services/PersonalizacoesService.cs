using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.DTOs;
using UDS.Business.Interfaces;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Interfaces.Services;
using UDS.Business.Model;

namespace UDS.Business.Services
{
    public class PersonalizacoesService : BaseService, IPersonalizacoesService
    {
        private readonly IPersonalizacoesRepository _personalizacoes;
        public PersonalizacoesService(IPersonalizacoesRepository personalizacoes, INotificador notificador) : base(notificador)
        {
            _personalizacoes = personalizacoes;
        }

        public async Task<DTOPersonalizacoes> Adicionar(DTOPersonalizacoes personalizacoes)
        {
            if (_personalizacoes.Buscar(p => p.Descricao == personalizacoes.Descricao).Result.Any())
            {
                Notificar("Personalizacao já existe.");
                return null;
            }
            var obj = new Personalizacoes
            {
                Ativo = personalizacoes.Ativo,
                Descricao = personalizacoes.Descricao,
                TempoPreparo = personalizacoes.TempoPreparo,
                Valor = personalizacoes.Valor
            };
            var t = await _personalizacoes.Adicionar(obj);
            personalizacoes.Id = t.Id;
            return personalizacoes;
        }

        public async Task<DTOPersonalizacoes> Atualizar(DTOPersonalizacoes personalizacoes)
        {
            if (!_personalizacoes.Buscar(p => p.Id == personalizacoes.Id).Result.Any())
            {
                Notificar("Personalizacão não localizada.");
                return null;
            }
            var obj = new Personalizacoes
            {
                Ativo = personalizacoes.Ativo,
                Descricao = personalizacoes.Descricao,
                TempoPreparo = personalizacoes.TempoPreparo,
                Valor = personalizacoes.Valor,
                Id = personalizacoes.Id
            };
            var t = await _personalizacoes.Atualizar(obj);
            return personalizacoes;
        }

        public async Task<bool> Excluir(int id)
        {
            if (!_personalizacoes.Buscar(p => p.Id == id).Result.Any())
            {
                Notificar("Personalizacão não localizada.");
                return false;
            }
            var t = await _personalizacoes.Remover(id);
            return t;
        }

        public async Task<List<DTOPersonalizacoes>> ListarTodos()
        {
            var lst = await _personalizacoes.ObterTodos();
            var lstRet = new List<DTOPersonalizacoes>();
            foreach (var t in lst)
            {
                var obj = new DTOPersonalizacoes
                {
                    Ativo = t.Ativo,
                    Descricao = t.Descricao,
                    Id = t.Id,
                    TempoPreparo = t.TempoPreparo,
                    Valor = t.Valor
                };
                lstRet.Add(obj);
            }
            return lstRet;
        }

        public async Task<DTOPersonalizacoes> ObterPorId(int id)
        {
            if (!_personalizacoes.Buscar(p => p.Id == id).Result.Any())
            {
                Notificar("Personalizacão não localizada.");
                return null;
            }
            var t = await _personalizacoes.ObterPorId(id);
            var obj = new DTOPersonalizacoes
            {
                Ativo = t.Ativo,
                Descricao = t.Descricao,
                Id = t.Id,
                TempoPreparo = t.TempoPreparo,
                Valor = t.Valor
            };
            return obj;
        }
    }
}
