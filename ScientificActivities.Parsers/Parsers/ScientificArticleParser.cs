using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers.Parsers;

/// <summary>
/// Парсер для "статья в журнале - научная статья".
/// </summary>
public class ScientificArticleParser
{
    public static ArticlesRequest ParseByScientificArticle(string url, HtmlDocument htmlDoc)
    {
        ArticlesRequest article = new ArticlesRequest();

        // Проверка на капчу
        if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
        {
            throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы.");
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
        
        //Номер
        var issueNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(., 'Номер:')]/a");
        if (issueNode != null)
        {
            article.Number = issueNode.InnerText.Replace("&nbsp;", "");
        }
        else
        {
            throw new InvalidOperationException("Элемент номер не найден.");
        }
        
        //Год
        var fontNodes = htmlDoc.DocumentNode.SelectNodes("//td/font");
        string yearText = null;

        foreach (var node in fontNodes)
        {
            if (node.PreviousSibling != null && node.PreviousSibling.InnerText.Contains("Год:"))
            {
                yearText = node.InnerText.Trim();
                break;
            }
        }
        if (yearText != null)
        {
            if (int.TryParse(yearText, out int year))
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
        var pagesNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(., 'Страницы:')]/font");
        if (pagesNode != null)
        {
            article.Pages = pagesNode.InnerText;
        }
        else
        {
            throw new InvalidOperationException("Элемент страницы не найден.");
        }
        
        // Поиск информации о РИНЦ и ядре РИНЦ
        var rinchNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Входит в РИНЦ:')]/font");
        if (rinchNode != null)
        {
            article.Rsci = rinchNode.InnerText.Contains("Да") ? "1" : "0";
        }
        else
        {
            throw new InvalidOperationException("Элемент 'Входит в РИНЦ' не найден.");
        }
            
        // Поиск информации о специальности ВАК
        var vakSpecialtyNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Специальность') and contains(text(), 'ВАК:')]/following-sibling::td/font/span[@id='rubric_vak']");
        if (vakSpecialtyNode != null)
        {
            article.Vak = vakSpecialtyNode.InnerText.Contains("Да") ? "1" : "0";
        }
        else
        {
            throw new InvalidOperationException("Элемент 'Специальность ВАК' не найден.");
        }

        article.JournalId = new Guid("7c8c3625-9afc-464b-87a2-1919a224bd21");
        // Возвращаем заполненный объект статьи
        return article;
    }
}