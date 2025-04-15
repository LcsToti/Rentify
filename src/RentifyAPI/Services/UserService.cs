using RentifyAPI.Models;
using RentifyAPI.DTOs.User;
using RentifyAPI.Utils.Mappers;
using RentifyAPI.Utils.Security;
using Microsoft.EntityFrameworkCore;

namespace RentifyAPI.Services
{
    public class UserService : IUserService
    {
        private readonly RentifyContext _context;
        public UserService(RentifyContext context)
        {
            _context = context;
        }
        public async Task<GetUserDTO?> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user != null ? UserMapper.ToDTO(user) : null;
        }

        public async Task<List<GetUserDTO>> GetUsersAsync()
        {
            var users = await _context.Users
                .Select(u => new GetUserDTO { Id = u.Id, Name = u.Name })
                .ToListAsync();
            return users;
        }

        public async Task<GetUserDTO> CreateUserAsync(RegisterUserDTO dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                throw new InvalidOperationException("E-mail já cadastrado.");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = PasswordHasher.Hash(dto.Password),
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new GetUserDTO
            {
                Id = user.Id,
                Name = user.Name,
            };
        }
    }
}
