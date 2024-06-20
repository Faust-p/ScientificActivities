using HtmlAgilityPack;
using ScientificActivities.Parsers.Parsers;
using ScientificActivities.Service.ModelRequest.Publication;

namespace ScientificActivities.Parsers;

public static class JournalHelper
{
    public static JournalRequest TypeOfJournal(string url)
    {
        HtmlWeb web = WebClientHelper.CreateWebClient();

        HtmlDocument htmlDoc = web.Load(url);
        
        // Проверка на капчу
        if (htmlDoc.DocumentNode.SelectSingleNode("//title[text()='Тест Тьюринга']") != null)
        {
            throw new InvalidOperationException("Необходимо пройти капчу для продолжения работы. Посетите https://elibrary.ru/");
        }
        
        //Проверка на тип
        var infoAboutJournal = htmlDoc.DocumentNode.SelectSingleNode("//font[b[contains(text(), 'ИНФОРМАЦИЯ О ЖУРНАЛЕ')]]");
        var infoAboutPublication = htmlDoc.DocumentNode.SelectSingleNode("//div[font/b[contains(text(), 'ИНФОРМАЦИЯ ОБ ИЗДАНИИ')]]");
        var infoAboutConference = htmlDoc.DocumentNode.SelectSingleNode("//td[contains(text(), 'Тип:')]/font");
        
        if (infoAboutJournal != null)
        {
            Console.WriteLine("Это страница с ИНФОРМАЦИЕЙ О ЖУРНАЛЕ.");
                    
            return JournalParser.ParseByJournal(url, htmlDoc);
        }
        else if (infoAboutPublication != null)
        {
            Console.WriteLine("Это страница с ИНФОРМАЦИЕЙ ОБ ИЗДАНИИ.");
                    
            return PublicationInformationParser.ParseByPublicationInformation(url, htmlDoc);
        }
        else if (infoAboutConference != null)
        {
            if (infoAboutConference.InnerText == "сборник трудов конференции")
            {
                Console.WriteLine("Это страница со сборником трудов конференции.");
                
                return ConferenceCollectionParser.ParseByConferenceCollection(url, htmlDoc);
            }
        }
           throw new InvalidOperationException("Не удалось определить тип страницы.");
    }
}