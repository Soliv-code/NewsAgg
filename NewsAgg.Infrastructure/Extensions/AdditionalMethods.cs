using HtmlAgilityPack;
using NewsAgg.Domain;
using System.Globalization;
using System.Xml.Linq;

namespace NewsAgg.Infrastructure.Additions
{
    public static class AdditionalMethods
    {
        public static bool IsLink(string requestLink)
        {
            return Uri.TryCreate(requestLink, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
        public static string RemoveHtmlTags(string requestLink)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(requestLink);
            return htmlDoc.DocumentNode.InnerText;
        }
        static DateTime pubDateToDateTIme(string pubDate)
        {
            // Потому что ни cnews, ни vc.ru, ни даже lenta.ru
            // не соблюдают спецификацию rss 2.0
            // Только хабр. По этому вынужденная мера - это обрезать жёстко до 25 символов.
            int defaultDateLength = 25;
            pubDate = pubDate.Substring(0, defaultDateLength).Trim();
            string parseFormat = "ddd, dd MMM yyyy HH:mm:ss";
            var res = DateTime.ParseExact(pubDate, parseFormat, CultureInfo.InvariantCulture);
            return res;
        }
        public static List<NewsFeed> ParsUrl(string requestLink)
        {
            XDocument doc = XDocument.Load(requestLink);
            var result = doc.Descendants("channel").Select(x => new
            {
                items = x.Elements("item").Select(y => new NewsFeed
                {
                    Title = (string?)y.Element("title") is not null ? RemoveHtmlTags((string?)y.Element("title")) : string.Empty,
                    Description = (string?)y.Element("description") is not null ? RemoveHtmlTags((string)y.Element("description")) : string.Empty,
                    Link = (string?)y.Element("link") ?? string.Empty,
                    PubDate = (string?)y.Element("pubDate") is not null ? pubDateToDateTIme((string?)y.Element("pubDate")) : new DateTime()
                }).ToList()
            }).FirstOrDefault();
            return result.items;
        }

    }
}
