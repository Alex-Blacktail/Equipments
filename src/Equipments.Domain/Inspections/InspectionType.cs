using System.Collections.Generic;

namespace Equipments.Domain.Inspections
{
    /// <summary>
    /// Вид осмотра
    /// </summary>
    public class InspectionType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название (ежемесячный, внеплановый)
        /// </summary>
        public string Name { get; set; }

        public virtual IEnumerable<Inspection> Inspections { get; set; }
    }
}
