using GeverageBoblins.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeverageBoblins.ViewModels
{
    public class ThreadListViewModel
    {
        public Models.Thread Thread;
        public string? CurrentViewName;

        public ThreadListViewModel(Models.Thread thread, string? currentViewName)
        {
            Thread = thread;
            CurrentViewName = currentViewName;
        }
    }
}
