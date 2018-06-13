using System;
using System.Collections.Generic;
using System.Linq;
using ScrapySharp;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.Text.RegularExpressions;

namespace DevOn.AskLisa.AWS.Lambda
{
    public class WebScraping
    {
        public static List<SampleData> GetAllCertifications(CategoryOfQuestion category)
        {
            var browser = new ScrapingBrowser();
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;
            var websites = Data.websites.First(x => x.Key == category);

            var rawData = ScrapAllWebsites(browser, websites.Value, category);
            foreach (var data in rawData)
            {
                data.Description = "I found this List for you: \n " + data.Description;
            }
            return rawData;
        }

        public static List<SampleData> GetDevOnJourney(CategoryOfQuestion category)
        {
            var browser = new ScrapingBrowser();
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;
            var websites = Data.websites.First(x => x.Key == category);

            var rawData = ScrapAllWebsites(browser, websites.Value, category);
            foreach (var data in rawData)
            {
                data.Description =  data.Description + " \n Here at DevOn we have guides full of tutorials, definitions, best practices, and advice.";
            }
            return rawData;
        }

        public static List<SampleData> GetDevOpsJourney(CategoryOfQuestion category)
        {
            var browser = new ScrapingBrowser();
            browser.AllowAutoRedirect = true;
            browser.AllowMetaRedirect = true;
            var websites = Data.websites.First(x => x.Key == category);

            var rawData = ScrapAllWebsites(browser, websites.Value, category);
            foreach (var data in rawData)
            {
                data.Description = "I found this for you: \n " + data.Description;
            }
            return rawData;
        }

        public static List<SampleData> ScrapAllWebsites(ScrapingBrowser browser, List<Websites> websites, CategoryOfQuestion category)
        {
            var results = new List<SampleData>();
            foreach (var site in websites)
            {
                if (site.WebsitesUrl != null || site.WebsitesUrl != string.Empty)
                {
                    var pageResult = browser.NavigateToPage(new Uri(site.WebsitesUrl));
                    var titleNode = pageResult.Html.SelectNodes(site.XPath);
                    var innerText = string.Join("\n", titleNode.ToList().Select(x => x.InnerText));
                    innerText.Replace("®", "");
                    innerText.Replace("℠", "");
                    results.Add(new SampleData() { Description = innerText, Title = innerText.Substring(0, 20), category = category, Source = site.WebsitesUrl, Reliability = 1 });
                }
            }
            return results;
        }
    }
}
