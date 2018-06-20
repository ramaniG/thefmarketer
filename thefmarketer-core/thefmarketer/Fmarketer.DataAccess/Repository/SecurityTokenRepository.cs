using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class SecurityTokenRepository : Repository<SecurityToken, Guid>
    {
        private readonly MainContext _dbContext;

        public SecurityTokenRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<SecurityToken> AddAsync(SecurityToken token)
        {
            token.Id = Guid.NewGuid();
            return base.AddAsync(token);
        }

        public async Task<SecurityToken> CheckAndUpdateAsync(Guid id)
        {
            var token = await Get(id);
            if (token != null) {
                if (token.ExpiryTime > DateTime.Now) {
                    // If haven't reach expiry time, increase the timeout
                    token.ExpiryTime = token.ExpiryTime.AddMinutes(15); // TODO : Update when change the value to setting
                    Update(token);
                    return token;
                }
            }

            return null;
        }
    }
}
