using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
namespace System.Globalization
{
    public static class ActivatorExt
    {
        public static int GetWeekOfMonth(this DateTime time) 
        {
           
            var dayofweek = (((byte)time.DayOfWeek) == 0) ? 7 : (byte)time.DayOfWeek;

            return (time.Day + (byte)(7 - dayofweek)) / 7;
            //if (time.Day < dayofweek)
            //{
            //    GregorianCalendar gc = new GregorianCalendar();
            //    return GetWeekOfMonth(new DateTime(time.Year, time.Month - 1 == 0 ? 12 : time.Month - 1, gc.GetDaysInMonth(time.Year, time.Month - 1 == 0 ? 12 : time.Month - 1)));
            //}
            //else
            //{
            //    return (time.Day + (byte)(7 - dayofweek)) / 7;
            //}
        }
    }
}


namespace System
{

        //
        // 摘要:
        //     Encapsulates a method that has a single parameter and does not return a value.
        //
        // 参数:
        //   obj:
        //     The parameter of the method that this delegate encapsulates.
        //
        // 类型参数:
        //   T:
        //     The type of the parameter of the method that this delegate encapsulates.
        public delegate bool ActionBool<in T>(T obj);
        public delegate bool ActionBool();
        public delegate bool ActionBool<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);
        public delegate bool ActionBool<in T1, in T2, in T3, in T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);


    public delegate int ActionInt<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);



    public static class ActivatorExt
    {
        public static T GetEQP<T>(this object obj) where T : class
        {
            return (T)obj;
        }
        public static void CopyTo(this object obj, object tag)
        {

            Type targetType = obj.GetType();
            if (tag == null)
            {
                tag = System.Activator.CreateInstance(targetType);
            }
            //值类型
            if (targetType.IsValueType == true)
            {
                tag = obj;
            }
            //引用类型 
            else
            {

                System.Reflection.MemberInfo[] memberCollection = obj.GetType().GetMembers();

                foreach (System.Reflection.MemberInfo member in memberCollection)
                {
                    if (member.MemberType == System.Reflection.MemberTypes.Field)
                    {
                        System.Reflection.FieldInfo field = (System.Reflection.FieldInfo)member;
                        Object fieldValue = field.GetValue(obj);
                        if (fieldValue is ICloneable)
                        {
                            field.SetValue(tag, (fieldValue as ICloneable).Clone());
                        }
                        else
                        {
                            field.SetValue(tag, Copy(fieldValue));
                        }

                    }
                    else if (member.MemberType == System.Reflection.MemberTypes.Property)
                    {
                        System.Reflection.PropertyInfo myProperty = (System.Reflection.PropertyInfo)member;
                        MethodInfo info = myProperty.GetSetMethod(false);
                        if (info != null)
                        {
                            object propertyValue = myProperty.GetValue(obj, null);
                            if (propertyValue is ICloneable)
                            {
                                myProperty.SetValue(tag, (propertyValue as ICloneable).Clone(), null);
                            }
                            else
                            {
                                myProperty.SetValue(tag, Copy(propertyValue), null);
                            }
                        }

                    }
                }
            }

        }
        public static object Copy(this object obj)
        {
            Object targetDeepCopyObj;
            if (obj == null)
            {
                return null;
            }
            Type targetType = obj.GetType();
            //值类型
            if (targetType.IsValueType == true)
            {
                targetDeepCopyObj = obj;
            }
            //引用类型 
            else
            {
                targetDeepCopyObj = System.Activator.CreateInstance(targetType);   //创建引用对象 
                System.Reflection.MemberInfo[] memberCollection = obj.GetType().GetMembers();

                foreach (System.Reflection.MemberInfo member in memberCollection)
                {
                    if (member.MemberType == System.Reflection.MemberTypes.Field)
                    {
                        System.Reflection.FieldInfo field = (System.Reflection.FieldInfo)member;
                        Object fieldValue = field.GetValue(obj);
                        if (fieldValue is ICloneable)
                        {
                            field.SetValue(targetDeepCopyObj, (fieldValue as ICloneable).Clone());
                        }
                        else
                        {
                            field.SetValue(targetDeepCopyObj, Copy(fieldValue));
                        }

                    }
                    else if (member.MemberType == System.Reflection.MemberTypes.Property)
                    {
                        System.Reflection.PropertyInfo myProperty = (System.Reflection.PropertyInfo)member;
                        MethodInfo info = myProperty.GetSetMethod(false);
                        if (info != null)
                        {
                            object propertyValue = myProperty.GetValue(obj, null);
                            if (propertyValue is ICloneable)
                            {
                                myProperty.SetValue(targetDeepCopyObj, (propertyValue as ICloneable).Clone(), null);
                            }
                            else
                            {
                                myProperty.SetValue(targetDeepCopyObj, Copy(propertyValue), null);
                            }
                        }

                    }
                }
            }
            return targetDeepCopyObj;
        }

        /// <summary>
        /// 得到一个对象的克隆(二进制的序列化和反序列化)--需要标记可序列化
        /// </summary>
        public static T Clone<T>(this T obj)
        {
            //if (obj ==null)
            //{
            //    return obj;
            //}
            //MemoryStream memoryStream = new MemoryStream();
            //BinaryFormatter formatter = new BinaryFormatter();
            //formatter.Serialize(memoryStream, obj);
            //memoryStream.Position = 0;
            //return formatter.Deserialize(memoryStream);

            var json = JsonConvert.SerializeObject(obj);
            var ret = JsonConvert.DeserializeObject<T>(json);
            return ret;




        }
        

    }
}
