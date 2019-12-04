using HtmlAgilityPack;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services
{
    public interface ICrudeData
    {
        Task<IEnumerable<HtmlNode>> GetChartTitlesAsync();
        Task<HtmlNodeCollection> ConcreteChartAsync(string chartPath);
    }
}
