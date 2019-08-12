using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Framework
{
    public class DBException : Exception
    {
        public DBException(string Message)
            : base(Message)
        { }

        public DBException(string Message, Exception ex)
            : base(Message, ex)
        { }

        public DBException(Exception ex)
            : base(ex.Message, ex)
        { }
    }

    public class BizException : Exception
    {
        public BizException(string Message) : base(Message)
        {} 

        public BizException(string Message, Exception ex) : base(Message, ex)
        {}

        public BizException(Exception ex) : base(ex.Message, ex)
        {}
    }

    public class ValidateException : Exception
    {
        public ValidateException(string Message) : base(Message)
        { }
    }
}
