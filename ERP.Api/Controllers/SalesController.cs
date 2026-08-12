using ERP.Core.Entities;
using ERP.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERP.Api.Controllers;

/// <summary>
/// Controller para gestionar pedidos de ventas.
/// Propietaria: Eliannys Hernandez Guzman.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ErpDbContext _context;

    public SalesController(ErpDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// GET /api/sales/orders
    /// Obtiene la lista de todos los pedidos.
    /// </summary>
    [HttpGet("orders")]
    public async Task<ActionResult<List<PedidoDto>>> GetOrders()
    {
        var pedidos = await _context.Pedidos
            .OrderByDescending(p => p.FechaCreacion)
            .ToListAsync();

        return Ok(pedidos.Select(p => new PedidoDto
        {
            Id = p.Id,
            Numero = p.Numero,
            Cliente = p.Cliente,
            Fecha = p.Fecha,
            Estado = p.Estado,
            Total = p.Total,
            Observaciones = p.Observaciones,
            FechaCreacion = p.FechaCreacion
        }).ToList());
    }

    /// <summary>
    /// POST /api/sales/orders
    /// Crea un nuevo pedido.
    /// </summary>
    [HttpPost("orders")]
    public async Task<ActionResult<PedidoDto>> CreateOrder([FromBody] CreatePedidoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Cliente))
            return BadRequest("El cliente es requerido.");

        if (request.Total < 0)
            return BadRequest("El total no puede ser negativo.");

        var pedido = new Pedido
        {
            Numero = $"PED-{DateTime.UtcNow:yyyyMMddHHmmss}",
            Cliente = request.Cliente,
            Fecha = request.Fecha ?? DateTime.UtcNow,
            Estado = "Pendiente",
            Total = request.Total,
            Observaciones = request.Observaciones,
            FechaCreacion = DateTime.UtcNow
        };

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrders), new PedidoDto
        {
            Id = pedido.Id,
            Numero = pedido.Numero,
            Cliente = pedido.Cliente,
            Fecha = pedido.Fecha,
            Estado = pedido.Estado,
            Total = pedido.Total,
            Observaciones = pedido.Observaciones,
            FechaCreacion = pedido.FechaCreacion
        });
    }
}

/// <summary>
/// DTO para transferencia de datos de pedidos.
/// </summary>
public class PedidoDto
{
    public int Id { get; set; }
    public string Numero { get; set; } = string.Empty;
    public string Cliente { get; set; } = string.Empty;
    public DateTime Fecha { get; set; }
    public string Estado { get; set; } = string.Empty;
    public decimal Total { get; set; }
    public string? Observaciones { get; set; }
    public DateTime FechaCreacion { get; set; }
}

/// <summary>
/// Request para crear un nuevo pedido.
/// </summary>
public class CreatePedidoRequest
{
    public string Cliente { get; set; } = string.Empty;
    public DateTime? Fecha { get; set; }
    public decimal Total { get; set; }
    public string? Observaciones { get; set; }
}
