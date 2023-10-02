using GeverageBoblins.Models;

namespace GeverageBoblins.ViewModels
{
    public class SubforumListViewModel
    {

        public Subforum Subforum;
        public string? CurrentViewName;

        public SubforumListViewModel(Subforum subforum, string? currentViewName)
        {
            Subforum = subforum;
            CurrentViewName = currentViewName;
        }

    }
}
