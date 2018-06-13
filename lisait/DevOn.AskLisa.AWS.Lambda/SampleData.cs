using System;
using System.Collections.Generic;
using System.Text;

namespace DevOn.AskLisa.AWS.Lambda
{
    public class SampleData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public CategoryOfQuestion category { get; set; }
        public int Reliability { get; set; }
        public string Source { get; set; }
        public DateTime Date { get; set; }
    }
    public enum CategoryOfQuestion
    {
        Events = 1,
        Certification = 2,
        MoreDetail = 3,
        Explaination = 4,
        Others = 5,
        Journey = 6
    }
    public class Websites
    {
        public string WebsitesUrl { get; set; }
        public string XPath { get; set; }
    }

    public static class Data
    {
        public static Dictionary<CategoryOfQuestion, List<Websites>> websites = new Dictionary<CategoryOfQuestion, List<Websites>>()
        {
            { CategoryOfQuestion.Certification, new List<Websites>{ new Websites{ WebsitesUrl = "https://devopsinstitute.com/certifications/", XPath = "//*[@id='Content']/div/div/div/div[2]/div/div[3]/div/div/div/descendant-or-self::h4" }
                                                                    } },
            { CategoryOfQuestion.Events, new List<Websites>{ new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" }
                                                                    } },
            { CategoryOfQuestion.MoreDetail, new List<Websites>{ new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" }
                                                                    } },
            { CategoryOfQuestion.Explaination, new List<Websites>{ new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" }
                                                                    } },
            { CategoryOfQuestion.Others, new List<Websites>{ new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" },
                                                                    new Websites{ WebsitesUrl = string.Empty, XPath = "" }
                                                                    } },
            { CategoryOfQuestion.Journey, new List<Websites>{ new Websites { WebsitesUrl = "https://devopscube.com/skillsets-to-work-in-devops-environment/", XPath = "//*[@id='post-1131']/div[2]/blockquote/p" } } }
        };
    }
}
