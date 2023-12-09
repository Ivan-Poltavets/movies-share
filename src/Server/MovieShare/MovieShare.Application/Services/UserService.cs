using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieShare.Application.Services.Interfaces;
using MovieShare.Domain.Dtos;
using MovieShare.Domain.Entities;
using MovieShare.Domain.Interfaces;
using Newtonsoft.Json;

namespace MovieShare.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            if(await _userRepository.IsUserExistAsync(userDto.Username, userDto.Email))
            {
                throw new Exception("User exist");
            }
            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = ComputePasswordHash(userDto.Password, userDto.PasswordSalt);
            var createdUser = await _userRepository.CreateAsync(user);
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> GetByLoginAndPassword(string login, string password)
        {
            var user = await _userRepository.GetByLoginAsync(login);
            var passwordHash = ComputePasswordHash(password, user.PasswordSalt);
            var result = await _userRepository.GetByLoginAndPasswordHashAsync(login, passwordHash);
            if (result == null)
                throw new Exception();

            return _mapper.Map<UserDto>(result);
        }

        public async Task UploadUserImageAsync(int id, byte[] content)
        {
            var user = await _userRepository.GetByIdAsync(id);
            //filename + extension
            var fileName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), _configuration["FileStoragePath"], fileName);
            using (var writer = new FileStream(imagePath, FileMode.Create))
            {
                await writer.WriteAsync(content, 0, content.Length);
            }

            user.ImagePath = $"/{fileName}";
            await _userRepository.UpdateAsync(user);
        }

        private string ComputePasswordHash(string password, string salt)
        {
            var json = JsonConvert.SerializeObject(password + salt);
            var bytes = Encoding.UTF8.GetBytes(json);
            var hashBytes = SHA256.HashData(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}

