using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class CredentialRepository : Repository<Credential, Guid>
    {
        private readonly MainContext _dbContext;

        public CredentialRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Credential> AddAsync(Credential credential)
        {
            credential.Id = Guid.NewGuid();

            var a = await FindByEmailAsync(credential.Email);
            if (a != null) {
                throw new InvalidOperationException("User with the same email already exist.");
            }

            if (string.IsNullOrEmpty(credential.Password)) {
                throw new InvalidOperationException("Password must not be empty.");
            }

            credential.Salt = BCrypt.BCryptHelper.GenerateSalt();
            credential.Password = BCrypt.BCryptHelper.HashPassword(credential.Password, credential.Salt);

            return await base.AddAsync(credential);
        }

        public void UpdateWithPassword(Credential credential)
        {
            credential.Salt = BCrypt.BCryptHelper.GenerateSalt();
            credential.Password = BCrypt.BCryptHelper.HashPassword(credential.Password, credential.Salt);

            Update(credential);
        }

        public async Task<Credential> FindByEmailAsync(string email)
        {
            var credential = await _dbContext.Credentials.Where(x => x.Email == email && !x.IsDeleted).FirstOrDefaultAsync();
            return credential;
        }
    }
}
