namespace SeeThatsAVerySharpScrapper.Models
{
    public class ScrapParameters
    {
        public List<string> Urls { get; set; } = new();
        public Dictionary<string, string> CssSelectors { get; set; } = new();
    }
}
