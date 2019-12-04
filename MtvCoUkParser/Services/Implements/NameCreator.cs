using MtvCoUkParser.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services.Implements
{
    public class NameCreator : INameCreatortor
    {
        private readonly ICrudeData _crudeData;

        public NameCreator(ICrudeData crudeData)
        {
            _crudeData = crudeData;
        }

        public async Task<Dictionary<string, string>> GetChartNamesAsync()
        {
            var names = new Dictionary<string, string>();
            var tn = await _crudeData.GetChartTitlesAsync();

            foreach (var t in tn)
            {
                string name = t.InnerText.ToLower();
                names.Add(name.ToPathId(), name);
            }

            return names;
        }

        public async Task<string> GetChartNameByChartId(string chartId)
        {
            var names = await GetChartNamesAsync();
            return names[chartId];
        }
    }
}
