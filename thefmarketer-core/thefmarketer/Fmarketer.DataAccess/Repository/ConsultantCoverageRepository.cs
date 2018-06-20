using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class ConsultantCoverageRepository : Repository<ConsultantCoverage, Guid>
    {
        private readonly MainContext _dbContext;

        public ConsultantCoverageRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<ConsultantCoverage> AddAsync(ConsultantCoverage coverage)
        {
            coverage.Id = Guid.NewGuid();
            return base.AddAsync(coverage);
        }
    }
}
