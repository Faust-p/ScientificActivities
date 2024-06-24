using System.Text.RegularExpressions;
using HtmlAgilityPack;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers.Parsers;

/// <summary>
/// Парсер для "КАРТОЧКА  ИЗДАТЕЛЬСТВА"
/// </summary>
public class PublishingHouseParser
{
   public static PublishingHouseRequest? ParseByPublishingHouse(string url)
        {
            // Создаем объект HtmlWeb для загрузки HTML-кода страницы
            HtmlWeb web = WebClientHelper.CreateWebClient();
            
            HtmlDocument htmlDoc = web.Load(url);
            
            // Проверка на капчу
            if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
            {
                throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы. Посетите https://elibrary.ru/");
            }
            
            // Поиск элемента с текстом "КАРТОЧКА ИЗДАТЕЛЬСТВА"
            var cardNode = htmlDoc.DocumentNode.SelectSingleNode("//td/font/b[contains(text(), 'КАРТОЧКА') and contains(text(), 'ИЗДАТЕЛЬСТВА')]");
            
            if (cardNode == null)
            {
                return null;
            }
            
            // Парсинг данных о стране, регионе, городе с помощью регулярного выражения
            Dictionary<string, string> data = ExtractDataFromTable(htmlDoc);

            // Создание и заполнение объекта PublishingHouseRequest
            var publishingHouseRequest = new PublishingHouseRequest
            {
                Name = data.ContainsKey("Полное название") ? data["Полное название"] : string.Empty,
                Country = data.ContainsKey("Страна") ? data["Страна"] : string.Empty,
                City = data.ContainsKey("Город") ? data["Город"] : string.Empty
            };

            return publishingHouseRequest;
        }

        private static Dictionary<string, string> ExtractDataFromTable(HtmlDocument htmlDoc)
        {
            // Используйте регулярное выражение для извлечения значений
            MatchCollection matches = Regex.Matches(htmlDoc.DocumentNode.OuterHtml, @"<td[^>]*>(.*?)</td>");

            // Сохраните результаты в словаре
            Dictionary<string, string> data = new Dictionary<string, string>();
            int i = 0;
            foreach (Match match in matches)
            {
                if (i % 2 == 0)
                {
                    // Удаление HTML-тегов из ключа
                    string key = Regex.Replace(match.Groups[1].ToString().Trim(), @"<[^>]*>", "");
                    // Извлечение следующего значения
                    Match nextMatch = match.NextMatch();
                    string value = nextMatch.Groups[1].ToString().Trim();
                    // Удаление HTML-тегов из значения
                    value = Regex.Replace(value, @"<[^>]*>", "");

                    // Добавьте проверку на пустое значение
                    if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                    {
                        data[key] = value;
                    }
                }
                i++;
            }
            return data;
        }
}