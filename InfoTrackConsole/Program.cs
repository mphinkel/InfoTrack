using InfoTrackBusinnes;
using System;

namespace InfoTrackDevelopmentProject
{
    class Program
    {
        static void Main(string[] args)
        {
            ISearch googleSearch = new GoogleSearch();

            Console.WriteLine("Enter keywords for search:");
            var keywords = Console.ReadLine().Replace(" ", "+");

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Enter URL for result:");
            var url = Console.ReadLine();

            var result = googleSearch.Search(keywords, url);
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(result);
        }
    }
}
