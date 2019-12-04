using HtmlAgilityPack;
using MtvCoUkParser.DTO;
using MtvCoUkParser.Extensions;
using System.Linq;

namespace MtvCoUkParser.Services.Implements
{
    public class TrackCreator : ITrackCreator
    {
        private readonly ICrudeData _crudeData;

        public TrackCreator(ICrudeData crudeData)
        {
            _crudeData = crudeData;
        }

        public Track CreateTrack(HtmlNode articleNode, string chartId)
        {
            var divItems = articleNode.ChildNodes.FirstOrDefault(n => n.Name == "div").ChildNodes; ;
            var figure = divItems.FirstOrDefault(n => n.Name == "figure");

            var track = new Track
            {
                Id = GetInerText(divItems.FirstOrDefault(t => t.Name == "h3")).ToLower().ToPathId(),
                Rank = int.Parse(GetInerText(divItems.FirstOrDefault(t => t.Name == "span"))),
                Name = GetInerText(divItems.FirstOrDefault(t => t.Name == "h3")).ToLower(),
                Artist = GetInerText(divItems.FirstOrDefault(t => t.Name == "p")).ToLower(),

                PromoImgUrl = GetImgUrl(figure.FirstChild, false),
                OverlayImgUrl = GetImgUrl(articleNode, true)
            };

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
    }
}
