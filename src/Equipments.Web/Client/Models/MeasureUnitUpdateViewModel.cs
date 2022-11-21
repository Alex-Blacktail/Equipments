using Equipments.Domain;

namespace Equipments.Web.Client.Models
{
    public class MeasureUnitUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int SelectedDataTypeId { get; set; }
        public IEnumerable<DataType> DataTypes { get; set; }
    }
}
