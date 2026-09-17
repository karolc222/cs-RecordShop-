namespace RecordShop.Models
{
    public class Artist
    {
        public int ArtistId { set; get; }
        public string ArtistName { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public ICollection<Album> Albums { get; set; } = new List<Album>();
    }
}
