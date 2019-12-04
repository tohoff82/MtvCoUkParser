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
            => Injector.Startup();

        public async Task<Dictionary<string, string>> GetChartNamesAsync()
            => await Injector.Provider.GetService<INameCreatortor>()
                        .GetChartNamesAsync();

        public async Task<Chart> GetChartAsync(string chartId)
            => await Injector.Provider.GetService<IChartCreator>()
                        .CreateChartAsync(chartId);
    }
}
