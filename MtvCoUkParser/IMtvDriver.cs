using MtvCoUkParser.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MtvCoUkParser
{
    public interface IMtvDriver
    {
        Task<Dictionary<string, string>> GetChartNamesAsync();
        Task<Chart> GetChartAsync(string chartId);
    }
}
