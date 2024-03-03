using back_end.DTOs;
using back_end.Models;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Services.interfaces
{
    public interface IUsersService
    {
        Task<ActionResult<User>> CreateUser(CreateUserRequest userData);
        Task<ActionResult<List<User>>> GetAllUsers();     
    }
}
