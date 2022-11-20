using Equipments.Domain;
using Equipments.Infrastructure;
using Equipments.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Web.Server.Controllers
{
    internal class MeasureUnitsController : ApiController
    {
        public MeasureUnitsController(EquipmentsDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<MeasureUnitDto>> GetAll()
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
                .FirstOrDefaultAsync(i => i.Id == id);

            return item;
        }

        [HttpPost]
        public async Task<IActionResult> Add(MeasureUnitCreateViewModel model)
        {
            var item = new MeasureUnit
            {
                Name = model.Name,
                ShortName = model.ShortName,
                DataTypeId = model.SelectedDataTypeId
            };
            await _context.MeasureUnits.AddAsync(item);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, MeasureUnitUpdateViewModel model)
        {
            var item = await _context.MeasureUnits.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null || model == null)
            {
                return BadRequest();
            }

            item.Name = model.Name;
            item.ShortName = model.ShortName;
            item.DataTypeId = model.SelectedDataTypeId;

            _context.MeasureUnits.Update(item);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
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
