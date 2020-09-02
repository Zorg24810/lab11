using System;
using System.Collections.Generic;
using System.Text;

namespace WebLabsV05.Entities
{
    public class AutoGroup
    {
        public int AutoGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Auto> Autos { get; set; }
    }
}
