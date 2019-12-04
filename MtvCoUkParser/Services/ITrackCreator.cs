using HtmlAgilityPack;
using MtvCoUkParser.DTO;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services
{
    public interface ITrackCreator
    {
        Track CreateTrack(HtmlNode htmlNode, string chartId);
    }
}
