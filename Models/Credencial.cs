namespace DRR_PRESENTATION.Models
{
    public class CredencialResponse
    {
        public string Status { get; set; } = string.Empty;
        public CredencialData Data { get; set; } = new();
    }

    public class CredencialData
    {
        public string User { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public DateTime DateUTC { get; set; }
    }
}
