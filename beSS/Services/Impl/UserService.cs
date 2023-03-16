using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using beSS.Models;
using beSS.Models.RequestModels;
using beSS.Models.ViewModels;
using beSS.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace beSS.Services.Impl
{
    public class UserService:IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly MasterDbContext _context;
        private IUserService _userServiceImplementation;

        public UserService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IConfiguration configuration, MasterDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }
        
        
        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var User = await _userManager.FindByNameAsync(request.UserName);
            if (User==null)
            {
                throw new Exception("User not exist");
            }

            var loginResponse = await _userManager.CheckPasswordAsync(User, request.PassWord);
            if (!loginResponse)
            {
                throw new Exception("Emai or PassWord not correct");
            }
            var token = await GenerateTokenJWTByUser(User);
            return new LoginResponse
            {   
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<bool> Registration(RegistrationUser request)
        {
            if (request.UserName == null)
            {
                throw new Exception("Email can not empty");
            }

            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = request.UserName,
                Name = request.Name,
                Address = request.Address,
                /*Email = request.Email*/
            };
            var newPassword = await _userManager.CreateAsync(newUser, request.PassWord);
            if (newPassword.Succeeded)
            {
                return true;
            }
            return false;
        }
        

        public List<UserResponse> GetlistUsers()
        {
            var listUser = _context.Users.Select(user => new UserResponse
            {
                id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Address = user.Address
            }).ToList();
            return listUser;
        }

        public UserResponse DeleteUser(Guid id)
        {
            var targetUser = _context.Users.FirstOrDefault(user => user.Id == id);
            if (targetUser==null)
            {
                throw new Exception("User not found");
            }

            _context.Remove(targetUser);
            _context.SaveChanges();
            return new UserResponse
            {
                id = targetUser.Id,
                UserName = targetUser.UserName,
                Name = targetUser.Name,
                Address = targetUser.Address
            };
        }

        public UserResponse EditUser(EditUserRequest request)
        {
            var targetUser = _context.AspNetUsers.FirstOrDefault(user => user.Id == request.id);
            if (targetUser == null)
            {
                throw new Exception("not found this user");
            }

            targetUser.UserName = request.UserName;
            targetUser.Name = request.Name;
            targetUser.Address = request.Address;
            _context.SaveChanges();
            return new UserResponse()
            {
                id = targetUser.Id,
                UserName = targetUser.UserName,
                Name = targetUser.Name,
                Address = targetUser.Address
            };
        }

        public UserResponse GetUserByID(Guid id)
        {
            var targetUser = _context.Users.FirstOrDefault(x => x.Id == id);
            if (targetUser == null)
            {
                throw new Exception("Không tìm thấy người dùng");
            }

            return new UserResponse()
            {
                id = targetUser.Id,
                UserName = targetUser.UserName,
                Name = targetUser.Name,
                Address = targetUser.Address
            };
        }


        private async Task<JwtSecurityToken> GenerateTokenJWTByUser(ApplicationUser user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (string role in userRoles)
            {
                var roleData = await _roleManager.FindByNameAsync(role);
            }
            authClaims.Add(new Claim(ClaimTypes.Role, "manyRole"));

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(DefaultApplication.SecretKey));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}