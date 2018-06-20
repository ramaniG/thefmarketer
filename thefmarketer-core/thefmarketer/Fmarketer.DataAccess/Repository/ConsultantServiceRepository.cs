using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class ConsultantServiceRepository : Repository<ConsultantService, Guid>
    {
        private readonly MainContext _dbContext;

        public ConsultantServiceRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<ConsultantService> AddAsync(ConsultantService service)
        {
            service.Id = Guid.NewGuid();
            return base.AddAsync(service);
        }
    }
}
