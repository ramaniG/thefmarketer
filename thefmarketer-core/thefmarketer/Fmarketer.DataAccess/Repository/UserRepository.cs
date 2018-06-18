using Fmarkerter.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;

namespace Fmarketer.DataAccess.Repository
{
    public class UserRepository : Repository<User, Guid>
    {
        private readonly MainContext _dbContext;

        public UserRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
