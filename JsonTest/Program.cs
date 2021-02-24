using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n------------ test1");
            Test1();
            Console.WriteLine("\n------------ test2");
            Test2();
            Console.WriteLine("\n------------ test3");
            Test3();
            Console.WriteLine("\n------------ test4");
            Test4();
            Console.WriteLine("\n------------ test5");
            Test5();
            Console.WriteLine("\n------------ test6");
            Test6();
        }
        static void Test1()
        {
            string errorstring = @"
                {
	                ""error"": {
		                ""code"": ""0_code"",
		                ""message"": ""0_message"",
		                ""innererror"": {
			                ""message"": ""1_message"",
			                ""type"": ""1_type"",
			                ""stacktrace"": ""1_stacktrace""
		                }
	                }
                }
                ";
            IDictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorstring);

            AdminApiError error = JsonConvert.DeserializeObject<AdminApiError>(responseDict["error"].ToString());
            Console.WriteLine(error.Code);
            Console.WriteLine(error.Message);
            Console.WriteLine(error.InnerError?.Message);
            Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine(error.InnerError?.StackTrace);
            Console.WriteLine(error.InnerError?.InternalException?.Message);
            Console.WriteLine(error.InnerError?.InternalException?.Type);
            Console.WriteLine(error.InnerError?.InternalException?.StackTrace);
        }

        static void Test2()
        {
            string errorstring = @"
                {
	                ""error"": {
		                ""code"": ""0_code"",
		                ""message"": ""0_message"",
		                ""innererror"": {
			                ""message"": ""1_message"",
			                ""type"": ""1_type"",
			                ""stacktrace"": ""1_stacktrace"",
                            ""internalexception"":{
			                    ""message"": ""2_message"",
			                    ""type"": ""2_type"",
			                    ""stacktrace"": ""2_stacktrace""
                            }
		                }
	                }
                }
                ";
            IDictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorstring);

            AdminApiError error = JsonConvert.DeserializeObject<AdminApiError>(responseDict["error"].ToString());
            Console.WriteLine(error.Code);
            Console.WriteLine(error.Message);
            Console.WriteLine(error.InnerError?.Message);
            Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine(error.InnerError?.StackTrace);
            Console.WriteLine(error.InnerError?.InternalException?.Message);
            Console.WriteLine(error.InnerError?.InternalException?.Type);
            Console.WriteLine(error.InnerError?.InternalException?.StackTrace);

        }

        static void Test3()
        {
            // standard exception
            string errorstring = @"
                {
	                ""error"": {
		                ""code"": ""0_code"",
                        ""message"": ""0_message"",
		                ""innererror"": {
			                ""message"": ""1_message"",
			                ""type"": ""1_type"",
			                ""stacktrace"": ""1_stacktrace"",
                            ""internalexception"":{
			                    ""message"": ""2_message"",
			                    ""type"": ""2_type"",
			                    ""stacktrace"": ""2_stacktrace""
                            }
		                }
	                }
                }
                ";
            IDictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorstring);

            AdminApiError error = JsonConvert.DeserializeObject<AdminApiError>(responseDict["error"].ToString());
            Console.WriteLine(error.Code);
            Console.WriteLine(error.Message);
            Console.WriteLine(error.InnerError?.Message);
            Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine(error.InnerError?.StackTrace);
            Console.WriteLine(error.InnerError?.InternalException?.Message);
            Console.WriteLine(error.InnerError?.InternalException?.Type);
            Console.WriteLine(error.InnerError?.InternalException?.StackTrace);
            Exception ex = new Exception(error.InnerError?.Message ?? error.Message, error.InnerError?.InternalException);
        }
        static void Test4()
        {
            string errorstring = @"
                {
	                ""error"": {
		                ""code"": ""0_code"",
		                ""message"": ""0_message""
	                }
                }
                ";
            IDictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorstring);

            AdminApiError error = JsonConvert.DeserializeObject<AdminApiError>(responseDict["error"].ToString());
            Console.WriteLine(error.Code);
            Console.WriteLine(error.Message);
            Console.WriteLine(error.InnerError?.Message);
            Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine(error.InnerError?.StackTrace);
            Console.WriteLine(error.InnerError?.InternalException?.Message);
            Console.WriteLine(error.InnerError?.InternalException?.Type);
            Console.WriteLine(error.InnerError?.InternalException?.StackTrace);

        }

        static void Test5()
        {
            string errorstring = @"
                {
	                ""error"": {
		                ""code"": ""0_code"",
		                ""message"": ""0_message"",
		                ""details"": [
                            {
                                ""code"": ""1_detail_1_code"",
				                ""target"": ""1_detail_1_target"",
				                ""message"": ""1_detail_1_message""
                            }
		                ],
		                ""innererror"": {
			                ""message"": ""1_message"",
			                ""type"": ""1_type"",
			                ""stacktrace"": ""1_stacktrace"",
                            ""internalexception"":{
			                    ""message"": ""2_message"",
			                    ""type"": ""2_type"",
			                    ""stacktrace"": ""2_stacktrace""
                            }
		                }
	                }
                }
                ";
            IDictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorstring);

            AdminApiError error = JsonConvert.DeserializeObject<AdminApiError>(responseDict["error"].ToString());
            Console.WriteLine(error.Code);
            Console.WriteLine(error.Message);
            Console.WriteLine(error.InnerError?.Message);
            Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine(error.InnerError?.StackTrace);
            Console.WriteLine(error.InnerError?.InternalException?.Message);
            Console.WriteLine(error.InnerError?.InternalException?.Type);
            Console.WriteLine(error.InnerError?.InternalException?.StackTrace);

        }

        static void Test6()
        {
            string errorstring = @"
               {
	            ""error"": {
		            ""code"": ""InternalServerError"",
		            ""message"": ""Error executing cmdlet"",
		            ""details"": [
			            {
				            ""code"": ""Client"",
				            ""target"": """",
				            ""message"": ""Ex6F9304|Microsoft.Exchange.Configuration.Tasks.ManagementObjectNotFoundException|The operation couldn't be performed because object 'user2@jichen0107d.com' couldn't be found on 'EXHV-1242.EXHV-1242dom.extest.microsoft.com'.""
			            }
		            ],
		            ""innererror"": {
			            ""message"": ""Error executingcmdlet"",
			            ""type"": ""Microsoft.Exchange.Admin.OData.Core.ODataServiceException"",
			            ""stacktrace"": "" 357""
		            }
	            }
            }
                ";
            IDictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorstring);

            AdminApiError error = JsonConvert.DeserializeObject<AdminApiError>(responseDict["error"].ToString());
            Console.WriteLine(error.Code);
            Console.WriteLine(error.Message);
            Console.WriteLine(error.InnerError?.Message);
            Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine(error.InnerError?.StackTrace);
            Console.WriteLine(error.InnerError?.InternalException?.Message);
            Console.WriteLine(error.InnerError?.InternalException?.Type);
            Console.WriteLine(error.InnerError?.InternalException?.StackTrace);

        }
    }
}
