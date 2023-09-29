using GeverageBoblins.Models;

namespace GeverageBoblins.ViewModels
{
    public class CommentListViewModel
    {
        public IEnumerable<Comment> Comments;
        public string? CurrentViewName;

        public CommentListViewModel(IEnumerable<Comment> comments, string? currentViewName)
        {
            Comments = comments;
            CurrentViewName = currentViewName;
        }
    }
}
