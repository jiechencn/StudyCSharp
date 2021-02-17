using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Reflection;

namespace AttributeTest
{
    public interface IMyValidator<T> where T : class
    {
        public IList<string> ValidatorResultMessages { get; set; }
        bool IsValid(T t);
    }
    public class MyValidator<T> : IMyValidator<T> where T : class
    {
        public IList<string> ValidatorResultMessages { get; set; }
        public bool IsValid(T t)
        {
            if (t == null)
            {
                throw new ArgumentNullException(t.ToString());
            }

            ValidatorResultMessages = new List<string>();

            Type type = t.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                //获取当前属性的1个或多个验证特性
                object[] allAttrsForCurrentProp = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                if (allAttrsForCurrentProp != null && allAttrsForCurrentProp.Length>0)
                {
                    //获取当前属性的值
                    object value = property.GetValue(t, null);
                    
                    foreach (ValidationAttribute att in allAttrsForCurrentProp)
                    {
                        //依次检查每个特性，查看当前value是否符合每个特性
                        if (!att.IsValid(value))
                        {
                            ValidatorResultMessages.Add(att.ErrorMessage);
                            
                        }
                    }
                }
            }
            if (ValidatorResultMessages==null || ValidatorResultMessages.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
