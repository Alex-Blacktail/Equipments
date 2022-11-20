namespace Equipments.Web.Shared
{
    public class MeasureUnitCreateViewModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SelecterDataTypeId { get; set; }
        public IList<DataTypeForSelectDto> DataTypes { get; set; }
    }
}
