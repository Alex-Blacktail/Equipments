using System;
using System.Collections.Generic;
using Equipments.Domain.Equipments;

namespace Equipments.Domain.Components
{
    /// <summary>
    /// Комплектующее
    /// </summary>
    public class Component
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

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
        /// ИД типа комплектующего
        /// </summary>
        public int ComponentTypeId { get; set; }

        /// <summary>
        /// ИД оргтехники, если комплектующее относится к ней
        /// </summary>
        public int? EquipmentId { get; set; }

        public virtual ComponentType ComponentType { get; set; }
        public virtual Equipment Equipment { get; set; }

        public virtual IEnumerable<ComponentProperty> ComponentProperties { get; set; }
        public virtual ComponentState ComponentState { get; set; }
    }
}
