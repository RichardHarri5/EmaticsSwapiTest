namespace EmaticsSwapiTest.Models
{
    public record Film
    {
        public string Title { get; set; }
        public int Episode_Id { get; set; }
        public string Opening_Crawl { get; set; }
        public DateTime Release_Date { get; set; }
        public string[] Characters { get; set; }
        public string[] Planets { get; set; }
        public string Url { get; set; }
    }

}
