using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers.Parsers;

/// <summary>
/// Парсер для "ИНФОРМАЦИЯ ОБ ИЗДАНИИ"
/// </summary>
public class PublicationInformationParser
{
    public static (JournalRequest, string? publisherUrl, string? publisherName) ParseByPublicationInformation(HtmlDocument htmlDoc)
    {
        var journalRequest = new JournalRequest();
        
        // Проверка на капчу
        if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
        {
            throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы. Посетите https://elibrary.ru/");
        }
        
        // Название
        var nameNode = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='bigtext']");
        if (nameNode == null)
        {
            throw new InvalidOperationException("Название не найдено.");
        }
        journalRequest.Name = nameNode.InnerText.Trim();
        
        // Поиск информации о РИНЦ
        var rinchNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'РИНЦ:')]/font");
        if (rinchNode != null)
        {
            var rinchValue = rinchNode.InnerText.Trim().ToLower();
            journalRequest.Rsci = (rinchValue == "да") ? "1" : "0";
        }

        // Поиск информации о ВАК
        var vakSpecialtyNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Перечень ВАК РФ:')]/font");
        if (vakSpecialtyNode != null)
        {
            var vakValue = vakSpecialtyNode.InnerText.Trim().ToLower();
            journalRequest.Vak = (vakValue == "да") ? "1" : "0";
        }

        // Поиск информации о ядре РИНЦ
        var rinchCoreNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Ядро РИНЦ:')]/font");
        if (rinchCoreNode != null)
        {
            var rinchCoreValue = rinchCoreNode.InnerText.Trim().ToLower();
            journalRequest.CoreRsci = (rinchCoreValue == "да") ? "1" : "0";
        }

        
        
        
        var tableNodes = htmlDoc.DocumentNode.SelectNodes("//table");
        string? publisherName = null;
        string? publisherUrl = null;

        foreach (var tableNode in tableNodes)
        {
            var hasPublisherLabel = tableNode.SelectSingleNode(".//font[contains(., 'ИЗДАТЕЛЬСТВО:')]");
            if (hasPublisherLabel != null)
            {
                var publisherNode = tableNode.SelectSingleNode(".//a[contains(@href, '/org_profile.asp')]");
                if (publisherNode != null)
                {
                    publisherName = publisherNode.InnerText.Trim();
                    Console.WriteLine("Имя издательства1" + publisherName);
                    publisherUrl = "https://elibrary.ru" + publisherNode.GetAttributeValue("href", string.Empty).Trim();
                }
                else
                {
                    // Ищем следующий элемент font после элемента с текстом "ИЗДАТЕЛЬСТВО:"
                    var publisherFontNode = hasPublisherLabel.SelectSingleNode("following::font[@color='#00008f']");
                    if (publisherFontNode != null)
                    {
                        publisherName = publisherFontNode.InnerText.Trim();
                        Console.WriteLine("Имя издательства2" + publisherName);
                    }
                }
                break;
            }
        }
        // Генерация случайного PublishingHouseId
        journalRequest.PublishingHouseId = new Guid("41f3a777-c2a8-45c3-9e47-efbfa70401fa");

        return (journalRequest, publisherUrl, publisherName);
    }
}