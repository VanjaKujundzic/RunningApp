using RunGroupWebApp.Models;

namespace RunGroupWebApp.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUser>> GetAllUsers();
        Task<AppUser> GetUserById(string id);
        bool add (AppUser user);
        bool update (AppUser user);
        bool delete (AppUser user);
        bool Save();
    }
}
