using System.Collections.Generic;

namespace Equipments.Domain.Inspections
{
    /// <summary>
    /// Факт осмотра оргтехники
    /// </summary>
    public class InspectionEquipmentFact
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Краткий комментарий
        /// </summary>
        public string? Comment { get; set; }

        /// <summary>
        /// ИД Состояния оргтехники
        /// </summary>
        public int EquipmentStateId { get; set; }

        /// <summary>
        /// ИД Осмотра
        /// </summary>
        public int InspectionId { get; set; }

        public virtual EquipmentState EquipmentState { get; set; }
        public virtual Inspection Inspection { get; set; }

        public virtual IEnumerable<InspectionComponentFact> InspectionComponentFacts { get; set; }
    }
}
