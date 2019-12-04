using HtmlAgilityPack;
using MtvCoUkParser.DTO;
using MtvCoUkParser.Extensions;
using System.Linq;
using System.Threading.Tasks;

namespace MtvCoUkParser.Services.Implements
{
    public class TrackCreator : ITrackCreator
    {
        private readonly ICrudeData _crudeData;

        public TrackCreator(ICrudeData crudeData)
        {
            _crudeData = crudeData;
        }

        public async Task<Track> CreateTrack(HtmlNode articleNode, string chartId)
        {
            var track = new Track();

            var articleItems = articleNode.ChildNodes;
            var divItem = articleItems.FirstOrDefault(n => n.Name == "div");
            var divItems = divItem.ChildNodes;
            var figure = divItems.FirstOrDefault(n => n.Name == "figure");

            track.Rank = int.Parse(GetInerText(divItems.FirstOrDefault(t => t.Name == "span")));
            track.Name = GetInerText(divItems.FirstOrDefault(t => t.Name == "h3")).ToLower();
            track.Artist = GetInerText(divItems.FirstOrDefault(t => t.Name == "p")).ToLower();

            track.PromoImgUrl = GetImgUrl(figure.FirstChild, false);
            track.OverlayImgUrl = GetImgUrl(articleNode, true);

            track.Id = track.Name.ToPathId();

            //track.VideoUrl = await GetVideoUrl(chartId, track.Id);

            return track;
        }

        private string GetInerText(HtmlNode node)
        {
            string text = node.InnerText;
            return text;
        }

        private string GetImgUrl(HtmlNode imgNode, bool isOverlay)
        {
            if (!isOverlay) return imgNode.Attributes["src"].Value;
            else return imgNode.Attributes["data-overlay-image"].Value;
        }

        //private async Task<string> GetVideoUrl(string chartId, string playerId)
        //{
        //    var player = await _crudeData.ConcretePlayerAsync(chartId, playerId);

        //    var vmItems = player.ChildNodes;
        //    var vmItem = vmItems[1];

        //    string oldClass = "vimn-videoplayer-item";
        //    string newClass = "vimn-videoplayer-item pjs edge-player edge-desktop-platform edge-international-platform edge-gui-cc-active-state edge-gui-cc-disabled-state edge-gui-content-active-state edge-gui-pause-active-state edge-gui-active-state";

        //    vmItem.ReplaceClass(newClass, oldClass);

        //    var vmItemsChilds = vmItem.ChildNodes;
        //    var video = vmItemsChilds.FirstOrDefault(n => n.Name == "video");
        //    string src = video.Attributes["src"].Value;
        //    return src;

        //}
    }
}
