using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkSeng.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Creates a new instance of this list and populates it with the instances of the old list
        /// </summary>
        /// <returns>A new List instance with the old items inside</returns>
        public static List<object> DeepCopy(this IList listToClone)
        {
            var tmpList = new List<object>();

            foreach (var itm in listToClone)
            {
                tmpList.Add(itm);
            }

            return tmpList;
        }
    }
}
