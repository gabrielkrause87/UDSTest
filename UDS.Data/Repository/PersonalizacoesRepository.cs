using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Model;
using UDS.Data.Context;

namespace UDS.Data.Repository
{
    public class PersonalizacoesRepository : Repository<Personalizacoes>, IPersonalizacoesRepository
    {
        public PersonalizacoesRepository(ApiDbContext context) : base(context)
        {

        }
    }
}
