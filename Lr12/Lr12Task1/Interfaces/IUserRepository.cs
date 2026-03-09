using System.Collections.Generic;
using Lr12Task1.Models;

namespace Lr12Task1.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        void Update(User user);
        void Delete(User user);
    }
}
