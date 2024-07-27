using MyGhar_Backend.DBContext;

namespace MyGhar_Backend.Contract
{
    public interface IUserMaster
    {
        Task<List<UserMaster>> GetAll();
        Task<UserMaster> GetUser(string Username, string Password);
    }
}
