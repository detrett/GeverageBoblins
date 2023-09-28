using Microsoft.AspNetCore.Mvc;
using GeverageBoblins.Models;

namespace GeverageBoblins.DAL
{
    public interface ISubforumRepository
    {
        Task<IEnumerable<Subforum>?> GetAll();
        Task<Subforum?> GetSubforumById(int id);
        Task Create(Subforum subforum);
        Task Update(Subforum subforum);
        Task<bool> Delete(int id);
    }
}
