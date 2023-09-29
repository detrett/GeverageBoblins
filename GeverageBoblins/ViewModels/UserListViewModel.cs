using GeverageBoblins.Models;

namespace GeverageBoblins.ViewModels
{
    public class UserListViewModel
    {
        public IEnumerable<User> Users;
        public string? CurrentViewName;

        public UserListViewModel(IEnumerable<User> users, string? currentViewName)
        {
            Users = users;
            CurrentViewName = currentViewName;
        }
    }
}
