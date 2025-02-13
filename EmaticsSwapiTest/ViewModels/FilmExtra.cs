namespace EmaticsSwapiTest.ViewModels
{
    public class FilmExtra : FilmInfo
    {
        public string TextCrawl { get; set; }
        public PlanetInfo[] Planets{ get; set; }
        public PlanetExtra[] HomeWorlds { get; set; }
    }
}