using System;
using System.Collections.Generic;
using Equipments.Domain.Components;

namespace Equipments.Domain.Equipments
{
    /// <summary>
    /// Оргтехника
    /// </summary>
    public class Equipment
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование модели
        /// </summary>
        public string ModelName { get; set; }

        /// <summary>
        /// Номер модели
        /// </summary>
        public string ModelNumber { get; set; }

        /// <summary>
        /// Инвентарный номер
        /// </summary>
        public string InventoryNumber { get; set; }

        /// <summary>
        /// Дата производства
        /// </summary>
        public DateTime ProductionDate { get; set; }

        /// <summary>
        /// Дата получения
        /// </summary>
        public DateTime GettingDate { get; set; }

        /// <summary>
        /// Дата ввода в эксплуатацию
        /// </summary>
        public DateTime? EntryDate { get; set; }

        /// <summary>
        /// ИД типа оргтехники
        /// </summary>
        public int EquipmentTypeId { get; set; }

        public virtual EquipmentType EquipmentType { get; set; }

        public virtual IEnumerable<Component> Components { get; set; }
        public virtual IEnumerable<EquipmentProperty> EquipmentProperties { get; set; }
        public virtual EquipmentState EquipmentState { get; set; }
    }
}
