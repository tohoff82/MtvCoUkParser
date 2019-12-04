using System.Collections.Generic;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services
{
    public interface INameCreatortor
    {
        Task<IDictionary<string, string>> GetChartNamesAsync();
        Task<string> GetChartNameByChartId(string chartId);
    }
}
