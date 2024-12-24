using AutoMapper;
using BuissnesLogic.DTO;
using BuissnesLogic.ServiceIntrface;
using DataAcsessLayer.Entity;
using DataAcsessLayer.repos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BuissnesLogic.Implemntation
{
    public class UserService : IUserService
    {
        private readonly IUserReposatory _repository;
        private readonly IMapper _mapper;
        public UserService(IUserReposatory repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // دالة لتجزئة كلمة المرور باستخدام SHA256
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString(); // إرجاع التجزئة
            }
        }

        // التحقق من كلمة المرور المدخلة
        private bool VerifyPassword(string inputPassword, string storedPasswordHash)
        {
            // تجزئة كلمة المرور المدخلة
            string hashedInputPassword = HashPassword(inputPassword);

            // المقارنة بين التجزئة المدخلة والتجزئة المخزنة
            return hashedInputPassword == storedPasswordHash;
        }

        // توليد JWT Token
        private string GenerateJwtToken(User user)
        {

            if (user == null)
                throw new ArgumentNullException(nameof(user), "User cannot be null.");

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ?? "0") // فقط معرف المستخدم
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("VeryLongComplexSecretKey_@2024SecureKey1234567890!"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:61448",
                audience: "http://localhost:61448",
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // تسجيل الدخول
        public async Task<string> LoginAsync(string PhoneNumber, string password)
        {
            // تحقق من وجود المستخدم عن طريق رقم الهاتف
            var user = await _repository.GetByPhone(PhoneNumber);
            if (user == null)
            {
                throw new UnauthorizedAccessException("User not found with the provided phone number.");
            }

            // تحقق من صحة كلمة المرور
            var passwordValid = VerifyPassword(password, user.PasswordHash);
            if (!passwordValid)
            {
                throw new UnauthorizedAccessException("Invalid password.");
            }

            // إنشاء JWT Token
            return GenerateJwtToken(user);
        }

        // تسجيل مستخدم جديد
        public async Task<string> RegisterAsync(AddUserDto userDto)
        {
            var existingUser = await _repository.GetByPhone(userDto.PhoneNumber);
            if (existingUser != null)
            {
                return "Email already registered.";
            }

            var user = _mapper.Map<User>(userDto);
            // تجزئة كلمة المرور باستخدام SHA256
            user.PasswordHash = HashPassword(userDto.Password);

            await _repository.Add(user);
            return "User registered successfully.";
        }

        // إضافة مستخدم جديد
        public async Task AddUserAsync(AddUserDto user)
        {
            var newUser = _mapper.Map<User>(user);
            await _repository.Add(newUser); // استخدم await بشكل صحيح
        }

        // حذف مستخدم
        public async Task DeleteUserAsync(int id)
        {
            await _repository.Delete(id);
        }

        // الحصول على جميع المستخدمين
        public async Task<IEnumerable<GetUserDto>> GetAllUsersAsync()
        {
            var users = await _repository.GetAll();
            return _mapper.Map<IEnumerable<GetUserDto>>(users);
        }

        // البحث عن مستخدم بالبريد الإلكتروني
        public async Task<GetUserDto> GetUserByEmailAsync(string email)
        {
            var user = await _repository.GetByEmail(email);
            return user == null ? null : _mapper.Map<GetUserDto>(user);
        }

        // البحث عن مستخدم بالمعرف
        public async Task<GetUserDto> GetUserByIdAsync(int id)
        {
            var user = await _repository.GetById(id);
            return user == null ? null : _mapper.Map<GetUserDto>(user);
        }

        // تحديث بيانات المستخدم
        public async Task UpdateUserAsync(AddUserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
