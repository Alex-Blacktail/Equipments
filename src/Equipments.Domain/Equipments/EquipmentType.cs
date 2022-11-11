using System.Collections.Generic;

namespace Equipments.Domain.Equipments
{
    /// <summary>
    /// Тип оргтехники
    /// </summary>
    public class EquipmentType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование типа оргтехники (принтеры, факсы, сканеры)
        /// </summary>
        public string Name { get; set; }

        public virtual IEnumerable<Equipment> Equipments { get; set; }
        public virtual IEnumerable<EquipmentTypeProperty> EquipmentTypeProperties { get; set; }
    }
}
