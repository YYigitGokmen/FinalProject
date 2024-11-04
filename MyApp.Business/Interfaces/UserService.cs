/*
using MyApp.Business.Interfaces;
using MyApp.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserService : IUserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<IEnumerable<User>> GetAllUsersAsync() => await _userRepository.GetAllAsync();

    public async Task AddUserAsync(User user) => await _userRepository.AddAsync(user);

    public Task<User> GetUserByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User> CreateUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}
*/