using MyGhar_Backend.Contract;
using MyGhar_Backend.DBContext;

namespace MyGhar_Backend.Service
{
    public class RoleService : IRole
    {

        public async Task<List<Role>> GetAll()
        {
            var list = new List<Role>();
            return list;
        }
    }
}
