namespace Equipments.Domain.Equipments
{
    /// <summary>
    /// Характеристика конкретной оргтехники
    /// </summary>
    public class EquipmentProperty
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
        /// ИД характеристики типа оргтехники
        /// </summary>
        public int EquipmentTypePropertyId { get; set; }

        /// <summary>
        /// ИД оргтехники
        /// </summary>
        public int EquipmentId { get; set; }

        public virtual EquipmentTypeProperty EquipmentTypeProperty { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
