namespace GridStatePOC.Models
{
    public class SaveRequestDto
    {
        public string PageKey { get; set; } = string.Empty;
        public string StateJson { get; set; } = string.Empty;
    }
}
