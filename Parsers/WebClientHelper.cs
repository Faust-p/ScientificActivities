using System.Net;
using HtmlAgilityPack;

namespace Parsers;

public class WebClientHelper
{
    public static HtmlWeb CreateWebClient()
    {
        HtmlWeb web = new HtmlWeb();

        web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
        web.PreRequest += request =>
        {
            request.CookieContainer = new CookieContainer();

            request.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers["Accept-Encoding"] = "gzip, deflate, br";
            request.Headers["Accept-Language"] = "en-US,en;q=0.5";
            request.Headers["Connection"] = "keep-alive";
            request.Headers["Upgrade-Insecure-Requests"] = "1";
            request.Headers["Referer"] = "https://developer.mozilla.org/ru/docs/Web/JavaScript";
            request.Headers["Cache-Control"] = "max-age=0";
            request.Headers["DNT"] = "1";
            request.Headers["TE"] = "Trailers";

            var cookie = new Cookie("example_cookie_name", "example_cookie_value", "/", "example.com");
            request.CookieContainer.Add(cookie);

            return true;
        };

        return web;
    }
}