using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MobileHelper.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileHelperMaui.Services.DataStores
{
    public static class ShareDataStore<T>
    {
        public static IEnumerable<T> SelectRandomItems(IList<T> source, int count)
        {
            IList<T> list = new List<T>();

            if (source.Count == 0)
            {
                return list;
            }

            HashSet<int> set = new HashSet<int>();

            Random random = new Random();

            while (set.Count < count)
            {
                int index = random.Next(0, source.Count - 1);

                set.Add(index);
            }

            foreach (int index in set.Distinct())
            {
                list.Add(source[index]);
            }

            return list;
        }
    }
}
