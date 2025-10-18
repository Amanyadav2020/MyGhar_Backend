using MyGhar_Backend.DBContext;

namespace MyGhar_Backend.Contract
{
    public interface IRole
    {
        Task<List<Role>> GetAll();
    }
}