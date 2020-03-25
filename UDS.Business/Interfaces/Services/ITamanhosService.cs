using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.DTOs;

namespace UDS.Business.Interfaces.Services
{
    public interface ITamanhosService
    {
        Task<DTOTamanhos> Adicionar(DTOTamanhos tamanhos);
        Task<List<DTOTamanhos>> ObterTodos();
        Task<DTOTamanhos> ObterPorId(int id);
        Task<DTOTamanhos> Atualizar(DTOTamanhos tamanhos);
        Task<bool> Excluir(int id);
    }
}
