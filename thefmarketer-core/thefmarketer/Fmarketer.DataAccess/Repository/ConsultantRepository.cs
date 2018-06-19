using Fmarkerter.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public override Task AddAsync(Consultant user)
        {
            if (FindByEmail(user.Email) != null)
            {
                throw new InvalidOperationException("User with the same email already exist.");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new InvalidOperationException("Password must not be empty.");
            }

            user.Salt = BCrypt.BCryptHelper.GenerateSalt();
            user.Password = BCrypt.BCryptHelper.HashPassword(user.Password, user.Salt);

            return base.AddAsync(user);
        }

        public Consultant FindByEmail(string email)
        {
            return _dbContext.Consultants.Where(user => user.Email == email && !user.IsDeleted).FirstOrDefault();
        }
    }
}
