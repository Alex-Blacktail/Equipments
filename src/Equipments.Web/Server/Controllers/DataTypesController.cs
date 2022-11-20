using Equipments.Domain;
using Equipments.Infrastructure;
using Equipments.Web.Shared;
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
        public async Task<IEnumerable<DataType>> GetDataTypes() 
        {
            var dataTypes = await _context.DataTypes
                .AsNoTracking()
                .ToListAsync();

            return dataTypes;
        }

        [HttpGet("{id}")]
        public async Task<DataType> GetDataType(int id)
        {
            var item = await _context.DataTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);
            return item;
        }

        [HttpPost]
        public async Task<IActionResult> AddDataType(DataTypeDto dataTypeDto)
        {
            var dataType = new DataType
            {
                Name = dataTypeDto.Name,
                CodeName = dataTypeDto.CodeName
            };
            await _context.DataTypes.AddAsync(dataType);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataType(int id, DataType item)
        {
            if (item == null || (item.Id != id))
            {
                return BadRequest();
            }

            _context.DataTypes.Update(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataType(int id)
        {
            var item = await _context.DataTypes.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return BadRequest();

            _context.DataTypes.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
