using BackendDevWithDotNet.Models;

namespace BackendDevWithDotNet.Services;

public interface IUserService
{
    IEnumerable<User> GetAll();
    User? GetById(int id);
    User Create(UserCreateRequest request);
    User? Update(int id, UserUpdateRequest request);
    bool Delete(int id);
}
