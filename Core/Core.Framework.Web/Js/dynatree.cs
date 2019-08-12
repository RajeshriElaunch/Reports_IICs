using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Framework.Web.Js
{
    public class dynatree
    {

        public dynatree(bool IsFolder)
        {
            if (IsFolder)
            {
                children = new List<dynatree>();
                isFolder = true;
            }
        }

        public string title { get; set; }
        public string tooltip { get; set; }
        public bool select { get; set; }
        public bool isFolder { get; set; }
        public bool activate { get; set; }

        public bool hideCheckbox { get; set; }
        public bool unselectable { get; set; }
        public bool expand { get; set; }
        
        
        public string key { get; set; }

        public List<dynatree> children { get; set; }
    }
}
