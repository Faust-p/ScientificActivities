using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers.Parsers;

/// <summary>
/// Парсер для "ИНФОРМАЦИЯ ОБ ИЗДАНИИ"
/// </summary>
public class PublicationInformationParser
{
    public static JournalRequest ParseByPublicationInformation(string url, HtmlDocument htmlDoc)
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
        if (rinchNode != null && rinchNode.InnerText.Trim().Equals("Да", StringComparison.OrdinalIgnoreCase))
        {
            journalRequest.Status = "0";
        }

        // Поиск информации о ВАК
        var vakSpecialtyNode = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Перечень ВАК РФ:')]/font");
        if (vakSpecialtyNode != null && vakSpecialtyNode.InnerText.Trim().Equals("Да", StringComparison.OrdinalIgnoreCase))
        {
            journalRequest.Status = "1";
        }

        // Генерация случайного PublishingHouseId
        journalRequest.PublishingHouseId = new Guid("41f3a777-c2a8-45c3-9e47-efbfa70401fa");

        return journalRequest;
    }
}