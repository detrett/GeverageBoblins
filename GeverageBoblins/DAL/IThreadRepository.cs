using GeverageBoblins.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeverageBoblins.DAL
{
    public interface IThreadRepository
    {
        Task<IEnumerable<Models.Thread>?> GetAll();
        Task<Models.Thread?> GetThreadById(int id);
        Task Create(Models.Thread thread);
        Task Update(Models.Thread thread);
        Task<bool> Delete(int id);
    }
}
