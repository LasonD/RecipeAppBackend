using Domain.Entities;

namespace Infrastructure.DataAccess.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
