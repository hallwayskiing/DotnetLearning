using PhoneCrawler.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace PhoneCrawler.crawler
{
    internal class Crawler
    {
        private static HttpClient httpClient = new HttpClient();

        private static async Task<List<string>>GetLinks(string keyword)
        {
            string searchUrl = $"https://www.bing.com/search?q={Uri.EscapeDataString(keyword)}";
            string html = await httpClient.GetStringAsync(searchUrl);

            // 正则表达式匹配搜索结果中的网页链接
            string linkPattern = @"<a href=""(http[^""]+)""";
            MatchCollection matches = Regex.Matches(html, linkPattern);

            List<string> links = new List<string>();
            foreach (Match match in matches)
            {
                links.Add(match.Groups[1].Value);
            }

            return links;
        }
        private static async Task<List<string>> GetPhoneNumbers(string link)
        {
            string html=await httpClient.GetStringAsync(link);

            //正则表达式匹配搜索结果中的手机号码
            string phoneNumberPattern = @"1[3456789]\d{9}";
            MatchCollection matches=Regex.Matches(html, phoneNumberPattern);

            List<string> numbers=new List<string>();
            foreach (Match match in matches)
            {
                numbers.Add(match.Value);
            }
            return numbers.Distinct().ToList();
        }

        //多线程异步获取所有链接中的电话号码
        public static async Task<List<PhoneInfo>> GetResults(string keyword)
        {
            var links=await GetLinks(keyword);
            List<PhoneInfo> results = new List<PhoneInfo>();

            var tasks=new List<Task>();
            links.ForEach(link =>
            {
                tasks.Add(Task.Run(async () =>
                {
                    List<string> numbers = await GetPhoneNumbers(link);
                    numbers.ForEach(number =>
                    {
                        if (results.Find(n=>n.PhoneNumber==number)==null)
                        {
                            PhoneInfo info = new();
                            info.PhoneNumber = number;
                            info.Urls.Add(link);
                            results.Add(info);
                        }
                        else
                        {
                            PhoneInfo info = results.Find(n => n.PhoneNumber == number)!;
                            info.Urls.Add(link);
                        }
                    });
                }));
            });
            await Task.WhenAll(tasks);
            return results;
        }
    }
}
