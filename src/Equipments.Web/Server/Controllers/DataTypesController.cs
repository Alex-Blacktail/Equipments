using System.Security.Claims;
using Equipments.Domain;
using Equipments.Infrastructure;
using Equipments.Web.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Web.Server.Controllers
{
    public class DataTypesController : ApiController
    {
        public DataTypesController(EquipmentsDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<DataType>> Get() 
        {
            var dataTypes = await _context.DataTypes
                .AsNoTracking()
                .ToListAsync();

            return dataTypes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DataType>> GetDataType(int id)
        {
            var item = await _context.DataTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            if(item == null) 
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> AddDataType(DataTypeDto dataTypeDto)
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
        public async Task<ActionResult> PutDataType(int id, DataTypeDto item)
        {
            var dataType = await _context.DataTypes.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null || dataType == null)
            {
                return BadRequest();
            }
            
            dataType.Name = item.Name;
            dataType.CodeName = item.CodeName;

            _context.DataTypes.Update(dataType);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDataType(int id)
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
