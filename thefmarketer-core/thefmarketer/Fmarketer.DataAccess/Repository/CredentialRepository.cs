using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
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

        public override Task<Credential> AddAsync(Credential credential)
        {
            credential.Id = Guid.NewGuid();

            if (FindByEmail(credential.Email) != null) {
                throw new InvalidOperationException("User with the same email already exist.");
            }

            if (string.IsNullOrEmpty(credential.Password)) {
                throw new InvalidOperationException("Password must not be empty.");
            }

            credential.Salt = BCrypt.BCryptHelper.GenerateSalt();
            credential.Password = BCrypt.BCryptHelper.HashPassword(credential.Password, credential.Salt);

            return base.AddAsync(credential);
        }

        public override void Update(Credential credential)
        {
            credential.Salt = BCrypt.BCryptHelper.GenerateSalt();
            credential.Password = BCrypt.BCryptHelper.HashPassword(credential.Password, credential.Salt);

            base.Update(credential);
        }

        public Credential FindByEmail(string email)
        {
            return _dbContext.Credentials.Where(credential => credential.Email == email && !credential.IsDeleted).FirstOrDefault();
        }
    }
}
