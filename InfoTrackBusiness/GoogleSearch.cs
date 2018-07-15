using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfoTrackBusinnes
{
    public class GoogleSearch : ISearch
    {
        readonly Func<string, string> GetResult;
        const int MAX_RESULTS_NUMBER = 100;

        public GoogleSearch(Func<string, string> getResult)
        {
            GetResult = getResult;
        }

        public GoogleSearch()
        {
            GetResult = keywords => GetHtmlResult(keywords).GetAwaiter().GetResult();
        }

        public string Search(string keywords, string url)
        {
            var searchMatches = new List<string>();
            var resultIndex = 1;
            var htmlResult = GetResult(keywords);
            var matches = Regex.Matches(htmlResult, @"<div[^>]*class=""g"">(.+?)</div>");

            foreach (Match item in matches)
            {
                if (item.Value.Contains(url))
                {
                    searchMatches.Add(resultIndex.ToString());
                }

                resultIndex++;
            }

            return searchMatches.Any() ? string.Join(", ", searchMatches) : "0";
        }

        private async Task<string> GetHtmlResult(string keywords)
        {
            var client = new HttpClient();
            var requestUri = $"https://www.google.com.au/search?q={keywords}&num={MAX_RESULTS_NUMBER}";

            using (var responseMsg = await client.GetAsync(requestUri))
            {
                return await responseMsg.Content.ReadAsStringAsync();
            }
        }
    }
}
