using System.Collections.Generic;

namespace Equipments.Domain
{
    /// <summary>
    /// Тип данных
    /// </summary>
    public class DataType
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование (строка, целое число)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Кодовое название (string, int)
        /// </summary>
        public string CodeName { get; set; }

        public virtual IEnumerable<MeasureUnit> MeasureUnits { get; set; }
    }
}
