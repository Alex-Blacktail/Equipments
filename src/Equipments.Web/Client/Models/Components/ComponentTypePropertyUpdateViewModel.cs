namespace Equipments.Web.Client.Models.Components
{
    public class ComponentTypePropertyUpdateViewModel
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }

        public int MeasureUnitId { get; set; }
        public IEnumerable<SomeTypeDto> MeasureUnits { get; set; }

        public int ComponentTypeId { get; set; }
        public IEnumerable<SomeTypeDto> ComponentTypes { get; set; }
    }
}
