namespace Equipments.Web.Shared
{
    public class MeasureUnitUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SelecterDataTypeId { get; set; }
        public IList<DataTypeForSelectDto> DataTypes { get; set; }
    }
}
