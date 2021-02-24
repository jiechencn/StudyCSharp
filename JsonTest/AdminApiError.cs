using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace JsonTest
{
    class AdminApiError
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public class AdminApiErrorDetail : Exception
        {
            public new string Message { get; set; }
            public string Type { get; set; }
            public new string StackTrace { get; set; }
            public AdminApiErrorDetail InternalException { get; set; }
            public override string ToString()
            {
                return Message + "::" + StackTrace;
            }

        }

        public AdminApiErrorDetail InnerError { get; set; }

    }
}
