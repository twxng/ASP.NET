using Lr12Task1.Data;
using Lr12Task1.Repositories;
using Lr12Task1.Services;

class Program
{
    static void Main()
    {
        using var context = new UserContext();
        var repo = new UserRepository(context);
        var service = new UserService(repo);

        service.SeedUsers();
        service.PrintUsers();
    }
}
