using HoneyStore.DataAccess.Context;
using HoneyStore.DataAccess.Identity;
using HoneyStore.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HoneyStore.DataAccess.Repositories
{
    public class UserRepository: BaseRepository<User>, IUserRepository
    {
        public UserRepository(StoreDbContext context): base(context)
        {
            
        }

        public async Task<ICollection<Role>> GetUserRolesAsync(int userId)
        {
            return await _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => _context.Roles.Single(r => r.Id == ur.RoleId))
                .ToListAsync();
        }
    }
}
