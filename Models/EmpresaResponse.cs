namespace DRR_PRESENTATION.Models
{
    public class EmpresaResponse
    {
        public string Status { get; set; } = string.Empty;
        public List<Empresa> Data { get; set; } = new();
    }
}