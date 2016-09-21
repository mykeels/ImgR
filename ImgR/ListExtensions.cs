using System;
using System.Collections.Generic;
using System.Linq;

namespace ImgR
{
    public static class ListExtensions
    {
        public static Random r = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
        public static IEnumerable<T> First<T>(this IEnumerable<T> myarray, int count)
        {
            if (myarray.IsEmpty()) return null;
            List<T> ret = new List<T>();
            for (int i = 0; i < Math.Min(count, myarray.Count()); i++)
            {
                ret.Add(myarray.ElementAt(i));
            }
            return ret.AsEnumerable<T>();
        }

        public static IEnumerable<T> Last<T>(this IEnumerable<T> myarray, int count)
        {
            if (myarray.IsEmpty()) return null;
            List<T> ret = new List<T>();
            for (int i = Math.Max(myarray.Count() - count, 0); i < myarray.Count(); i++)
            {
                ret.Add(myarray.ElementAt(i));
            }
            return ret.AsEnumerable<T>();
        }

        public static List<T> Fill<T>(this List<T> myarray, int count, T value = default(T))
        {
            myarray = new List<T>();
            for (int i = 0; i < count; i++)
            {
                myarray.Add(value);
            }
            return myarray;
        }

        public static List<T> Push<T>(this List<T> myarray, T obj)
        {
            if ((myarray != null))
            {
                myarray.Add(obj);
            }
            return myarray;
        }

        public static List<T> PushRange<T>(this List<T> myarray, List<T> arr)
        {
            if (myarray == null) return myarray;
            if (arr == null) return myarray;
            myarray.AddRange(arr);
            return myarray;
        }

        public static T Random<T>(this IEnumerable<T> l)
        {
            //Random r = new Random(Convert.ToInt32(DateTime.Now.Millisecond));
            if (l.Count() == 0)
            {
                return default(T);
            }
            double rr = r.NextDouble() * l.Count();
            return l.ElementAt(Convert.ToInt32(Math.Floor(Convert.ToDouble(rr))));
        }

        public static IEnumerable<T> Random<T>(this IEnumerable<T> l, int count)
        {
            l = l.ToList();
            Random r = new Random(Convert.ToInt32((new DateTime()).Ticks));
            if (l.Count() == 0 || count < 1)
            {
                return new List<T>();
            }
            List<T> ret = new List<T>();
            for (int i = 0; i < Math.Min(count, l.Count()); i++)
            {
                double rr = r.NextDouble() * l.Count();
                int index = Convert.ToInt32(Math.Floor(Convert.ToDouble(rr)));
                ret.Push(l.ElementAt(index));
                l = l.Except(ret);
            }
            return ret;
        }

        public static string Join(this IEnumerable<string> myarray, string concatenator = "")
        {
            string ret = "";
            int i = 0;
            foreach (var ch in myarray)
            {
                ret += Convert.ToString(ch);
                i += 1;
                if (i < myarray.Count())
                {
                    ret += concatenator;
                }
            }
            return ret;
        }

        public static string Join<T>(this IEnumerable<T> myarray, string concatenator = "")
        {
            string ret = "";
            int i = 0;
            foreach (var ch in myarray)
            {
                ret += Convert.ToString(ch);
                i += 1;
                if (i < myarray.Count())
                {
                    ret += concatenator;
                }
            }
            return ret;
        }
        
        public static List<T> From<T>(this List<T> myarray, int index)
        {
            List<T> ret = new List<T>();
            if (index >= myarray.Count) return new List<T>();
            for (int i = index; i < myarray.Count; i++)
            {
                ret.Push(myarray[i]);
            }
            return ret;
        }

        public static IEnumerable<T> Backwards<T>(this IEnumerable<T> myarray)
        {
            for (int i = myarray.Count() - 1; i >= 0; i--)
            {
                yield return myarray.ElementAt(i);
            }
        }

        public static List<T> Where<T>(this List<T> myarray, Func<T, bool> myfunc)
        {
            List<T> ret = new List<T>();
            foreach (var obj in myarray)
            {
                if (myfunc(obj)) ret.Add(obj);
            }
            return ret;
        }

        public static bool IsEmpty<T>(this IEnumerable<T> myarray)
        {
            if (myarray.Count() == 0) return true;
            return false;
        }

        public static List<X> Flatten<X>(this IEnumerable<IEnumerable<X>> myarray)
        {
            List<X> ret = new List<X>();
            foreach (var arr in myarray)
            {
                if (arr is IEnumerable<X>)
                {
                    foreach (X obj in arr)
                    {
                        ret.Push(obj);
                    }
                }
            }
            return ret;
        }

        public static ICollection<X> AddIf<X>(this ICollection<X> myarray, X val, Func<X, X, bool> check)
        {
            if (myarray.All<X>((c) => check(c, val))) myarray.Add(val);
            return myarray;
        }

        public static List<List<X>> Paginate<X>(this List<X> myarray, int width = 5)
        {
            if (myarray.IsEmpty()) return new List<List<X>>();
            List<List<X>> ret = new List<List<X>>();
            List<X> ret_i = new List<X>();
            int i = 0;
            myarray.ForEach((X item) =>
            {
                //if (ret.LastOrDefault() == null || ret.LastOrDefault().IsEmpty()) ret.Add(new List<X>());
                if (i < width)
                {
                    ret_i.Add(item);
                    i += 1;
                }
                if (i == width)
                {
                    ret.Add(ret_i);
                    ret_i = new List<X>();
                    //ret_i.Add(item);
                    i = 0;
                }
            });
            if (!ret_i.IsEmpty()) ret.Add(ret_i);
            return ret;
        }

        public static void AddSafe(this IDictionary<string, dynamic> mydict, string key, dynamic value)
        {
            if (mydict.ContainsKey(key))
            {
                try
                {
                    mydict[key] = value;
                }
                catch (Exception ex)
                {
                    mydict.Add(key, value);
                }
            }
            else
            {
                try
                {
                    mydict.Add(key, value);
                }
                catch (Exception ex)
                {
                    mydict[key] = value;
                }
            }
        }

        public static void AddSafe<K, V>(this IDictionary<K, V> mydict, K key, V value)
        {
            if (mydict.ContainsKey(key))
            {
                try
                {
                    mydict[key] = value;
                }
                catch (Exception ex)
                {
                    mydict.Add(key, value);
                }
            }
            else
            {
                try
                {
                    mydict.Add(key, value);
                }
                catch (Exception ex)
                {
                    mydict[key] = value;
                }
            }
        }

        public static void AddOnce<K, V>(this IDictionary<K, V> mydict, K key, V value)
        {
            if (!mydict.ContainsKey(key)) mydict.Add(key, value);
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> myarray, T default_value)
        {
            T ret = myarray.FirstOrDefault();
            if (ret == null) return default_value;
            else return ret;
        }

        public static T LastOrDefault<T>(this IEnumerable<T> myarray, T default_value)
        {
            T ret = myarray.LastOrDefault();
            if (ret == null) return default_value;
            else return ret;
        }

        public static void AddSafe(this System.Web.SessionState.HttpSessionState session, string key, dynamic value)
        {
            if (!String.IsNullOrEmpty(key))
            {
                if (session[key] != null)
                {
                    session[key] = value;
                }
                else
                {
                    session.Add(key, value);
                }
            }
        }

        public static void AddOnce(this System.Web.SessionState.HttpSessionState session, string key, dynamic value)
        {
            if (!String.IsNullOrEmpty(key))
            {
                if (session[key] == null)
                {
                    session.Add(key, value);
                }
            }
        }

        public static void AddSafe(this System.Web.HttpSessionStateBase session, string key, dynamic value)
        {
            if (!String.IsNullOrEmpty(key))
            {
                if (session[key] != null)
                {
                    session[key] = value;
                }
                else
                {
                    session.Add(key, value);
                }
            }
        }

        public static void AddOnce(this System.Web.HttpSessionStateBase session, string key, dynamic value)
        {
            if (!String.IsNullOrEmpty(key))
            {
                if (session[key] == null)
                {
                    session.Add(key, value);
                }
            }
        }
    }
}
