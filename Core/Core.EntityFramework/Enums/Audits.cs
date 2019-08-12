using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.EntityFramework
{
    public static class Audits
    {
        public enum TypeAction
        { 
            Create = 1,
            Update = 2,
            Delete = 3
        }
    }
}
