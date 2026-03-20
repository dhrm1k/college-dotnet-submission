using BackendDevWithDotNet.Models;

namespace BackendDevWithDotNet.Services;

public class InMemoryUserService : IUserService
{
    private readonly List<User> _users =
    [
        new User { Id = 1, FirstName = "Ada", LastName = "Lovelace", Email = "ada@example.com", Age = 28 },
        new User { Id = 2, FirstName = "Alan", LastName = "Turing", Email = "alan@example.com", Age = 32 }
    ];

    private int _nextId = 3;

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User? GetById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }

    public User Create(UserCreateRequest request)
    {
        var user = new User
        {
            Id = _nextId++,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Age = request.Age
        };

        _users.Add(user);
        return user;
    }

    public User? Update(int id, UserUpdateRequest request)
    {
        var existingUser = GetById(id);
        if (existingUser is null)
        {
            return null;
        }

        existingUser.FirstName = request.FirstName;
        existingUser.LastName = request.LastName;
        existingUser.Email = request.Email;
        existingUser.Age = request.Age;

        return existingUser;
    }

    public bool Delete(int id)
    {
        var existingUser = GetById(id);
        if (existingUser is null)
        {
            return false;
        }

        return _users.Remove(existingUser);
    }
}
