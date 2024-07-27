using Microsoft.EntityFrameworkCore;
using MyGhar_Backend.Contract;
using MyGhar_Backend.DBContext;

namespace MyGhar_Backend.Service
{
    public class UserMasterService: IUserMaster
    {
        private readonly MyGharLocalDbContext _dbContext;

        public UserMasterService(MyGharLocalDbContext context)
        {
            _dbContext = context;
        }



        public async Task<List<UserMaster>> GetAll()
        {
            try
            {
                using (_dbContext)
                {
                    return await _dbContext.UserMasters.Where(x => x.IsDeleted == false).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserMaster> GetUser(string Username, string Password)
        {
            try
            {
                using (_dbContext)
                {
                    UserMaster Usermodel = null;
                    var User = await _dbContext.UserMasters.Where(x => x.IsDeleted == false && x.UserName == Username && x.Password == Password).Select(x => new UserMaster
                    {
                        Id = x.Id,
                        UserName = x.UserName,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        LastName = x.LastName,
                        Email = x.Email,
                        Contact = x.Contact,
                        CreatedBy = x.CreatedBy,
                        CreatedDate = x.CreatedDate,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedDate = x.UpdatedDate,
                        IsDeleted = x.IsDeleted
                    }).FirstOrDefaultAsync();

                    if (User != null)
                    {
                        Usermodel = new UserMaster
                        {
                            Id = User.Id,
                            UserName = User.UserName,
                            FirstName = User.FirstName,
                            MiddleName = User.MiddleName,
                            LastName = User.LastName,
                            Email = User.Email,
                            Contact = User.Contact,
                            CreatedBy = User.CreatedBy,
                            CreatedDate = User.CreatedDate,
                            UpdatedBy = User.UpdatedBy,
                            UpdatedDate = User.UpdatedDate,
                            IsDeleted = User.IsDeleted
                        };
                    }
                    return Usermodel;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
