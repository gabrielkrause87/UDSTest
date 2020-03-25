using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.DTOs;
using UDS.Business.Model;

namespace UDS.Business.Interfaces.Services
{
    public interface ISaboresService
    {
        Task<DTOSabores> Adicionar(DTOSabores sabores);
        Task<List<DTOSabores>> ObterTodos();
        Task<DTOSabores> ObterPorId(int id);
        Task<DTOSabores> Atualizar(DTOSabores sabores);
        Task<bool> Excluir(int id);
    }
}
