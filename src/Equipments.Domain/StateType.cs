using System.Collections.Generic;

namespace Equipments.Domain
{
    /// <summary>
    /// Вид состояния
    /// </summary>
    public class StateType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование состояния (критический, плохой, хороший, отличный)
        /// </summary>
        public string Name { get; set; }

        public virtual IEnumerable<ComponentState> ComponentStates { get; set; }
        public virtual IEnumerable<EquipmentState> EquipmentStates { get; set; }
    }
}
