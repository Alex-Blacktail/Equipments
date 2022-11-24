using System;
using Equipments.Domain;
using Equipments.Domain.Components;
using Equipments.Infrastructure;
using Equipments.Web.Client.Models;
using Equipments.Web.Client.Models.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Web.Server.Controllers
{
    public class ComponentTypePropertiesController : ApiController
    {
        public ComponentTypePropertiesController(EquipmentsDbContext context) : base(context)
        {
        }

        [HttpGet("type/{id}")]
        public async Task<ActionResult<ComponentTypePropertiesViewModel>> Get(int id)
        {
            var model = new ComponentTypePropertiesViewModel();

            var typeItems = await _context.ComponentTypes.ToListAsync();

            if (typeItems.Count < 1) 
                return NotFound();

            if (typeItems.FirstOrDefault(x => x.Id == id) == null) 
                return NotFound();

            var items = await _context.ComponentTypeProperties
                .Where(x => x.ComponentTypeId == id)
                .Include(e => e.MeasureUnit)
                .AsNoTracking()
                .ToListAsync();

            var typePropertiesList = new List<ComponentTypePropertyViewModel>();
            foreach(var item in items)
            {
                typePropertiesList.Add(new ComponentTypePropertyViewModel
                {
                    Id = item.Id,
                    PropertyName = item.Name,
                    MeasureUnitName = item.MeasureUnit.Name
                });
            }

            model.ComponentTypeProperties = typePropertiesList;
            return Ok(model);
        }
        
        //[HttpGet("{id}")]
        //public async Task<MeasureUnit> GetFirstOrDefault(int id)
        //{
        //    var item = await _context.MeasureUnits
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(i => i.Id == id);

        //    return item;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">ÈÄ ComponentTypeProperty</param>
        /// <returns></returns>
        [HttpGet("for-update/{id}")]
        public async Task<ActionResult<ComponentTypePropertyUpdateViewModel>> GetForUpdate(int id)
        {
            var componentTypeProperty = await _context.ComponentTypeProperties.FirstOrDefaultAsync(x => x.Id == id);

            if (componentTypeProperty == null)
                return NotFound();

            var model = new ComponentTypePropertyUpdateViewModel();

            var componentTypeItems = await _context.ComponentTypes.ToListAsync();
            var componentTypes = new List<SomeTypeDto>();

            foreach (var type in componentTypeItems)
            {
                componentTypes.Add(new SomeTypeDto
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }

            var measureUnitsItems = await _context.MeasureUnits.ToListAsync();
            var measureUnits = new List<SomeTypeDto>();

            foreach (var mu in measureUnitsItems)
            {
                measureUnits.Add(new SomeTypeDto
                {
                    Id = mu.Id,
                    Name = mu.Name
                });
            }

            model.Id = componentTypeProperty.Id;
            model.PropertyName = componentTypeProperty.Name;
            model.ComponentTypeId = componentTypeProperty.ComponentTypeId;
            model.MeasureUnitId = componentTypeProperty.MeasureUnitId;

            model.ComponentTypes = componentTypes;
            model.MeasureUnits = measureUnits;

            return model;
        }

        [HttpPost]
        public async Task<ActionResult> Add(ComponentTypePropertyAddDto dto)
        {
            var item = new ComponentTypeProperty
            {
                Name = dto.PropertyName,
                MeasureUnitId = dto.MeasureUnitId,
                ComponentTypeId = dto.ComponentTypeId
            };

            await _context.ComponentTypeProperties.AddAsync(item);
            await _context.SaveChangesAsync();  

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ComponentTypePropertyAddDto model)
        {
            var item = await _context.ComponentTypeProperties.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null || model == null)
            {
                return BadRequest();
            }

            item.Name = model.PropertyName;
            item.MeasureUnitId = model.MeasureUnitId;
            item.ComponentTypeId = model.ComponentTypeId;

            _context.ComponentTypeProperties.Update(item);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _context.ComponentTypeProperties.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
                return BadRequest();

            try
            {
                _context.ComponentTypeProperties.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}
