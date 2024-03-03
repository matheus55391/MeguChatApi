using ApiNet5.Models;
using back_end.DTOs;
using back_end.Models;
using back_end.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_end.Services
{
    public class UsersService: IUsersService
    {
        private readonly AppDbContext _context;

        public UsersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<User>> CreateUser(CreateUserRequest userData)
        {
            User newUser = new User { 
                UserName = userData.Username, 
                Password = userData.Password,
            };
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();
            newUser.Password = "";
            return newUser;
        }

        public async Task<ActionResult<List<User>>> GetAllUsers() {

            var result = await _context.Users.ToListAsync();
            return result;
        }
    }
}
