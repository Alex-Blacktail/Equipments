using Equipments.Domain;
using Equipments.Domain.Equipments;
using Equipments.Infrastructure;
using Equipments.Web.Client.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Web.Server.Controllers
{
    public class EquipmentTypesController : ApiController
    {
        public EquipmentTypesController(EquipmentsDbContext context) : base(context)
        {
        }

        [HttpGet]
        public async Task<IEnumerable<SomeTypeDto>> Get()
        {
            var items = await _context.EquipmentTypes
                .AsNoTracking()
                .ToListAsync();

            var list = new List<SomeTypeDto>();
            foreach (var item in items)
            {
                list.Add(new SomeTypeDto
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            return list;
        }

        [HttpGet("{id}")]
        public async Task<SomeTypeDto> GetFirstOrDefault(int id)
        {
            var item = await _context.EquipmentTypes
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.Id == id);

            var result = new SomeTypeDto
            {
                Id = item.Id,
                Name = item.Name
            };

            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Add(SomeTypeDto model)
        {
            var item = new EquipmentType
            {
                Name = model.Name,
            };
            await _context.EquipmentTypes.AddAsync(item);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, SomeTypeDto model)
        {
            var item = await _context.EquipmentTypes.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null || model == null)
            {
                return BadRequest();
            }

            item.Name = model.Name;

            _context.EquipmentTypes.Update(item);

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.EquipmentTypes.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return BadRequest();

            _context.EquipmentTypes.Remove(item);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
