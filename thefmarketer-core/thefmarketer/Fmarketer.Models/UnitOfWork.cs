using System;
using System.Threading;
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

            try {
                if (_context.ChangeTracker.HasChanges()) {
                    await _context.SaveChangesAsync();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex) {
                Console.Out.WriteLine(ex.Message);
            }

            return 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
