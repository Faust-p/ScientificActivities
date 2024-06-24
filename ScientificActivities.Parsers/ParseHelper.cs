using ScientificActivities.Parsers.Parsers;
using ScientificActivities.Service.ModelRequest.Parser;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers;

public static class ParseHelper
{
    public static ParseRequest FullParse(string articleUrl)
    {
        //Должен вернуть ArticleRequet и JournalUrl
        var (articlesRequest, journalUrl) = ArticleHelper.TypeOfJournal(articleUrl);
            
        //Должен вернуть JournalRequet и PublihingHouseUrl
        var (journalRequest, publishingHouseUrl, publisherName) = JournalHelper.TypeOfJournal(journalUrl);
        
        //Должен вернуть PublihingHouseRequet
        PublishingHouseRequest? publishingHouseRequest;
        if (publishingHouseUrl != null)
        {
            publishingHouseRequest = PublishingHouseParser.ParseByPublishingHouse(publishingHouseUrl);
            // Добавьте дополнительную проверку здесь
            if (publishingHouseRequest == null && !string.IsNullOrEmpty(publisherName))
            {
                publishingHouseRequest = new PublishingHouseRequest
                {
                    Name = publisherName
                };
            }
        }
        else
        {
            publishingHouseRequest = new PublishingHouseRequest
            {
                Name = publisherName
            };
        }

        var parseRequest = new ParseRequest
        {
            ArticlesRequest = articlesRequest,
            JournalRequest = journalRequest,
            PublishingHouseRequest = publishingHouseRequest
        };

        return parseRequest;
    }
}