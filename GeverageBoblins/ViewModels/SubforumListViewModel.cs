using GeverageBoblins.Models;

namespace GeverageBoblins.ViewModels
{
    public class SubforumListViewModel
    {

        public IEnumerable<Subforum> Subforums;
        public string? CurrentViewName;

        public SubforumListViewModel(IEnumerable<Subforum> subforums, string? currentViewName)
        {
            Subforums = subforums;
            CurrentViewName = currentViewName;
        }

    }
}
