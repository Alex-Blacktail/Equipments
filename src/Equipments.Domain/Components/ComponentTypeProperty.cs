using System.Collections.Generic;

namespace Equipments.Domain.Components
{
    /// <summary>
    /// Характеристика типа комплектующего
    /// </summary>
    public class ComponentTypeProperty
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование (Длина кабеля, частота процессора)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ИД типа комплектующего
        /// </summary>
        public int ComponentTypeId { get; set; }

        /// <summary>
        /// ИД единицы измерения
        /// </summary>
        public int MeasureUnitId { get; set; }

        public virtual ComponentType ComponentType { get; set; }
        public virtual MeasureUnit MeasureUnit { get; set; }

        public virtual IEnumerable<ComponentProperty> ComponentProperties { get; set; }
    }
}