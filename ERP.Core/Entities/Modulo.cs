namespace ERP.Core.Entities;

public class Modulo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Codigo { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public string Version { get; set; } = "1.0.0";

    public bool Activo { get; set; } = true;

    public DateTime FechaInstalacion { get; set; } = DateTime.UtcNow;
}