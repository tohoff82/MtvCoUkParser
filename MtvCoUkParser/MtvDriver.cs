using MtvCoUkParser.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MtvCoUkParser.DTO;
using System.Collections.Generic;

namespace MtvCoUkParser
{
    public class MtvDriver : IMtvDriver
    {
        public MtvDriver()
            => Injection.Startup();

        public async Task<Dictionary<string, string>> GetChartNamesAsync()
            => await Injection.Provider.GetService<INameCreatortor>()
                        .GetChartNamesAsync();

        public async Task<Chart> GetChartAsync(string chartId)
            => await Injection.Provider.GetService<IChartCreator>()
                        .CreateChartAsync(chartId);
    }
}
