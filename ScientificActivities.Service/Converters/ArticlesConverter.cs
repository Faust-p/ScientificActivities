using ScientificActivities.Data.Models.Publication;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.StorageEnums;

namespace ScientificActivities.Service.Converters;

public static class ArticlesConverter
{
    public static Article ConverterArticlesRequest(ArticlesRequest articlesRequest, Journal journal)
    {
        var articlesDb = new Article(
            articlesRequest.Name,
            articlesRequest.Number,
            articlesRequest.Year,
            articlesRequest.Pages,
            (EnumRSCI)Enum.Parse(typeof(EnumRSCI), articlesRequest.Rsci, true),
            (EnumVAK)Enum.Parse(typeof(EnumVAK), articlesRequest.Vak, true),
            journal
        );
        return articlesDb;
    }
}