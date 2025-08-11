namespace DRR_PRESENTATION.Models;

public class Empresa
{
    public int EmpresaID { get; set; }  // ← coincide con "empresaID"
    public string RazonSocial { get; set; } = string.Empty;
    //public string Ruc { get; set; } = string.Empty;
    public string telefono { get; set; } = string.Empty;

    public string E_Mail { get; set; } = string.Empty;
    public string Logo { get; set; } = string.Empty;

    public List<Sucursal>? Sucursales { get; set; }
}

public class Sucursal
{
    public string? Domicilio { get; set; }
    public int CiudadId { get; set; }
    //public string Ciudad { get; set; }
    public string? Provincia { get; set; }
    public string? Pais { get; set; }
    // Agrega más propiedades si existen
}
