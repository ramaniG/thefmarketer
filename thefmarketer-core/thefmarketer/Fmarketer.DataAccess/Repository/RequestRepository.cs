using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class RequestRepository : Repository<Request, Guid>
    {
        private readonly MainContext _dbContext;

        public RequestRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<Request> AddAsync(Request request)
        {
            request.Id = Guid.NewGuid();
            request.IsActive = true;
            request.IsCompleted = false;
            return base.AddAsync(request);
        }
    }
}
