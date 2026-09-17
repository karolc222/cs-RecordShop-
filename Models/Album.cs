namespace RecordShop.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; } = string.Empty;
        public int ArtistId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Stock { get; set; }

        public Artist Artist { get; set; } = null!;
    }
}
