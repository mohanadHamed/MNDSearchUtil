/*
The MIT License(MIT)
Copyright(c) MohanadHamed
Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
*/


using System;
using System.Collections.Generic;

namespace MNDSearchUtil
{
    public static class ListUtility
    {


        /// <summary>
        /// Returns an index pointing to the first element in the sorted list whose value is equals or greater than v. 
        ///  If v is less than the first lement, zero is returned.
        ///  If v is greater that the last element, list.Count is returned
        /// </summary>
        /// <returns>An index pointing to the first element whose value is equals or greater than v.</returns>
        /// <param name="list">The list to search in (must be sorted).</param>
        /// <param name="v">The value to get its lower bound</param>
        /// <typeparam name="T">The type of list and v parameters</typeparam>
        public static int LowerBound<T>(List<T> list, T v)
        {

            int start, end, mid;
            Comparer<T> customComparer = Comparer<T>.Default;
            int numIt = 0;

            if(list.Count == 0)
            {
                return -1;
            }


            start = 0;
            end = list.Count-1;

            do
            {
                mid = (start + end) / 2;

                if (customComparer.Compare(list [mid], v) >= 0)
                {
                    if (mid > 0 &&
                        customComparer.Compare(list [mid - 1], v)  < 0)
                    {
                        Console.WriteLine("num iterations = " + numIt);
                        return mid;
                    }

                    end = mid - 1;

                } else
                {
                    start = mid + 1;
                }

                ++numIt;

            } while(start <= end);

            if(customComparer.Compare(v, list[0]) <= 0)
            {
                return 0;
            }

            Console.WriteLine("num iterations = " + numIt);
            return mid + 1;
        }


        /// <summary>
        /// Returns an index pointing to the first element in the sorted list whose value is considered to go after v. 
        ///  If v is less than the first lement, zero is returned.
        ///  If v is greater that the last element, list.Count is returned
        /// </summary>
        /// <returns>An index pointing to the first element whose value is greater than v.</returns>
        /// <param name="list">The list to search in (must be sorted).</param>
        /// <param name="v">The value to get its upper bound</param>
        /// <typeparam name="T">The type of list and v parameters</typeparam>
        public static int UpperBound<T>(List<T> list, T v)
        {

            int start, end, mid;
            Comparer<T> customComparer = Comparer<T>.Default;

            if(list.Count == 0)
            {
                return -1;
            }


            start = 0;
            end = list.Count-1;

            do
            {
                mid = (start + end) / 2;

                if (customComparer.Compare(list [mid], v) <= 0)
                {
                    if (mid < (list.Count - 1) &&
                        customComparer.Compare(v, list [mid + 1]) < 0)
                    {
                        return mid + 1;
                    }

                    start = mid + 1;

                } else
                {
                    end = mid - 1;
                }



            } while(start <= end);

            if(customComparer.Compare(v, list[0]) < 0)
            {
                return 0;
            }

            return mid + 1;
        }


        /// <summary>
        /// Searches an entire sorted list for a first occurence of specific element, using the IComparable interface implemented by each element of the list and by the specified object.
        /// </summary>
        /// <returns>The index of the first occurence of specified value in the specified list, if v is found; otherwise, a negative number.
        ///  If v is not found and v is less than one or more elements in list, the negative number returned is the bitwise complement of the index of the first element that is larger than v.
        ///  If v is not found and v is greater than all elements in list, the negative number returned is the bitwise complement of (the index of the last element plus 1). If this method is called with a non-sorted list, the return value can be incorrect and a negative number could be returned, even if v is present in list.</returns>
        /// <param name="list">The list to search in (must be sorted).</param>
        /// <param name="v">The value to search for</param>
        /// <typeparam name="T">The type of list and v parameters</typeparam>
        public static int BinarySearchFirstIndex<T>(List<T> list, T v)
        {

            int start, end, mid;
            Comparer<T> customComparer = Comparer<T>.Default;
         
            if(list.Count == 0)
            {
                return -1;
            }


            start = 0;
            end = list.Count-1;

            int compareResult;

            do
            {
                mid = (start + end) / 2;

                compareResult = customComparer.Compare(list[mid], v);
                if (compareResult >= 0)
                {
                    if (mid > 0 &&
                        customComparer.Compare(list[mid - 1], v)  < 0)
                    {
                        return compareResult == 0 ? mid : ~mid;
                    }

                    end = mid - 1;

                } else
                {
                    start = mid + 1;
                }

            } while(start <= end);

            compareResult = customComparer.Compare(v, list[0]);
            if(compareResult <= 0)
            {
                return compareResult == 0 ? 0 : -1;
            }
                
            return ~(mid + 1);
        }


        /// <summary>
        /// Searches an entire sorted list for a last occurence of specific element, using the IComparable interface implemented by each element of the list and by the specified object.
        /// </summary>
        /// <returns>The index of the last occurence of specified value in the specified list, if v is found; otherwise, a negative number.
        ///  If v is not found and v is less than one or more elements in list, the negative number returned is the bitwise complement of the index of the first element that is larger than v.
        ///  If v is not found and v is greater than all elements in list, the negative number returned is the bitwise complement of (the index of the last element plus 1). If this method is called with a non-sorted list, the return value can be incorrect and a negative number could be returned, even if v is present in list.</returns>
        /// <param name="list">The list to search in (must be sorted).</param>
        /// <param name="v">The value to search for</param>
        /// <typeparam name="T">The type of list and v parameters</typeparam>
        public static int BinarySearchLastIndex<T>(List<T> list, T v)
        {

            int start, end, mid;
            Comparer<T> customComparer = Comparer<T>.Default;

            if(list.Count == 0)
            {
                return -1;
            }


            start = 0;
            end = list.Count-1;

            int compareResult;

            do
            {
                mid = (start + end) / 2;

                compareResult = customComparer.Compare(list[mid], v);
                if (compareResult <= 0)
                {
                    if (mid < (list.Count - 1) &&
                        customComparer.Compare(list[mid + 1], v)  > 0)
                    {
                        return compareResult == 0 ? mid : ~(mid + 1);
                    }

                    start = mid + 1;

                } else
                {
                    end = mid - 1;             
                }                   

            } while(start <= end);

            compareResult = customComparer.Compare(v, list[list.Count - 1]);
            if(compareResult >= 0)
            {
                return compareResult == 0 ? list.Count - 1 : ~(list.Count);
            }
                
            return -1;
        }
    }
}

