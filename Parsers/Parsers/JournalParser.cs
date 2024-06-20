using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;
using ScientificActivities.StorageEnums;

namespace Parsers.Parsers;

/// <summary>
/// Парсер для "ИНФОРМАЦИЯ О ЖУРНАЛЕ"
/// </summary>
public class JournalParser
{
    public static JournalRequest ParseByJournal(string url, HtmlDocument htmlDoc)
        {
            var journalRequest = new JournalRequest();
            
            
            // Создаем генератор случайных чисел
            Random random = new Random();
            
            // Генерируем случайное число в диапазоне от 8 до 20 (включительно)
            int randomSeconds = random.Next(8000, 17000);
            
            // Проверка на капчу
            if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
            {
                throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы.");
            }
            
            var node = htmlDoc.DocumentNode.SelectSingleNode("//td[@width='360']/font/b");

            // Проверяем, нашли ли узел, и выводим результат
            if (node != null)
            {
                journalRequest.Name = node.InnerText.Trim();
            }
            else
            {
                throw new InvalidOperationException("Название не найдено");
            }
            
            var tableRows = htmlDoc.DocumentNode.SelectNodes("//tr");
            bool isRINC = false;
            bool isVAK = false;

            foreach (var row in tableRows)
            {
                var cells = row.SelectNodes("td");
                if (cells != null && cells.Count > 1)
                {
                    var cellText = cells[0].InnerText.Trim();
                    var cellValue = cells[1].InnerText.Trim().ToLower();
                    if (cellText == "РИНЦ" && cellValue == "да")
                    {
                        isRINC = true;
                    }
                    else if (cellText == "Перечень ВАК" && cellValue == "да")
                    {
                        isVAK = true;
                    }
                }
            }

            // Определение статуса
            if (isVAK)
            {
                journalRequest.Status = "1"; // VAK
            }
            else if (isRINC)
            {
                journalRequest.Status = "0"; // RSCI
            }
            else
            {
                journalRequest.Status = "2"; // Tezis
            }

            // PublishingHouseId нужно будет установить отдельно, так как эта информация не парсится
            journalRequest.PublishingHouseId = new Guid("41f3a777-c2a8-45c3-9e47-efbfa70401fa");

            return journalRequest;
        }
}