namespace Equipments.Domain.Components
{
    /// <summary>
    /// Характеристика конкретного комплектующего
    /// </summary>
    public class ComponentProperty
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Строковое поле данных
        /// </summary>
        public string? StringValue { get; set; }

        /// <summary>
        /// Вещественное поле данных
        /// </summary>
        public double? DoubleValue { get; set; }

        /// <summary>
        /// Целочисленное поле данных
        /// </summary>
        public int? IntValue { get; set; }

        /// <summary>
        /// ИД характеристики типа комплектующего
        /// </summary>
        public int ComponentTypePropertyId { get; set; }

        /// <summary>
        /// ИД комплектующего
        /// </summary>
        public int ComponentId { get; set; }

        public virtual ComponentTypeProperty ComponentTypeProperty { get; set; }
        public virtual Component Component { get; set; }

    }
}
