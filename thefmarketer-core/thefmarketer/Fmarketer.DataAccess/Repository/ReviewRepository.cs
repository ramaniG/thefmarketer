using Fmarketer.Base;
using Fmarketer.Models;
using Fmarketer.Models.Model;
using System;
using System.Threading.Tasks;

namespace Fmarketer.DataAccess.Repository
{
    public class ReviewRepository : Repository<Review, Guid>
    {
        private readonly MainContext _dbContext;

        public ReviewRepository(MainContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override Task<Review> AddAsync(Review review)
        {
            review.Id = Guid.NewGuid();
            return base.AddAsync(review);
        }
    }
}
