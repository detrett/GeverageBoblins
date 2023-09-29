using GeverageBoblins.Models;
using Microsoft.EntityFrameworkCore;

namespace GeverageBoblins.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumDbContext _db;

        public UserRepository(ForumDbContext db)
        {
            _db = db;
        }
        public async Task Create(User user)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Users.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _db.Users.Remove(item);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>?> GetAll()
        {
            return await _db.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _db.Users.FindAsync(id);
        }

        public async Task Update(User user)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
        }
    }
}
