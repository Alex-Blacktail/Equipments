using System.Collections.Generic;
using Equipments.Domain.Components;
using Equipments.Domain.Equipments;

namespace Equipments.Domain
{
    /// <summary>
    /// Единица измерения
    /// </summary>
    public class MeasureUnit
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование единицы измерения (Герц, сантиметр)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Краткое наименование единицы измерения (гц, см)
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// ИД типа данных
        /// </summary>
        public int DataTypeId { get; set; }

        public virtual DataType DataType { get; set; }

        public virtual IEnumerable<ComponentTypeProperty> ComponentTypeProperties { get; set; }
        public virtual IEnumerable<EquipmentTypeProperty> EquipmentTypeProperties { get; set; }
    }
}
