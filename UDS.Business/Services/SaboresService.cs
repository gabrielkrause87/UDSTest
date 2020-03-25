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
    public class SaboresService : BaseService, ISaboresService
    {
        private readonly ISaboresRepository _sabores;
        public SaboresService(ISaboresRepository sabores, INotificador notificador) : base(notificador)
        {
            _sabores = sabores;
        }
        public async Task<DTOSabores> Adicionar(DTOSabores sabores)
        {
            if (_sabores.Buscar(p => p.Descricao == sabores.Descricao).Result.Any())
            {
                Notificar("Este sabor já foi cadastrado.");
                return null;
            }
            var obj = new Sabores
            {
                Ativo = sabores.Ativo,
                Descricao = sabores.Descricao,
                TempoPreparo = sabores.TempoPreparo,
                Valor = sabores.Valor
            };
            var add = await _sabores.Adicionar(obj);
            sabores.Id = add.Id;
            return sabores;
        }

        public async Task<DTOSabores> Atualizar(DTOSabores sabores)
        {
            if (!_sabores.Buscar(p=>p.Id==sabores.Id).Result.Any())
            {
                Notificar("Sabor não localizado");
                return null;
            }
            var obj = new Sabores
            {
                Ativo = sabores.Ativo,
                Descricao = sabores.Descricao,
                TempoPreparo = sabores.TempoPreparo,
                Valor = sabores.Valor,
                Id = sabores.Id
            };
            var t = await _sabores.Atualizar(obj);
            return new DTOSabores
            {
                Ativo = t.Ativo,
                Id = t.Id,
                TempoPreparo = t.TempoPreparo,
                Descricao = t.Descricao,
                Valor = t.Valor,
            };
        }

        public async Task<bool> Excluir(int id)
        {
            if (!_sabores.Buscar(p => p.Id == id).Result.Any())
            {
                Notificar("Sabor não localizado");
                return false;
            }
            return await _sabores.Remover(id);
        }

        public async Task<DTOSabores> ObterPorId(int id)
        {
            if (!_sabores.Buscar(p => p.Id == id).Result.Any())
            {
                Notificar("Sabor não localizado");
                return null;
            }
            var obj = await _sabores.ObterPorId(id);
            return new DTOSabores
            {
                Valor = obj.Valor,
                TempoPreparo = obj.TempoPreparo,
                Id = obj.Id,
                Descricao = obj.Descricao,
                Ativo = obj.Ativo
            };
        }

        public async Task<List<DTOSabores>> ObterTodos()
        {
            var lst = await _sabores.ObterTodos();
            var listaRetorno = new List<DTOSabores>();
            foreach (var item in lst)
            {
                var obj = new DTOSabores
                {
                    Ativo = item.Ativo,
                    Descricao = item.Descricao,
                    Id = item.Id,
                    TempoPreparo = item.TempoPreparo,
                    Valor = item.Valor
                };
                listaRetorno.Add(obj);
            }
            return listaRetorno;
        }
    }
}
