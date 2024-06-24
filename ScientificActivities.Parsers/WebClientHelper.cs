using System.Net;
using HtmlAgilityPack;

namespace ScientificActivities.Parsers
{
    public class WebClientHelper
    {
        private static readonly Random Random = new Random();

        public static HtmlWeb CreateWebClient()
        {
            var templates = new[]
            {
                (Func<HtmlWeb>)CreateTemplate1,
                CreateTemplate2,
                CreateTemplate3,
                CreateTemplate4,
                CreateTemplate5,
                CreateTemplate6,
                CreateTemplate7,
                CreateTemplate8,
                CreateTemplate9,
                CreateTemplate10,
                CreateTemplate11,
                CreateTemplate12
            };

            int index = Random.Next(templates.Length);
            return templates[index]();
        }

        private static HtmlWeb CreateTemplate1()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.5";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://developer.mozilla.org/ru/docs/Web/JavaScript";
                request.Headers["Cache-Control"] = "max-age=0";
                request.Headers["DNT"] = "1";
                request.Headers["TE"] = "Trailers";

                // Пример реальных куки
                var cookie1 = new Cookie("sessionid", "1234567890abcdef", "/", "example.com");
                var cookie2 = new Cookie("csrftoken", "abcdef1234567890", "/", "example.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate2()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.1.1 Safari/605.1.15";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.9";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.google.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";

                // Пример реальных куки
                var cookie1 = new Cookie("NID", "204=XYZ12345abcd", "/", "google.com");
                var cookie2 = new Cookie("SID", "sAbC1234DEF", "/", "google.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate3()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/92.0.4515.107 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.8";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.wikipedia.org";
                request.Headers["Cache-Control"] = "max-age=0";
                request.Headers["DNT"] = "1";
                request.Headers["TE"] = "Trailers";

                // Пример реальных куки
                var cookie1 = new Cookie("GeoIP", "US:CA:San_Francisco", "/", "wikipedia.org");
                var cookie2 = new Cookie("WMF-Last-Access", "30-Jun-2024", "/", "wikipedia.org");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate4()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; AS; rv:11.0) like Gecko";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate";
                request.Headers["Accept-Language"] = "en-US,en;q=0.7";
                request.Headers["Connection"] = "Keep-Alive";
                request.Headers["Referer"] = "https://www.bing.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["DNT"] = "1";
                request.Headers["TE"] = "Trailers";

                // Пример реальных куки
                var cookie1 = new Cookie("MUID", "abcdef1234567890abcdef1234567890", "/", "bing.com");
                var cookie2 = new Cookie("SRCHD", "AF=NOFORM", "/", "bing.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate5()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.190 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.6";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.reddit.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["DNT"] = "1";
                request.Headers["TE"] = "Trailers";

                // Пример реальных куки
                var cookie1 = new Cookie("reddit_session", "abc123def456ghi789", "/", "reddit.com");
                var cookie2 = new Cookie("token_v2", "abcdefg1234567", "/", "reddit.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate6()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 11_2_3) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.128 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.9";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.apple.com";
                request.Headers["Cache-Control"] = "max-age=0";
                request.Headers["DNT"] = "1";
                request.Headers["TE"] = "Trailers";

                // Пример реальных куки
                var cookie1 = new Cookie("ac", "1234567890abcdef", "/", "apple.com");
                var cookie2 = new Cookie("geo", "US", "/", "apple.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate7()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.9";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.yahoo.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";

                // Пример реальных куки
                var cookie1 = new Cookie("Y", "abcdef1234567890", "/", "yahoo.com");
                var cookie2 = new Cookie("T", "s1234567890abcdef", "/", "yahoo.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate8()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/94.0.4606.61 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.8";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.amazon.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";

                // Пример реальных куки
                var cookie1 = new Cookie("session-id", "abcdef1234567890abcdef", "/", "amazon.com");
                var cookie2 = new Cookie("session-token", "abcdef1234567890abcdef", "/", "amazon.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate9()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/95.0.4638.54 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.9";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.twitter.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";

                // Пример реальных куки
                var cookie1 = new Cookie("auth_token", "abcdef1234567890abcdef", "/", "twitter.com");
                var cookie2 = new Cookie("guest_id", "v1:abcdef1234567890", "/", "twitter.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate10()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.45 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.9";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.instagram.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";

                // Пример реальных куки
                var cookie1 = new Cookie("sessionid", "abcdef1234567890abcdef", "/", "instagram.com");
                var cookie2 = new Cookie("csrftoken", "abcdef1234567890abcdef", "/", "instagram.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate11()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.99 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.9";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.facebook.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";

                // Пример реальных куки
                var cookie1 = new Cookie("xs", "abcdef1234567890abcdef", "/", "facebook.com");
                var cookie2 = new Cookie("c_user", "abcdef1234567890", "/", "facebook.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }

        private static HtmlWeb CreateTemplate12()
        {
            HtmlWeb web = new HtmlWeb();

            web.UserAgent =
                "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36";
            web.PreRequest += request =>
            {
                request.CookieContainer = new CookieContainer();

                request.Headers["Accept"] =
                    "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Headers["Accept-Encoding"] = "gzip, deflate, br";
                request.Headers["Accept-Language"] = "en-US,en;q=0.9";
                request.Headers["Connection"] = "keep-alive";
                request.Headers["Upgrade-Insecure-Requests"] = "1";
                request.Headers["Referer"] = "https://www.linkedin.com";
                request.Headers["Cache-Control"] = "no-cache";
                request.Headers["Pragma"] = "no-cache";

                // Пример реальных куки
                var cookie1 = new Cookie("li_at", "abcdef1234567890abcdef", "/", "linkedin.com");
                var cookie2 = new Cookie("JSESSIONID", "ajax:abcdef1234567890abcdef", "/", "linkedin.com");
                request.CookieContainer.Add(cookie1);
                request.CookieContainer.Add(cookie2);

                return true;
            };

            return web;
        }
    }
}