using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public static class ObjectComparer
{
    /// <summary>
    /// Root method for comparing objects of similar type
    /// </summary>
    /// <param name="obj1"></param>
    /// <param name="obj2"></param>
    /// <returns></returns>
    public static bool Compare(object obj1, object obj2)
    {
        bool result;

        if (obj1 != null && obj2 != null)
        {
            Type objectType;
            objectType = obj1.GetType();
            result = true;

            foreach (PropertyInfo propertyInfo in objectType.GetProperties())
            {
                object valueObj1;
                object valueObj2;

                valueObj1 = propertyInfo.GetValue(obj1, null);
                valueObj2 = propertyInfo.GetValue(obj2, null);

                // value types can be directly compared using the function comparable
                if (Comparable(propertyInfo.PropertyType))
                {
                    if (!CompareValues(valueObj1, valueObj2))
                    {
                        return false;
                    }
                }
                // In case of IEnumerable type items neds to be scanned
                else if (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    IEnumerable<object> collectionItems1;
                    IEnumerable<object> collectionItems2;
                    int collectionItemsCount1;
                    int collectionItemsCount2;

                    // Null check
                    if (valueObj1 == null && valueObj2 != null || valueObj1 != null && valueObj2 == null)
                    {
                        result = false;
                    }
                    else if (valueObj1 != null && valueObj2 != null)
                    {
                        collectionItems1 = ((IEnumerable)valueObj1).Cast<object>();
                        collectionItems2 = ((IEnumerable)valueObj2).Cast<object>();

                        if (collectionItems1.GetType().Namespace.Contains("Linq"))
                        {
                            if (collectionItems1.OrderBy(i => i).SequenceEqual(collectionItems2.OrderBy(i => i)))
                            {
                                return true;

                            }
                            return false;
                        }

                        collectionItemsCount1 = collectionItems1.Count();
                        collectionItemsCount2 = collectionItems2.Count();

                        // count of collection items must be equal for the objects to be equal
                        if (collectionItemsCount1 != collectionItemsCount2)
                        {
                            result = false;
                        }

                        else
                        {


                            for (int i = 0; i < collectionItemsCount1; i++)
                            {
                                object collectionItem1;
                                object collectionItem2;
                                Type collectionItemType;

                                collectionItems2.GetHashCode();
                                collectionItem1 = collectionItems1.ElementAt(i);
                                collectionItem2 = collectionItems2.ElementAt(i);
                                collectionItemType = collectionItem1.GetType();




                                if (Comparable(collectionItemType))
                                {
                                    if (!CompareValues(collectionItem1, collectionItem2))
                                    {
                                        result = false;
                                    }
                                }
                                else if (!Compare(collectionItem1, collectionItem2))
                                {
                                    result = false;
                                }
                            }
                        }
                    }
                }
                else if (propertyInfo.PropertyType.IsClass)
                {
                    if (!Compare(propertyInfo.GetValue(obj1, null), propertyInfo.GetValue(obj2, null)))
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
        }
        else
            result = object.Equals(obj1, obj2);

        return result;
    }

    /// <summary>
    /// For directly checking value types and primitive types
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private static bool Comparable(Type type)
    {
        return typeof(IComparable).IsAssignableFrom(type) || type.IsPrimitive || type.IsValueType;
    }

    /// <summary>
    /// to compare reference types
    /// </summary>
    /// <param name="objVal1"></param>
    /// <param name="objVal2"></param>
    /// <returns></returns>
    private static bool CompareValues(object objVal1, object objVal2)
    {
        bool result;
        IComparable Comparer;

        Comparer = objVal1 as IComparable;

        if (objVal1 == null && objVal2 != null || objVal1 != null && objVal2 == null)
            result = false;
        else if (Comparer != null && Comparer.CompareTo(objVal2) != 0)
            result = false;
        else if (!object.Equals(objVal1, objVal2))
            result = false;
        else
            result = true;

        return result;
    }
}