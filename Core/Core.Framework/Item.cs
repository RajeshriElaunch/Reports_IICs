using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Framework
{
    public class ItemDTO
    {
        public ItemDTO()
        { }

        public string Text { get; set; }
        public string Value { get; set; }
        public int IntValue { set { Value = value.ToString(); } }
        public bool IsDefault { get; set; }
        public string Group { get; set; }
        public string CssClass { get; set; }
        public string Subtext { get; set; }
    }
}
