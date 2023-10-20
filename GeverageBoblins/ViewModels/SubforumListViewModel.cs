using GeverageBoblins.Models;

namespace GeverageBoblins.ViewModels
{
    public class SubforumListViewModel
    {

        public SubforumThreadComment SubforumThreadComment;
        public string? CurrentViewName;

        public SubforumListViewModel(SubforumThreadComment stc, string? currentViewName)
        {
            SubforumThreadComment = stc;
            CurrentViewName = currentViewName;
        }

    }
}
