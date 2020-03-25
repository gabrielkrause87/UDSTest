using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.DTOs;

namespace UDS.Business.Interfaces.Services
{
    public interface IPersonalizacoesService
    {
        Task<List<DTOPersonalizacoes>> ListarTodos();
        Task<DTOPersonalizacoes> ObterPorId(int id);
        Task<DTOPersonalizacoes> Adicionar(DTOPersonalizacoes personalizacoes);
        Task<DTOPersonalizacoes> Atualizar(DTOPersonalizacoes personalizacoes);
        Task<bool> Excluir(int id);
    }
}
