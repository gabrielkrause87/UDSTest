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
    public class TamanhosService : BaseService, ITamanhosService
    {
        private readonly ITamanhosRepository _tamanhos;
        public TamanhosService(ITamanhosRepository tamanhos, INotificador notificador) : base(notificador)
        {
            _tamanhos = tamanhos;
        }

        public async Task<DTOTamanhos> Adicionar(DTOTamanhos tamanhos)
        {
            if (_tamanhos.Buscar(p => p.Descricao == tamanhos.Descricao).Result.Any())
            {
                Notificar("Tamanho já foi criado.");
                return null;
            }
            var obj = new Tamanhos
            {
                Ativo = tamanhos.Ativo,
                Descricao = tamanhos.Descricao,
                TempoPreparo = tamanhos.TempoPreparo,
                Valor = tamanhos.Valor,
                Volume = tamanhos.Volume
            };
            var t = await _tamanhos.Adicionar(obj);
            tamanhos.Id = t.Id;
            return tamanhos;
        }

        public async Task<DTOTamanhos> Atualizar(DTOTamanhos tamanhos)
        {
            if (!_tamanhos.Buscar(p => p.Id == tamanhos.Id).Result.Any())
            {
                Notificar("Tamanho não localizado");
                return null;
            }
            var obj = new Tamanhos
            {
                Ativo = tamanhos.Ativo,
                Descricao = tamanhos.Descricao,
                TempoPreparo = tamanhos.TempoPreparo,
                Valor = tamanhos.Valor,
                Volume = tamanhos.Volume,
                Id = tamanhos.Id
            };
            var t = await _tamanhos.Atualizar(obj);
            return tamanhos;
        }

        public async Task<bool> Excluir(int id)
        {
            if (!_tamanhos.Buscar(p => p.Id == id).Result.Any())
            {
                Notificar("Tamanho não localizado");
                return false;
            }
            var t = await _tamanhos.Remover(id);
            return t;
        }

        public async Task<DTOTamanhos> ObterPorId(int id)
        {
            if (!_tamanhos.Buscar(p => p.Id == id).Result.Any())
            {
                Notificar("Tamanho não localizado");
                return null;
            }
            var t = await _tamanhos.ObterPorId(id);
            var obj = new DTOTamanhos
            {
                Ativo = t.Ativo,
                Id = t.Id,
                Descricao = t.Descricao,
                TempoPreparo = t.TempoPreparo,
                Valor = t.Valor,
                Volume = t.Volume
            };
            return obj;
        }

        public async Task<List<DTOTamanhos>> ObterTodos()
        {
            var lst = await _tamanhos.ObterTodos();
            var lstRet = new List<DTOTamanhos>();
            foreach (var t in lst)
            {
                var obj = new DTOTamanhos
                {
                    Ativo = t.Ativo,
                    Id = t.Id,
                    Descricao = t.Descricao,
                    TempoPreparo = t.TempoPreparo,
                    Valor = t.Valor,
                    Volume = t.Volume
                };
                lstRet.Add(obj);
            }
            return lstRet;
        }
    }
}
