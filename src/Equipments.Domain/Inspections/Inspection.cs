using System;
using System.Collections.Generic;

namespace Equipments.Domain.Inspections
{
    /// <summary>
    /// Осмотр
    /// </summary>
    public class Inspection
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата осмотра
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Комментарий к осмотру
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// ИД вида осмотра
        /// </summary>
        public int InspectionTypeId { get; set; }

        public virtual InspectionType InspectionType { get; set; }

        public virtual IEnumerable<InspectionEquipmentFact> InspectionEquipmentFacts { get; set; }
    }
}
