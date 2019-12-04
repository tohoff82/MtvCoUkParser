using MtvCoUkParser.DTO;
using MtvCoUkParser.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services.Implements
{
    public class ChartCreator : IChartCreator
    {
        private readonly ICrudeData _crudeData;
        private readonly ITrackCreator _trackCtor;
        private readonly INameCreatortor _nameCreator;

        public ChartCreator(ICrudeData crudeData, ITrackCreator trackCtor, INameCreatortor nameCreator)
        {
            _crudeData = crudeData;
            _trackCtor = trackCtor;
            _nameCreator = nameCreator;
        }

        public async Task<Chart> CreateChartAsync(string chartId)
        {
            string name = await _nameCreator.GetChartNameByChartId(chartId);

            var chart = new Chart
            {
                Id = chartId,
                Name = name,
                PlayList = new SortedDictionary<int, Track>()
            };

            var articles = await _crudeData.ConcreteChartAsync(chartId);

            foreach (var article in articles)
            {
                if (article.Attributes["class"].Value.Contains("playlist-item chart-item"))
                {
                    var track = await _trackCtor.CreateTrack(article, name.ToPathId(true));
                    chart.PlayList.Add(track.Rank, track);
                }
                else continue;
            }
            return chart;
        }
    }
}
