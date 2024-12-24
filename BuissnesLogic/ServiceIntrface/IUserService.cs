using BuissnesLogic.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.ServiceIntrface
{
    public interface IUserService
    {

        Task<string> RegisterAsync(AddUserDto userDto); // Register function
         Task<string> LoginAsync(string email, string password); // Login function
        Task AddUserAsync(AddUserDto user);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<GetUserDto>> GetAllUsersAsync();
        Task<GetUserDto> GetUserByEmailAsync(string email);
        Task<GetUserDto> GetUserByIdAsync(int id);
        Task UpdateUserAsync(AddUserDto user);
    }
}
