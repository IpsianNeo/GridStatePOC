namespace GridStatePOC.Models
{
    public class GridState
    {
        public int Id { get; set; }
        public string UserName { get; set; }   // ties to server-side identity
        public string PageKey { get; set; }    // e.g. "CityGrid"
        public string StateJson { get; set; }  // full state as JSON
        public DateTime UpdatedAt { get; set; }
    }
}
