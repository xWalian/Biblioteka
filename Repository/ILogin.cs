using System.Collections.Generic;
using System.Threading.Tasks;
using Biblioteka.Models;

namespace Biblioteka.Repository
{
    public interface ILogin
    {
        Task<IEnumerable<UserLogin>> getuser();
        Task<UserLogin> AuthenticateUser(string username, string passcode);
    }
}