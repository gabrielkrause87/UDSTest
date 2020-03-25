using System;
using System.Collections.Generic;
using System.Text;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Model;
using UDS.Data.Context;

namespace UDS.Data.Repository
{
    public class TamanhosRepository : Repository<Tamanhos>, ITamanhosRepository
    {
        public TamanhosRepository(ApiDbContext context) : base(context)
        { 

        }
    }
}
