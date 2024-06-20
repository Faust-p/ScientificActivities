using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;

namespace Parsers.Parsers;

/// <summary>
/// Парсер для "сборник трудов конференции"
/// </summary>
public class ConferenceCollectionParser
{
    public static JournalRequest ParseByConferenceCollection(string url, HtmlDocument htmlDoc)
    {
        var journalRequest = new JournalRequest();
        // Создаем генератор случайных чисел
        Random random = new Random();
        
        // Генерируем случайное число в диапазоне от 8 до 20 (включительно)
        int randomSeconds = random.Next(8000, 17000);
        
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

        // Генерация случайного PublishingHouseId
        journalRequest.PublishingHouseId = new Guid("41f3a777-c2a8-45c3-9e47-efbfa70401fa");

        return journalRequest;
    }
}