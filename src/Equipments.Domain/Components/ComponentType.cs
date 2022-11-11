using System.Collections.Generic;

namespace Equipments.Domain.Components
{
    /// <summary>
    /// Тип комплектующего
    /// </summary>
    public class ComponentType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование типа комплектующего (Кабель WGA, Кабель Ethernet)
        /// </summary>
        public string Name { get; set; }

        public virtual IEnumerable<ComponentTypeProperty> ComponentTypeProperties { get; set; }
        public virtual IEnumerable<Component> Components { get; set; }
    }
}
