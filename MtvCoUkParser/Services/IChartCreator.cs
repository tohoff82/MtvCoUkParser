using MtvCoUkParser.DTO;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services
{
    public interface IChartCreator
    {
        Task<Chart> CreateChartAsync(string chartId);
    }
}
