using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers.Parsers;

/// <summary>
/// Парсер для "статья в сборнике трудов конференции "
/// </summary>
public class СonferenceArticleParser
{
    public static (ArticlesRequest, string) ParseByСonferenceArticle(HtmlDocument htmlDoc)
    {
        ArticlesRequest article = new ArticlesRequest();
        // Проверка на капчу
        if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
        {
            throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы. Посетите https://elibrary.ru/");
        }
        
        // Используем XPath, чтобы найти элемент с заголовком
        HtmlNode titleNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='bigtext']");

        // Проверяем, найден ли узел с заголовком
        if (titleNode != null)
        {
            // Получаем текст из найденного узла
            article.Name = titleNode.InnerText;
        }
        else
        {
            throw new InvalidOperationException("Название не найден.");
        }
        
        //Год
        var yearNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(., 'Год издания:')]/font[3]");
        if (yearNode != null)
        {
            if (int.TryParse(yearNode.InnerText.Trim(), out int year))
            {
                article.Year = new DateTime(year, 1, 1);
            }
            else
            {
                throw new InvalidOperationException("Не удалось распознать год.");
            }
        }
        else
        {
            throw new InvalidOperationException("Элемент 'год' не найден.");
        }
        
        //Страницы
        var pageNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(., 'Страницы:')]/font");
        if (pageNode != null)
        {
            article.Pages = pageNode.InnerText;
        }
        else
        {
            throw new InvalidOperationException("Элемент страницы не найден.");
        }
        
        // Поиск информации о РИНЦ и ядре РИНЦ
        var rinchNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Входит в РИНЦ:')]/font");
        if (rinchNode != null)
        {
            article.Rsci = rinchNode.InnerText.Contains("да") ? "1" : "0";
        }
        else
        {
            throw new InvalidOperationException("Элемент 'Входит в РИНЦ' не найден.");
        }
        
        // Поиск информации о специальности ВАК
        var vakSpecialtyNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Специальность') and contains(text(), 'ВАК:')]/following-sibling::td/font/span[@id='rubric_vak']");
        if (vakSpecialtyNode != null)
        {
            article.Vak = vakSpecialtyNode.InnerText.Contains("да") ? "1" : "0";
        }
        else
        {
            throw new InvalidOperationException("Элемент 'Специальность ВАК' не найден.");
        }

        // Используем XPath, чтобы найти название конференции
        HtmlNode journalNode = htmlDoc.DocumentNode.SelectSingleNode("//td[@width='504']/a");
        string journalUrl;
        
        // Проверяем, найден ли узел с названием конференции
        if (journalNode != null)
        {
            // Получаем ссылку из найденного узла
            string journalLink = journalNode.GetAttributeValue("href", string.Empty);

            // Формируем полный URL, добавляя базовый URL к относительной ссылке
           journalUrl = "https://www.elibrary.ru/" + journalLink;
        }
        else
            throw new InvalidOperationException("Ссылка на сборник трудов не найдена.");
        
        
        article.JournalId = new Guid("7c8c3625-9afc-464b-87a2-1919a224bd21");
        // Возвращаем заполненный объект статьи
        return (article, journalUrl);
    }
}