/*
The MIT License(MIT)
Copyright(c) MohanadHamed
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
*/

using System;
using System.Collections.Generic;
using System.Collections;

namespace MNDSearchUtil
{
    public static class SortedListUtility
    {


        /// <summary>
        /// Returns an index pointing to the first element in the sorted list whose key is equals or greater than k. 
        ///  If k is less than the first lement, zero is returned.
        ///  If k is greater that the last element, list.Count is returned
        /// </summary>
        /// <returns>An index pointing to the first element whose value is equals or greater than k.</returns>
        /// <param name="list">The sorted list to search in</param>
        /// <param name="k">The key to get its lower bound</param>
        /// <typeparam name="TKey">The type of sorted list keys</typeparam>
        /// <typeparam name="TValue">The type of sorted list values</typeparam>
        public static int LowerBound<TKey, TValue>(SortedList<TKey, TValue> list, TKey k)
        {

            int start, end, mid;
            Comparer<TKey> customComparer = Comparer<TKey>.Default;

            if(list.Count == 0)
            {
                return -1;
            }


            start = 0;
            end = list.Count-1;

            do
            {
                mid = (start + end) / 2;

                if (customComparer.Compare(list.Keys[mid], k) >= 0)
                {
                    if (mid > 0 &&
                        customComparer.Compare(list.Keys[mid - 1], k)  < 0)
                    {
                        return mid;
                    }

                    end = mid - 1;

                } else
                {
                    start = mid + 1;
                }

            } while(start <= end);

            if(customComparer.Compare(k, list.Keys[0]) <= 0)
            {
                return 0;
            }

            return mid + 1;
        }

        /// <summary>
        /// Returns an index pointing to the first element in the sorted list whose key is considered to go after k. 
        ///  If k is less than the first lement, zero is returned.
        ///  If k is greater that the last element, list.Count is returned
        /// </summary>
        /// <returns>An index pointing to the first element whose key is greater than k.</returns>
        /// <param name="list">The sorted list to search in</param>
        /// <param name="k">The key to get its upper bound</param>
        /// <typeparam name="TKey">The type of sorted list keys</typeparam>
        /// <typeparam name="TValue">The type of sorted list values</typeparam>
        public static int UpperBound<TKey, TValue>(SortedList<TKey, TValue> list, TKey k)
        {

            int start, end, mid;
            Comparer<TKey> customComparer = Comparer<TKey>.Default;

            if(list.Count == 0)
            {
                return -1;
            }

            start = 0;
            end = list.Count-1;

            do
            {
                mid = (start + end) / 2;

                if (customComparer.Compare(list.Keys[mid], k) <= 0)
                {
                    if (mid < (list.Count - 1) &&
                        customComparer.Compare(k, list.Keys [mid + 1]) < 0)
                    {
                        return mid + 1;
                    }

                    start = mid + 1;

                } else
                {
                    end = mid - 1;
                }



            } while(start <= end);

            if(customComparer.Compare(k, list.Keys[0]) < 0)
            {
                return 0;
            }

            return mid + 1;
        }

            
    }
}

