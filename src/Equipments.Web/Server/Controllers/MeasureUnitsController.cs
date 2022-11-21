using Equipments.Domain;
using Equipments.Infrastructure;
using Equipments.Web.Client.Models; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Web.Server.Controllers
{
    public class MeasureUnitsController : ApiController
    {
        public MeasureUnitsController(EquipmentsDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> Get()
        {
            var items = await _context.MeasureUnits
                .Include(e => e.DataType)
                .AsNoTracking()
                .ToListAsync();

            var list = new List<MeasureUnitDto>();
            foreach (var item in items)
            {
                list.Add(new MeasureUnitDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    ShortName = item.ShortName,
                    DataTypeName = item.DataType.Name,
                });
            }
            return list;
        }

        [HttpGet("{id}")]
        public async Task<MeasureUnit> GetFirstOrDefault(int id)
        {
            var item = await _context.MeasureUnits
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            return item;
        }

        [HttpGet("for-update/{id}")]
        public async Task<MeasureUnitUpdateViewModel> GetForUpdate(int id)
        {  
            var item = await _context.MeasureUnits
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            var dataTypes = await _context.DataTypes
                .AsNoTracking()
                .ToListAsync();

            var result = new MeasureUnitUpdateViewModel
            {
                Id = item.Id,
                Name = item.Name,
                ShortName = item.ShortName,
                SelectedDataTypeId = item.DataTypeId,
                DataTypes = dataTypes
            };

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Add(MeasureUnitCreateDto model)
        {
            var item = new MeasureUnit
            {
                Name = model.Name,
                ShortName = model.ShortName,
                DataTypeId = model.DataTypeId
            };
            await _context.MeasureUnits.AddAsync(item);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, MeasureUnitUpdateDto model)
        {
            var item = await _context.MeasureUnits.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null || model == null)
            {
                return BadRequest();
            }

            item.Name = model.Name;
            item.ShortName = model.ShortName;
            item.DataTypeId = model.DataTypeId;

            _context.MeasureUnits.Update(item);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.MeasureUnits.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return BadRequest();

            _context.MeasureUnits.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
