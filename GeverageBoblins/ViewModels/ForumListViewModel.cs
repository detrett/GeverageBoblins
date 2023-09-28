using GeverageBoblins.Models;

namespace GeverageBoblins.ViewModels
{
    public class ForumListViewModel
    {

        public IEnumerable<Forum> Forums;

        public string? CurrentViewName;

        public ForumListViewModel(IEnumerable<Forum> forums, string? currentViewName) 
        {
            Forums = forums;
            CurrentViewName = currentViewName;
        }

    }
}
