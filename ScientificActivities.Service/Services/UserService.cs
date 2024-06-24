using ScientificActivities.Data.Models;
using ScientificActivities.Data.Models.UserActivity;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.UserActivity;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;
using ScientificActivities.StorageEnums;

namespace ScientificActivities.Service.Services;

public class UserService : IUserService
{
    private readonly IUserProvider _userProvider;
    //private readonly IMailTokenProvider _mailTokenProvider;
    private readonly ITokenProvider _tokenProvider;
    private readonly IPasswordHashService _passwordHashService;

    public UserService(IUserProvider userProvider,  ITokenProvider tokenProvider, IPasswordHashService passwordHashService)
    {
        _userProvider = userProvider;
        _tokenProvider = tokenProvider;
        _passwordHashService = passwordHashService;
    }

    public async Task<Token> LoginAsync(UserLoginRequest entityRequest, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(entityRequest.Password))
            throw new ExistIsEntityException("Password не может быть пустым");

        if (string.IsNullOrWhiteSpace(entityRequest.Email))
            throw new ExistIsEntityException("Email не может быть пустым");
    
        var user = await _userProvider.FindAsync(entityRequest.Email, cancellationToken);
        if (user == null)
            throw new ExistIsEntityException("Пользователя не существует");
    
        var computedHash = _passwordHashService.GetHashPassword(entityRequest.Password, user.PasswordKey);
        Console.WriteLine($"Stored Hash: {user.PasswordHash}");
        Console.WriteLine($"Computed Hash: {computedHash}");

        if (user.PasswordHash != computedHash)
            throw new ExistIsEntityException("Неверный пароль");

        return _tokenProvider.CreateToken(user);
    }
    
    public async Task<Guid> CreateAsync(UserRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _userProvider.FindAsync(entityRequest.Email, cancellationToken) != null)
            throw new ExistIsEntityException("Пользователь с таким email уже существует");
    
        if (string.IsNullOrWhiteSpace(entityRequest.Email))
            throw new ExistIsEntityException("Email не может быть пустым");
    
        if (string.IsNullOrWhiteSpace(entityRequest.Password))
            throw new ExistIsEntityException("Email не может быть пустым");
    
        var password = _passwordHashService.GenHashPassword(entityRequest.Password);

        Console.WriteLine($"Generated Password Hash: {password.Hash}");
        Console.WriteLine($"Generated Password Key: {password.Key}");

        var userDb = new User(entityRequest.FirstName,
            entityRequest.LastName,
            entityRequest.SureName,
            entityRequest.Email,
            EnumUserRole.User,
            EnumUserStatus.New,
            password.Key,
            password.Hash);

        await _userProvider.AddAsync(userDb, cancellationToken);
    
        return userDb.Id;
    }

        public async Task<User?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var user = await _userProvider.FindAsync(id, cancellationToken);
            if (user == null)
                throw new NotExistException("Такого пользователя не существует");
            return user;
        }

        public async Task<User> UpdateAsync(UserRequest entityRequest, CancellationToken cancellationToken)
        {
            var userDb = await GetAsync(entityRequest.Id, cancellationToken);
            if (userDb == null)
                throw new NotExistException("Такого пользователя не существует");
            
            var password = _passwordHashService.GenHashPassword(entityRequest.Password);
            
            userDb.FirstName = entityRequest.FirstName;
            userDb.LastName = entityRequest.LastName;
            userDb.SureName = entityRequest.SureName;
            userDb.Email = entityRequest.Email;
            userDb.Role = (EnumUserRole) Enum.Parse(typeof(EnumUserRole), entityRequest.Role, true);
            userDb.Status = (EnumUserStatus) Enum.Parse(typeof(EnumUserStatus), entityRequest.Status, true);
            userDb.PasswordKey = password.Key;
            userDb.PasswordHash = password.Hash;
            userDb.UpdateChange = DateTime.Now;

            await _userProvider.UpdateAsync(userDb, cancellationToken);
            return userDb;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _userProvider.GetAllAsync(cancellationToken);
        }
        
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _userProvider.DeleteAsync(id, cancellationToken);
        }
}