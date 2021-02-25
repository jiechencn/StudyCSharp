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
            Console.WriteLine("\n------------ test7");
            Test7();

            Console.WriteLine("\n------------ test8");
            Test8();
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
            Console.WriteLine(error.InnerError?.InnerException?.Message);
            Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine(error.InnerError?.InnerException?.StackTrace);
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
            Console.WriteLine(error.InnerError?.InnerException?.Message);
            Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine(error.InnerError?.InnerException?.StackTrace);

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
            Console.WriteLine(error.InnerError?.InnerException?.Message);
            Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine(error.InnerError?.InnerException?.StackTrace);
            Exception ex = new Exception(error.InnerError?.Message ?? error.Message ?? error.ToString(), error.InnerError?.InnerException);
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
            Console.WriteLine(error.InnerError?.InnerException?.Message);
            Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine(error.InnerError?.InnerException?.StackTrace);

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
            Console.WriteLine(error.InnerError?.InnerException?.Message);
            Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine(error.InnerError?.InnerException?.StackTrace);

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
            Console.WriteLine(error.InnerError?.InnerException?.Message);
            Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine(error.InnerError?.InnerException?.StackTrace);

        }

        static void Test7()
        {
            // tds exception
            string errorstring = @"
                {
	                ""error"": {
		                ""code"": ""0_code"",
                        ""message"": ""0_message"",
                        ""details"": [
			                        {
				                        ""code"": ""Client"",
				                        ""target"": """",
				                        ""message"": ""Ex6F9304|Microsoft.Exchange.Configuration.Tasks.ManagementObjectNotFoundException|The operation couldn't be performed because object 'user2@jichen0107d.com' couldn't be found on 'EXHV-1242.EXHV-1242dom.extest.microsoft.com'.""
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
            Console.WriteLine(error.InnerError?.InnerException?.Message);
            Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine(error.InnerError?.InnerException?.StackTrace);
            Exception ex = new Exception(error.InnerError?.Message ?? error.Message ?? error.ToString(), error.InnerError?.InnerException);
        }



        static void Test8()
        {
            // tds exception
            string errorstring = @"
                {
	                ""error"": {
		                ""Code"": ""0_code"",
                        ""Message"": ""0_message"",
                        ""details"": [
			                        {
				                        ""code"": ""Client"",
				                        ""target"": """",
				                        ""message"": ""Ex6F9304|Microsoft.Exchange.Configuration.Tasks.ManagementObjectNotFoundException|The operation couldn't be performed because object 'user2@jichen0107d.com' couldn't be found on 'EXHV-1242.EXHV-1242dom.extest.microsoft.com'.""
			                        }
		                        ],
		                ""InnerError"": {
			                ""Message"": ""1_message"",
			                ""Type"": ""1_type"",
			                ""StackTrace"": ""1_stacktrace"",
                            ""internalexception"":{
			                    ""Message"": ""2_message"",
			                    ""Type"": ""2_type"",
			                    ""StackTrace"": ""2_stacktrace""
                            }
		                }
	                }
                }
                ";
            IDictionary<string, object> responseDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(errorstring);

  
            AdminApiError error1 = JsonConvert.DeserializeObject<AdminApiError>(responseDict["error"].ToString());
            AdminApiError2 error2 = JsonConvert.DeserializeObject<AdminApiError2>(responseDict["error"].ToString());

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("error.Code\t\t\t\t\t" + error1.Code);
            Console.WriteLine("error.Message\t\t\t\t\t" + error1.Message);
            Console.WriteLine("error.InnerError?.Message\t\t\t" + error1.InnerError?.Message);
            //Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine("error.InnerError?.StackTrace\t\t\t" + error1.InnerError?.StackTrace);
            Console.WriteLine("error.InnerError?.InnerException?.Message\t" + error1.InnerError?.InnerException?.Message);
            //Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine("error.InnerError?.InnerException?.StackTrace\t" + error1.InnerError?.InnerException?.StackTrace);

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("error.Code\t\t\t\t\t" + error2.Code);
            Console.WriteLine("error.Message\t\t\t\t\t" + error2.Message);
            Console.WriteLine("error.InnerError?.Message\t\t\t" + error2.InnerError?.Message);
            //Console.WriteLine(error.InnerError?.Type);
            Console.WriteLine("error.InnerError?.StackTrace\t\t\t" + error2.InnerError?.StackTrace);
            Console.WriteLine("error.InnerError?.InnerException?.Message\t" + error2.InnerError?.InnerException?.Message);
            //Console.WriteLine(error.InnerError?.InnerException?.Type);
            Console.WriteLine("error.InnerError?.InnerException?.StackTrace\t" + error2.InnerError?.InnerException?.StackTrace);

            Console.WriteLine("--------------------------------------");

            Exception innerEx1 = error1.InnerError.InnerException;
            Console.WriteLine("innerEx1.ToString()   -" + innerEx1.ToString());
            Console.WriteLine("innerEx1.Message   -" + innerEx1.Message);
            Console.WriteLine("innerEx1.StackTrace   -" + innerEx1.StackTrace);

            Console.WriteLine("--------------------------------------");

            Exception innerEx2 = error2.InnerError.InnerException;
            Console.WriteLine("innerEx2.ToString()   -" + innerEx2.ToString());
            Console.WriteLine("innerEx2.Message   -" + innerEx2.Message);
            Console.WriteLine("innerEx2.StackTrace   -" + innerEx2.StackTrace);
            Console.WriteLine("--------------------------------------");

            //Exception ex = new Exception(error.InnerError?.Message ?? error.Message ?? error.ToString(), error.InnerError?.InnerException);
        }
    }
}
