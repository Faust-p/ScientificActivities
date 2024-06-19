using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Service.Services;

public class PublishingHouseService : IPublishingHouseService
{
    private readonly IPublishingHouseProvider _publishingHouseProvider;

     public async Task<Guid> CreateAsync(PublishingHouseRequest entityRequest, CancellationToken cancellationToken)
        {
            if (await _publishingHouseProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
                throw new ExistIsEntityException("Такое издательство уже существует");

            var publishingHouseDb = new PublishingHouse(entityRequest.Name,
                entityRequest.Country,
                entityRequest.City);
            await _publishingHouseProvider.AddAsync(publishingHouseDb, cancellationToken);
            return publishingHouseDb.Id;
        }

        public async Task<PublishingHouse?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var publishingHouse = await _publishingHouseProvider.FindAsync(id, cancellationToken);
            if (publishingHouse == null)
                throw new NotExistException("Такого издательства не существует");
            return publishingHouse;
        }

        public async Task<PublishingHouse> GetAsync(string name, CancellationToken cancellationToken)
        {
            var publishingHouse = await _publishingHouseProvider.FindAsync(name, cancellationToken);
            if (publishingHouse == null)
                throw new NotExistException("Такого издательства не существует");
            return publishingHouse;
        }

        public async Task<PublishingHouse> UpdateAsync(PublishingHouseRequest entityRequest, CancellationToken cancellationToken)
        {
            var publishingHouseDb = await GetAsync(entityRequest.Id, cancellationToken);
            if (publishingHouseDb == null)
                throw new NotExistException("Такого издательства не существует");

            publishingHouseDb.Name = entityRequest.Name;
            publishingHouseDb.UpdateChange = DateTime.Now;

            await _publishingHouseProvider.UpdateAsync(publishingHouseDb, cancellationToken);
            return publishingHouseDb;
        }

        public async Task<List<PublishingHouse>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _publishingHouseProvider.GetAllAsync(cancellationToken);
        }
        
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _publishingHouseProvider.DeleteAsync(id, cancellationToken);
        }
}