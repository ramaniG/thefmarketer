using System.Threading.Tasks;

namespace Fmarketer.Models
{
    public class UnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
