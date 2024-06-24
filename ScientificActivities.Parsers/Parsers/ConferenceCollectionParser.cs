using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers.Parsers;

/// <summary>
/// Парсер для "сборник трудов конференции"
/// </summary>
public class ConferenceCollectionParser
{
    public static (JournalRequest, string?, string? publisherName) ParseByConferenceCollection(HtmlDocument htmlDoc)
    {
        var journalRequest = new JournalRequest();
        // Создаем генератор случайных чисел
        Random random = new Random();
        
        
        if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
        {
            throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы. Посетите https://elibrary.ru/");
        }
        
        //Получаем название
        HtmlNode titleNode = htmlDoc.DocumentNode.SelectSingleNode("//p[@class='bigtext']");
        if (titleNode != null)
        {
            journalRequest.Name = titleNode.InnerText.Trim();
        }
        
        

        // Поиск информации о РИНЦ
        var rinchNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Входит в РИНЦ:')]/font");
        if (rinchNode != null && rinchNode.InnerText.Trim().Equals("Да", StringComparison.OrdinalIgnoreCase))
        {
            journalRequest.Status = "0";
        }

        // Поиск информации о специальности ВАК
        var vakSpecialtyNode = htmlDoc.DocumentNode.SelectSingleNode(
            "//td[contains(text(), 'Специальность') and contains(text(), 'ВАК:')]/following-sibling::td/font/span[@id='rubric_vak']");
        if (vakSpecialtyNode != null && vakSpecialtyNode.InnerText.Trim().Equals("Да", StringComparison.OrdinalIgnoreCase))
        {
            journalRequest.Status = "1";
        }
        
        // Поиск издательства с учетом различных структур HTML
        var publisherNode =
            htmlDoc.DocumentNode.SelectSingleNode(
                "//td[contains(text(), 'Издательство:')]/font | //td[contains(text(), 'Издательство:')]/a");
        string? publisherName = null;
        string? publisherUrl = null;
        if (publisherNode != null)
        {
            publisherName = publisherNode.InnerText.Trim();
            
            // Извлечение ссылки из атрибута title элемента <span>
            var spanNode = publisherNode.ParentNode;
            if (spanNode != null && spanNode.Attributes["title"] != null)
            {
                string title = spanNode.Attributes["title"].Value;
                // Регулярное выражение для поиска URL в атрибуте title
                var matches = System.Text.RegularExpressions.Regex.Matches(title, @"href=""([^""]+)""");
                foreach (System.Text.RegularExpressions.Match match in matches)
                {
                    string href = match.Groups[1].Value;
                    if (!string.IsNullOrEmpty(href))
                    {
                        publisherUrl = "https://elibrary.ru/" + href;
                    }
                }
            }

            // Если издательство найдено в элементе <a>, выводим ссылку на издательство
            var publisherLinkNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Издательство:')]/a");
            if (publisherLinkNode != null)
            {
                string href = publisherLinkNode.GetAttributeValue("href", string.Empty);
                if (!string.IsNullOrEmpty(href))
                {
                    publisherUrl = "https://elibrary.ru/" + href;
                }
            }
        }
        // Генерация случайного PublishingHouseId
        journalRequest.PublishingHouseId = new Guid("41f3a777-c2a8-45c3-9e47-efbfa70401fa");

        return (journalRequest, publisherUrl, publisherName);
    }
}