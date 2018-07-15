using InfoTrackBusinnes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace InfoTrackTest
{
    [TestClass]
    public class GoogleSearchTest
    {
        [TestMethod]
        public void TestGoogleSearchResult()
        {
            var googleSearch = new GoogleSearch(_ => File.ReadAllText(System.Environment.CurrentDirectory + @"\Mock\mock.html"));

            var result = googleSearch.Search("online title search", "www.infotrack.com.au");

            Assert.AreEqual("2", result);
        }
    }
}
