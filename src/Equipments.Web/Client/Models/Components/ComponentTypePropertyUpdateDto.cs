namespace Equipments.Web.Client.Models.Components
{
    public class ComponentTypePropertyUpdateDto
    {
        public int Id { get; set; }
        public string PropertyName { get; set; }

        public int MeasureUnitId { get; set; }
        public int ComponentTypeId { get; set; }
    }
}
