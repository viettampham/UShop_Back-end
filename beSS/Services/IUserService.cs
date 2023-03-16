using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;

namespace beSS.Services
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task<bool> Registration(RegistrationUser request);
        List<UserResponse> GetlistUsers();
        UserResponse DeleteUser(Guid id);
        UserResponse EditUser(EditUserRequest request);
        UserResponse GetUserByID(Guid id);
    }
}