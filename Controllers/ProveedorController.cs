using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend_autores.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProveedorController: ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Usuario autenticado");
    }

    [Authorize]
    [HttpPost]
    public IActionResult Create()
    {
        return Ok("Producto creado");
    }

}