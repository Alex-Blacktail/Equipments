namespace Equipments.Web.Client.Models.Components
{
    public class ComponentTypePropertyAddViewModel
    {
        public string PropertyName { get; set; }

        public int MeasureUnitId { get; set; }
        public IEnumerable<SomeTypeDto> MeasureUnits { get; set; }

        public int ComponentTypeId { get; set; }
        public IEnumerable<SomeTypeDto> ComponentTypes { get; set; }
    }
}
