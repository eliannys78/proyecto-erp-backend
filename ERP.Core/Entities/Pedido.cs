namespace ERP.Core.Entities;

/// <summary>
/// Representa un pedido de ventas en el ERP.
/// Propietaria: Eliannys Hernandez Guzman.
/// </summary>
public class Pedido
{
    public int Id { get; set; }

    /// <summary>
    /// Número o código del pedido (ej: "PED-001").
    /// </summary>
    public string Numero { get; set; } = string.Empty;

    /// <summary>
    /// Nombre del cliente.
    /// </summary>
    public string Cliente { get; set; } = string.Empty;

    /// <summary>
    /// Fecha en que se creó el pedido.
    /// </summary>
    public DateTime Fecha { get; set; }

    /// <summary>
    /// Estado del pedido: Pendiente, Confirmado, Enviado, Entregado, Cancelado.
    /// </summary>
    public string Estado { get; set; } = "Pendiente";

    /// <summary>
    /// Total del pedido.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Observaciones o comentarios sobre el pedido.
    /// </summary>
    public string? Observaciones { get; set; }

    /// <summary>
    /// Fecha de creación del registro.
    /// </summary>
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
