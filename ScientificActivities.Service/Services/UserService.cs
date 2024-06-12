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

    public UserService(IUserProvider userProvider)
    {
        _userProvider = userProvider;
    }

    public async Task<Guid> CreateAsync(UserRequest entityRequest, CancellationToken cancellationToken)
        {
            if (await _userProvider.FindAsync(entityRequest.Email, cancellationToken) != null)
                throw new ExistIsEntityException("Пользователь с таким email уже существует");

            var userDb = new User(entityRequest.FirstName,
                entityRequest.LastName,
                entityRequest.SureName,
                entityRequest.Email,
                (EnumUserRole) Enum.Parse(typeof(EnumUserRole), entityRequest.Role, true),
                (EnumUserStatus) Enum.Parse(typeof(EnumUserStatus), entityRequest.Status, true));

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

            userDb.FirstName = entityRequest.FirstName;
            userDb.LastName = entityRequest.LastName;
            userDb.SureName = entityRequest.SureName;
            userDb.Email = entityRequest.Email;
            userDb.Role = (EnumUserRole) Enum.Parse(typeof(EnumUserRole), entityRequest.Role, true);
            userDb.Status = (EnumUserStatus) Enum.Parse(typeof(EnumUserStatus), entityRequest.Status, true);
            userDb.UpdateChange = DateTime.Now;

            await _userProvider.UpdateAsync(userDb, cancellationToken);
            return userDb;
        }

        public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _userProvider.GetAllAsync(cancellationToken);
        }
}