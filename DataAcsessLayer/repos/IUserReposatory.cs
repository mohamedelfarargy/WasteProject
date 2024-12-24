using DataAcsessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsessLayer.repos
{
    public interface IUserReposatory : IRepository<User>
    {
        Task<User> GetByPhone(string PhoneNumber);
        Task<User> GetByEmail(string Email);
    }
}
