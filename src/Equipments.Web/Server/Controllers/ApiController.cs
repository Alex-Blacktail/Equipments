using Equipments.Infrastructure;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase
{
    protected readonly EquipmentsDbContext _context;

    public ApiController(EquipmentsDbContext context)
    {
        _context = context;
    }
}