using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace JsonTest
{
    internal class AdminApiError2
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


        [Serializable]
        internal class AdminApiErrorDetail2 : Exception, ISerializable
        {
            private string _message { get; set; }
            private string _type { get; set; }
            private string _stacktrace { get; set; }
            private AdminApiErrorDetail2 _adminapierrordetail2 { get; set; }

            public override string Message => _message;
            public string Type => _type;

            public override string StackTrace => _stacktrace;
            public new AdminApiErrorDetail2 InnerException => _adminapierrordetail2;
 
            public AdminApiErrorDetail2(SerializationInfo info, StreamingContext context)
            {
                if (info != null)
                {
                    foreach (SerializationEntry entry in info)
                    {
                        switch (entry.Name.ToLower())
                        {
                            case "message":
                                this._message = entry.Value.ToString();
                                break;
                            case "type":
                                _type = entry.Value.ToString();
                                break;
                            case "stacktrace":
                                _stacktrace = entry.Value.ToString();
                                break;
                            case "internalexception":
                                _adminapierrordetail2 = JsonConvert.DeserializeObject<AdminApiErrorDetail2>(entry.Value.ToString());
                                break;
                        }
                    }
                }
            }

            public override void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                base.GetObjectData(info, context);

                if (info != null)
                {
                    info.AddValue("message", this.Message);
                    info.AddValue("type", this.Message);
                    info.AddValue("stacktrace", this.Message);
                    info.AddValue("internalexception", this.InnerException);
                }
            }

        }

        public AdminApiErrorDetail2 InnerError { get; set; }

    }
}
