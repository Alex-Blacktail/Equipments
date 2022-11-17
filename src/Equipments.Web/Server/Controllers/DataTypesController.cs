using Equipments.Domain;
using Equipments.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataTypesController : ControllerBase
    {
        private readonly EquipmentsDbContext _context;

        public DataTypesController(EquipmentsDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<DataType>> Get() 
        {
            var dataTypes = await _context.DataTypes.ToListAsync();
            return dataTypes;
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var dataTypes = await _context.DataTypes.ToListAsync();
            return Ok();
        }
    }
}
