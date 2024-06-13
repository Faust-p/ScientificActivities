using Microsoft.EntityFrameworkCore;
using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.Services.Interface.Providers;

namespace ScientificActivities.Infrastructure.Providers;

public class PublishingHouseProvider : IPublishingHouseProvider
{
private readonly ApplicationContext _applicationContext;

        public PublishingHouseProvider(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<Guid> AddAsync(PublishingHouse entity, CancellationToken cancellationToken)
        {
            _applicationContext.Add(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity.Id;
        }

        public async Task<PublishingHouse?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            var publishingHouse = await _applicationContext.PublishingHouses
                .FirstOrDefaultAsync(ph => ph.Id == id, cancellationToken: cancellationToken).ConfigureAwait(false);
            return publishingHouse;
        }

        public async Task<PublishingHouse?> FindAsync(string name, CancellationToken cancellationToken)
        {
            var publishingHouse = await _applicationContext.PublishingHouses
                .FirstOrDefaultAsync(ph => ph.Name == name, cancellationToken: cancellationToken).ConfigureAwait(false);
            return publishingHouse;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var publishingHouse = await FindAsync(id, cancellationToken);
            ArgumentNullException.ThrowIfNull(publishingHouse);
            _applicationContext.Remove(publishingHouse);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<PublishingHouse> UpdateAsync(PublishingHouse entity, CancellationToken cancellationToken)
        {
            _applicationContext.Update(entity);
            await _applicationContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public async Task<List<PublishingHouse>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _applicationContext.PublishingHouses.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
        }
}