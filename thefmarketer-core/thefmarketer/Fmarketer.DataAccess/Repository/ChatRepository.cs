using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class ChatRepository : Repository<Chat, Guid>
    {
        private readonly MainContext _dbContext;

        public ChatRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<Chat> AddAsync(Chat chat)
        {
            chat.Id = Guid.NewGuid();
            return base.AddAsync(chat);
        }
    }
}
