using Equipments.Domain;

namespace Equipments.Web.Client.Models
{
    public class MeasureUnitCreateViewModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int SelectedDataTypeId { get; set; }
        public IEnumerable<DataType> DataTypes { get; set; }
    }
}
