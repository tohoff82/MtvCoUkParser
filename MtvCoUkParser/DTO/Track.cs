using System.Text;

namespace MtvCoUkParser.DTO
{
    public class Track
    {
        public string Id { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }

        public string Artist { get; set; }

        public string PromoImgUrl { get; set; }

        public string OverlayImgUrl { get; set; }

        // public string VideoUrl { get; set; }

        // public string Duration { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(Rank);
            sb.AppendFormat("{0}. {1} | {2}",Rank, Name, Artist);
            return sb.ToString();
        }
    }
}
