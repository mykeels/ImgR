using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgR.Models
{
    public static class StringExtensions
    {
        public static string Shuffle(this string s)
        {
            if (String.IsNullOrEmpty(s)) return "";
            string ret = "";
            var l = s.Length;
            List<int> indices = new List<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            while (indices.Count < l)
            {
                int index = Convert.ToInt32(Math.Floor(rand.NextDouble() * l));
                if (!indices.Contains(index))
                {
                    indices.Add(index);
                    ret += s.ElementAt(index);
                }
            }
            return ret;
        }

        public static string First(this string s, int count = 1)
        {
            var ret = "";
            for (int i = 1; i < Math.Min(count, s.Length); i++)
            {
                ret += s.ElementAt(i - 1);
            }
            return ret;
        }

        public static string Last(this string s, int count = 1)
        {
            var ret = "";
            for (int i = Math.Max(s.Length - count, 1); i < s.Length; i++)
            {
                ret += s.ElementAt(i - 1);
            }
            return ret;
        }

    }
    public class StringX
    {
        public static string RandomLetters(int length)
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Shuffle().First(length);
        }

        public static string Random(int length)
        {
            return "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".Shuffle().First(length);
        }
    }
}
