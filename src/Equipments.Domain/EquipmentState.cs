using System.Collections.Generic;
using Equipments.Domain.Equipments;
using Equipments.Domain.Inspections;

namespace Equipments.Domain
{
    /// <summary>
    /// Статус-состояние конкретной оргтехники (TODO)
    /// </summary>
    public class EquipmentState
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ИД Состояния
        /// </summary>
        public int StateTypeId { get; set; }

        /// <summary>
        /// ИД Оргтехники
        /// </summary>
        public int EquipmentId { get; set; }

        public virtual StateType StateType { get; set; }
        public virtual Equipment Equipment { get; set; }

        public virtual IEnumerable<InspectionEquipmentFact> InspectionEquipmentFacts { get; set; }
    }
}
