using System.Collections.Generic;

namespace Equipments.Domain.Equipments
{
    /// <summary>
    /// Характеристика типа оргтехники
    /// </summary>
    public class EquipmentTypeProperty
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование (Объем оперативной памяти, максимальный формат печати)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ИД типа оргтехники
        /// </summary>
        public int EquipmentTypeId { get; set; }

        /// <summary>
        /// ИД единицы измерения
        /// </summary>
        public int MeasureUnitId { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }

        public virtual IEnumerable<EquipmentProperty> EquipmentProperties { get; set; }
    }
}