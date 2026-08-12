namespace ERP.Core.Entities;

public class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;

    public int RolId { get; set; }

    public Rol? Rol { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}