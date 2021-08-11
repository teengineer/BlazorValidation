using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorValidation.Infrastructure
{
    public class Validation
    {
        private readonly IJSRuntime js;

        public Validation(IJSRuntime js)
        {
            this.js = js;
        }
        public string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }

        public bool ValidationForm(Object ob)
        {
            bool result = true;
            foreach (var propertyInfo in ob.GetType()
                                  .GetProperties(
                                           BindingFlags.FlattenHierarchy |
                                            BindingFlags.Instance |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Public |
                                            BindingFlags.Static))
            {
                if (propertyInfo.CustomAttributes.Count() > 0)
                {
                    var attributeName = propertyInfo.CustomAttributes.FirstOrDefault().AttributeType.Name;
                    if (attributeName == "RequiredAttribute")
                    {
                        var value = propertyInfo.GetValue(ob);
                        if (value != null)
                        {
                            var type = value.GetType();
                            if (type.Name == "Int32" && value.ToString() == "0") result = false;
                            if (type.Name == "String" && value.ToString() == "") result = false;
                            if (type.Name == "Guid" && value.ToString() == "00000000-0000-0000-0000-000000000000") result = false;
                            js.InvokeVoidAsync("Validation", propertyInfo.Name, value.ToString(), type.Name);
                        }
                        else
                        {
                            result = false;
                            js.InvokeVoidAsync("Validation", propertyInfo.Name, null, null);
                        }
                    }
                }
            }
            return result;
        }

        public bool ValidationGrid(Object ob, string guid)
        {
            bool result = true;
            foreach (var propertyInfo in ob.GetType()
                                  .GetProperties(
                                           BindingFlags.FlattenHierarchy |
                                            BindingFlags.Instance |
                                            BindingFlags.NonPublic |
                                            BindingFlags.Public |
                                            BindingFlags.Static))
            {
                if (propertyInfo.CustomAttributes.Count() > 0)
                {
                    var attributeName = propertyInfo.CustomAttributes.FirstOrDefault().AttributeType.Name;
                    if (attributeName == "RequiredAttribute")
                    {
                        var value = propertyInfo.GetValue(ob);
                        if (value != null)
                        {
                            var type = value.GetType();
                            if (type.Name == "Int32" && value.ToString() == "0") result = false;
                            if (type.Name == "String" && value.ToString() == "") result = false;
                            if (type.Name == "Guid" && value.ToString() == "00000000-0000-0000-0000-000000000000") result = false;
                            js.InvokeVoidAsync("Validation", propertyInfo.Name + "_" + guid, value.ToString(), type.Name);
                        }
                        else
                        {
                            result = false;
                            js.InvokeVoidAsync("Validation", propertyInfo.Name + "_" + guid, null, null);
                        }
                    }
                }
            }
            return result;
        }

    }
}
