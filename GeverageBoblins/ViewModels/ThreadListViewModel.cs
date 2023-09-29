using GeverageBoblins.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeverageBoblins.ViewModels
{
    public class ThreadListViewModel
    {
        public IEnumerable<Models.Thread> Threads;
        public string? CurrentViewName;

        public ThreadListViewModel(IEnumerable<Models.Thread> threads, string? currentViewName)
        {
            Threads = threads;
            CurrentViewName = currentViewName;
        }
    }
}
