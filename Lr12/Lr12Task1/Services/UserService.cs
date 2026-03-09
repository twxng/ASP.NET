using System;
using Lr12Task1.Models;
using Lr12Task1.Interfaces;

namespace Lr12Task1.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void SeedUsers()
        {
            _repository.Add(new User { FirstName = "Оксана", LastName = "Шумакова", Age = 19 });
            _repository.Add(new User { FirstName = "Марія", LastName = "Шумакова", Age = 30 });
            _repository.Add(new User { FirstName = "Олег", LastName = "Коваль", Age = 28 });
        }

        public void PrintUsers()
        {
            foreach (var user in _repository.GetAll())
            {
                Console.WriteLine($"{user.Id}: {user.FirstName} {user.LastName}, {user.Age} років");
            }
        }
    }
}
