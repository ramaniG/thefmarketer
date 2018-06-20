using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class UserRepository : Repository<User, Guid>
    {
        private readonly MainContext _dbContext;

        public UserRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<User> AddAsync(User user)
        {
            user.Id = Guid.NewGuid();

            if (FindByEmail(user.Email) != null)
            {
                throw new InvalidOperationException("User with the same email already exist.");
            }

            return base.AddAsync(user);
        }

        public User FindByEmail(string email)
        {
            return _dbContext.Users.Where(user => user.Email == email && !user.IsDeleted).FirstOrDefault();
        }
    }
}
