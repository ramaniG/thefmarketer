using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class AdminRepository : Repository<Admin, Guid>
    {
        private readonly MainContext _dbContext;

        public AdminRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<Admin> AddAsync(Admin admin)
        {
            admin.Id = Guid.NewGuid();
            return base.AddAsync(admin);
        }

        public Admin FindByEmail(string email)
        {
            return _dbContext.Admins.Where(admin => admin.Email == email && !admin.IsDeleted).FirstOrDefault();
        }

        public Admin FindByCredential(Guid id)
        {
            return _dbContext.Admins.Where(admin => admin._Credential.Id == id && !admin.IsDeleted).FirstOrDefault();
        }
    }
}
