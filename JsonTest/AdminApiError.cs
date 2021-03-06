﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace JsonTest
{
    internal class AdminApiError
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }


        [Serializable]
        internal class AdminApiErrorDetail : Exception, ISerializable
        {
            public new string Message { get; set; }
            public string Type { get; set; }
            public new string StackTrace { get; set; }
            public new AdminApiErrorDetail InnerException { get; set; }
            public override string ToString()
            {
                return Message + "::" + StackTrace;
            }
            public AdminApiErrorDetail(SerializationInfo info, StreamingContext context)
            {
                if (info != null)
                {
                    foreach (SerializationEntry entry in info)
                    {
                        switch (entry.Name.ToLower())
                        {
                            case "message":
                                Message = entry.Value.ToString();
                                break;
                            case "type":
                                Type = entry.Value.ToString();
                                break;
                            case "stacktrace":
                                StackTrace = entry.Value.ToString();
                                break;
                            case "internalexception":
                                InnerException = JsonConvert.DeserializeObject<AdminApiErrorDetail>(entry.Value.ToString());
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

        public AdminApiErrorDetail InnerError { get; set; }

    }
}
