namespace Equipments.Web.Shared
{
    public class MeasureUnitCreateViewModel
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int SelectedDataTypeId { get; set; }
        public IList<DataTypeForSelectDto> DataTypes { get; set; }
    }
}
