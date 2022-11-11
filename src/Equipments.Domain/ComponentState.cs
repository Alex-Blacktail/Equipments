using System.Collections.Generic;
using Equipments.Domain.Components;
using Equipments.Domain.Inspections;

namespace Equipments.Domain
{
    /// <summary>
    /// Статус-состояние конкретного комплектующего (TODO)
    /// </summary>
    public class ComponentState
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
        /// ИД Комплектующего
        /// </summary>
        public int ComponentId { get; set; }

        public virtual StateType StateType { get; set; }
        public virtual Component Component { get; set; }

        public virtual IEnumerable<InspectionComponentFact> InspectionComponentFacts { get; set; }
    }
}
