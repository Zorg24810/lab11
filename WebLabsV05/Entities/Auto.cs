using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebLabsV05.Entities
{
    public class Auto
    {
        [Key]
        public int AutoId { get; set; } // id Авто
        public string AutoName { get; set; } // Марка авто
        public string Description { get; set; } // год выпуска
        public int AutoCost { get; set; } // стоимость
        public string Image { get; set; } // имя файла изображения
                                          // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int AutoGroupId { get; set; }
        public AutoGroup Group { get; set; }
    }
}
