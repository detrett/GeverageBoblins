using GeverageBoblins.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeverageBoblins.DAL
{
    public class ThreadRepository : IThreadRepository
    {
        private readonly ForumDbContext _db;

        public ThreadRepository(ForumDbContext db)
        {
            _db = db;
        }

        public async Task Create(Models.Thread thread)
        {
            _db.Threads.Add(thread);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _db.Threads.FindAsync(id);
            if (item == null)
            {
                return false;
            }

            _db.Threads.Remove(item);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Models.Thread>?> GetAll()
        {
            return await _db.Threads.ToListAsync();
        }

        public async Task<Models.Thread?> GetThreadById(int id)
        {
            return await _db.Threads.FindAsync(id);
        }

        public async Task Update(Models.Thread thread)
        {
            _db.Threads.Update(thread);
            await _db.SaveChangesAsync();
        }
    }
}
