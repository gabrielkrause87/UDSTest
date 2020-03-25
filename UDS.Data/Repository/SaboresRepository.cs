using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UDS.Business.DTOs;
using UDS.Business.Interfaces.Repositories;
using UDS.Business.Model;
using UDS.Data.Context;

namespace UDS.Data.Repository
{
    public class SaboresRepository : Repository<Sabores>, ISaboresRepository
    {
        public SaboresRepository(ApiDbContext context) : base(context)
        {

        }
    }
}
