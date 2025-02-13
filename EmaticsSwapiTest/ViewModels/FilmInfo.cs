namespace EmaticsSwapiTest.ViewModels
{
    public class FilmInfo
    {
        public int EpisodeId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ReleaseDateFormatted
        {
            get
            {
                return ReleaseDate.ToShortDateString();
            }
        }
        public string FilmUrl { get; set; }
    }
}