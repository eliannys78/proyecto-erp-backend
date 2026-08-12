using Microsoft.AspNetCore.Mvc;

namespace ERP.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ErpController : ControllerBase
{
    [HttpGet("estado")]
    public IActionResult Estado()
    {
        return Ok(new
        {
            sistema = "ERP Empresarial",
            estado = "Operativo",
            version = "1.0.0"
        });
    }
}