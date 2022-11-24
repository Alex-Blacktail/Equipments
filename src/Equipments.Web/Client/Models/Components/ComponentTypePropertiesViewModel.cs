namespace Equipments.Web.Client.Models.Components
{
    public class ComponentTypePropertiesViewModel
    {
        public IEnumerable<ComponentTypePropertyViewModel> ComponentTypeProperties { get; set; }

        public int ComponentTypeId { get; set; }
        public IEnumerable<SomeTypeDto> ComponentTypes { get; set; }
    }
}
