namespace filmsRESTapi
{
    public class Films
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = "No description";
        public int Rating { get; set; }
    }
}
