using GeverageBoblins.Models;

namespace GeverageBoblins.DAL
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>?> GetAll();
        Task<Comment?> GetCommentById(int id);
        Task Create(Comment comment);
        Task Update(Comment comment);
        Task<bool> Delete(int id);
    }
}
