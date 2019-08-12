using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Framework.Web.DTO
{
    public class WSResult
    {
        public bool HasError { get; set; }
        public string Message { get; set; }

        public void SetMessage(string Message, bool HasError)
        {
            this.Message = Message;
            this.HasError = HasError;
        }

    }
}
