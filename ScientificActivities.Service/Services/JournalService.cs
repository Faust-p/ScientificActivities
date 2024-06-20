using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.CustomException;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.Service.Services.Interface.Providers;
using ScientificActivities.Service.Services.Interface.Providers.Parsers;
using ScientificActivities.Service.Services.Interface.Services;
using ScientificActivities.StorageEnums;

namespace ScientificActivities.Service.Services;

public class JournalService : IJournalService
{
    private readonly IJournalProvider _journalProvider;
    private readonly IPublishingHouseProvider _publishingHouseProvider;
    private readonly IJournalParseProvider _journalParseProvider;
    
    public JournalService(IJournalProvider journalProvider, IPublishingHouseProvider publishingHouseProvider, IJournalParseProvider journalParseProvider)
    {
        _journalProvider = journalProvider;
        _publishingHouseProvider = publishingHouseProvider;
        _journalParseProvider = journalParseProvider;
    }

     public async Task<Guid> CreateAsync(JournalRequest entityRequest, CancellationToken cancellationToken)
        {
            if (await _journalProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
                throw new ExistIsEntityException("Такой журнал уже существует");

            var publishingHouse = await _publishingHouseProvider.FindAsync(entityRequest.PublishingHouseId, cancellationToken);
            if (publishingHouse == null)
                throw new MissingDivisionException("Такого издательства не существует");

            var journalDb = new Journal(entityRequest.Name, 
                publishingHouse,
                (EnumJournalStatus) Enum.Parse(typeof(EnumJournalStatus), 
                entityRequest.Status, true));
            await _journalProvider.AddAsync(journalDb, cancellationToken);
            return journalDb.Id;
        }

        public async Task<Guid> CreateParseAsync(string url, CancellationToken cancellationToken)
        {
            var entityRequest = await _journalParseProvider.ParseAsync(url, cancellationToken);

            if (await _journalProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
                throw new ExistIsEntityException("Такой журнал уже существует");

            var publishingHouse = await _publishingHouseProvider.FindAsync(entityRequest.PublishingHouseId, cancellationToken);
            if (publishingHouse == null)
                throw new MissingDivisionException("Такого издательства не существует");

            var journalDb = new Journal(entityRequest.Name, 
                publishingHouse,
                (EnumJournalStatus) Enum.Parse(typeof(EnumJournalStatus), 
                    entityRequest.Status, true));
            await _journalProvider.AddAsync(journalDb, cancellationToken);
            return journalDb.Id;
        }
        
        public async Task<Journal?> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var journal = await _journalProvider.FindAsync(id, cancellationToken);
            if (journal == null)
                throw new NotExistException("Такого журнала не существует");
            return journal;
        }

        public async Task<Journal> GetAsync(string name, CancellationToken cancellationToken)
        {
            var journal = await _journalProvider.FindAsync(name, cancellationToken);
            if (journal == null)
                throw new NotExistException("Такого журнала не существует");
            return journal;
        }
        
        public async Task<Journal> UpdateAsync(JournalRequest entityRequest, CancellationToken cancellationToken)
        {
            var journalDb = await GetAsync(entityRequest.Id, cancellationToken);
            if (journalDb == null)
                throw new NotExistException("Такого журнала не существует");

            var publishingHouse = await _publishingHouseProvider.FindAsync(entityRequest.PublishingHouseId, cancellationToken);
            if (publishingHouse == null)
                throw new MissingDivisionException("Такого издательства не существует");

            journalDb.Name = entityRequest.Name;
            journalDb.PublishingHouse = publishingHouse;
            journalDb.UpdateChange = DateTime.Now;

            await _journalProvider.UpdateAsync(journalDb, cancellationToken);
            return journalDb;
        }

        public async Task<List<Journal>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _journalProvider.GetAllAsync(cancellationToken);
        }
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _journalProvider.DeleteAsync(id, cancellationToken);
        }
}