using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Providers.Parsers;
using ScientificActivities.Service.Services.Interface.Services;

namespace ScientificActivities.Service.Services;

public class PublishingHouseService : IPublishingHouseService
{
    private readonly IPublishingHouseProvider _publishingHouseProvider;
    private readonly IPublishingHouseParseProvider _publishingHouseParseProvider;

    public PublishingHouseService(IPublishingHouseProvider publishingHouseProvider, IPublishingHouseParseProvider publishingHouseParseProvider)
    {
        _publishingHouseProvider = publishingHouseProvider;
        _publishingHouseParseProvider = publishingHouseParseProvider;
    }

    public async Task<Guid> CreateAsync(PublishingHouseRequest entityRequest, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(entityRequest.Name))
                throw new ExistIsEntityException("Name не может быть пустым");
            
            var existingpublishingHouse = await _publishingHouseProvider.FindAsync(entityRequest.Name, cancellationToken);
            if (existingpublishingHouse != null)
                return existingpublishingHouse.Id;
                //throw new ExistIsEntityException("Такое издательство уже существует");
            

            var publishingHouseDb = new PublishingHouse(entityRequest.Name,
                entityRequest.Country,
                entityRequest.City);
            await _publishingHouseProvider.AddAsync(publishingHouseDb, cancellationToken);
            return publishingHouseDb.Id;
        }

        public async Task<Guid> ParseAsync(string url, CancellationToken cancellationToken)
        {
            var entityRequest = await _publishingHouseParseProvider.ParseAsync(url, cancellationToken);
            
            
            var existingpublishingHouse = await _publishingHouseProvider.FindAsync(entityRequest.Name, cancellationToken);
            if (existingpublishingHouse != null)
                return existingpublishingHouse.Id;
                //throw new ExistIsEntityException("Такое издательство уже существует");

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