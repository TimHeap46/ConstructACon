using System;
using System.Reflection;

namespace App1.Models.Helper
{
    namespace App1.Models
    {
        public static class ReflectionHelper
        {

            public static void SetProperty(Object source, string property, object target)
            {
                string[] names = property.Split('.');

                for (int i = 0; i < names.Length - 1; i++)
                {
                    PropertyInfo prop = source.GetType().GetProperty(names[i]);
                    source = prop.GetValue(source, null);
                }
                PropertyInfo propertyToSet = source.GetType().GetProperty(names[names.Length - 1]);
                propertyToSet.SetValue(source, target, null);
            }

            public static Object GetPropValue(this Object obj, String propName)
            {
                string[] nameParts = propName.Split('.');
                if (nameParts.Length == 1)
                {
                    return obj.GetType().GetProperty(propName).GetValue(obj, null);
                }

                foreach (String part in nameParts)
                {
                    if (obj == null) { return null; }

                    Type type = obj.GetType();
                    PropertyInfo info = type.GetProperty(part);
                    if (info == null) { return null; }

                    obj = info.GetValue(obj, null);
                }
                return obj;
            }
            public static PropertyInfo GetProp(this Object obj, String propName)
            {
                string[] nameParts = propName.Split('.');
                if (nameParts.Length == 1)
                {
                    return obj.GetType().GetProperty(propName);
                }

                foreach (String part in nameParts)
                {
                    if (obj == null)
                    {
                        return null;
                    }

                    Type type = obj.GetType();
                    PropertyInfo info = type.GetProperty(part);
                    if (info == null)
                    {
                        return null;
                    }
                    else
                    {
                        return info;
                    }
                }
                return null;
            }
        }
    }
}