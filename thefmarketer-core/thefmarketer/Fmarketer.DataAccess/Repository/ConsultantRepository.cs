using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class ConsultantRepository : Repository<Consultant, Guid>
    {
        private readonly MainContext _dbContext;

        public ConsultantRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<Consultant> AddAsync(Consultant consultant)
        {
            consultant.Id = Guid.NewGuid();

            if (FindByEmail(consultant.Email) != null)
            {
                throw new InvalidOperationException("User with the same email already exist.");
            }

            return base.AddAsync(consultant);
        }

        public Consultant FindByEmail(string email)
        {
            return _dbContext.Consultants.Where(consultant => consultant.Email == email && !consultant.IsDeleted).FirstOrDefault();
        }

        public async Task<Consultant> FindByCredentialAsync(Guid id)
        {
            return await SingleOrDefaultAsync(consultant => consultant._Credential.Id == id && !consultant.IsDeleted);
        }
    }
}
