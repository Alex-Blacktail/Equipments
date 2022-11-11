namespace Equipments.Domain.Inspections
{
    /// <summary>
    /// Факт осмотра комплектующего
    /// </summary>
    public class InspectionComponentFact
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Краткий комментарий
        /// </summary>
        public string ShortComment { get; set; }

        /// <summary>
        /// ИД Состояния комплектующего
        /// </summary>
        public int ComponentStateId { get; set; }

        /// <summary>
        /// ИД факта осмотра оргтехники
        /// </summary>
        public int InspectionEquipmentFactId { get; set; }

        public virtual ComponentState ComponentState { get; set; }
        public virtual InspectionEquipmentFact InspectionEquipmentFact { get; set; }
    }
}
