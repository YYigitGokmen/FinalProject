using MyApp.Business.Interfaces;
using MyApp.Data.Entities;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace MyApp.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly DataProtectionService _dataProtectionService;

        public UserService(IGenericRepository<User> userRepository, DataProtectionService dataProtectionService)
        {
            _userRepository = userRepository;
            _dataProtectionService = dataProtectionService;
        }
        public async Task RegisterUser(User user, string plainPassword)
        {
            // Encrypt the password before storing it
            user.Password = _dataProtectionService.Protect(plainPassword);

            await _userRepository.AddAsync(user);
        }

        public bool ValidatePassword(User user, string inputPassword)
        {
            // Decrypt the stored password and compare with input password
            var decryptedPassword = _dataProtectionService.Unprotect(user.Password);
            return decryptedPassword == inputPassword;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return user;
        }

        public Task AddUserAsync(User user)
        {
            throw new NotImplementedException();
        }

     
    }
}

