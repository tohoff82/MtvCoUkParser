using System;
using System.Text;

namespace MtvCoUkParser.Extensions
{
    public static class Extensions
    {
        public static string ToPathId(this string name, bool forPlayer = false)
        {
            string[] nameArr = name.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder(nameArr[0]);
            if (nameArr.Length > 1)
            {
                for (int i = 1; i < nameArr.Length; i++)
                {
                    sb.AppendFormat("{0}{1}", '-', nameArr[i]);
                }
            }

            if (!forPlayer) return sb.ToString();
            else return sb.Append('#').ToString();
        }
    }
}
