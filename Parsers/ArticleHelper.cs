using HtmlAgilityPack;
using Parsers.Parsers;
using ScientificActivities.Service.ModelRequest.Publication;

namespace Parsers;

public class ArticleHelper
{
    public static ArticlesRequest TypeOfJournal(string url)
    {
        HtmlWeb web = WebClientHelper.CreateWebClient();

        HtmlDocument htmlDoc = web.Load(url);
        
        // Проверка на капчу
        if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
        {
            throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы. Посетите https://elibrary.ru/");
        }
        
        var typeNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Тип:')]/font");
        if (typeNode != null)
        {
            string typeText = typeNode.InnerText;
            if (typeText.Contains("статья в сборнике трудов конференции"))
            {
                return СonferenceArticleParser.ParseByСonferenceArticle(url, htmlDoc);
            }
            else if (typeText.Contains("статья в журнале - научная статья"))
            {
                return ScientificArticleParser.ParseByScientificArticle(url, htmlDoc);
            }
        }
        
        throw new InvalidOperationException("Не удалось определить тип страницы.");
    }
}