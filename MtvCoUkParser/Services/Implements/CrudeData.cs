using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services.Implements
{
    public class CrudeData : ICrudeData
    {
        private HtmlWeb htmlWeb;
        private const string chartsBaseUri = "http://www.mtv.co.uk/music/charts/";

        public  CrudeData()
        {
            htmlWeb = new HtmlWeb();
        }

        public async Task<IEnumerable<HtmlNode>> GetChartTitlesAsync()
        {
            var titles = new List<HtmlNode>();
            var charts = await ChartsAsync();

            foreach (var chart in charts)
            {
                titles.Add(chart.ChildNodes.FirstOrDefault(n => n.Name == "h2"));
            }
            return titles;
        }

        public async Task<HtmlNodeCollection> ConcreteChartAsync(string chartId)
        {
            var dom = await htmlWeb.LoadFromWebAsync(string.Concat(chartsBaseUri, chartId));
            return dom.DocumentNode.SelectNodes("//article");
        }

        private async Task<IEnumerable<HtmlNode>> ChartsAsync()
        {
            var dom = await htmlWeb.LoadFromWebAsync(chartsBaseUri);
            var reg = dom.DocumentNode.SelectSingleNode("//div[@class='region-inner ']");
            var divs = reg.ChildNodes.Where(n => n.Name == "div");
            var pane = divs.Where(n => n.Attributes["class"].Value.Contains("pane-vimn-listing"));
            return pane;                    
        }
    }
}
