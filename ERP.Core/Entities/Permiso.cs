namespace ERP.Core.Entities;

public class Permiso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public int RolId { get; set; }

    public Rol? Rol { get; set; }
}