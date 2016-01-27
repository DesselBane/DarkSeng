using System;

namespace DarkSeng.Extensions
{
    public static class IComparableExtentions
    {
        /// <summary>
        /// Changes the Items at Index1 and Index2
        /// </summary>
        /// <typeparam name="T">Type of ICompareable</typeparam>
        /// <param name="data">The array that contains the items</param>
        /// <param name="index1">First index to swap</param>
        /// <param name="index2">Second index to swap</param>
        public static void exchange<T>(this T[] data, int index1, int index2) where T : IComparable
        {
            T temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }

        #region InsertionSort

        /// <summary>
        /// Sorts the array discendingly with InsertionSort Algorithm
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="data">The array to sort</param>
        public static void InsertionSortDESC<T>(this T[] data) where T : IComparable
        {
            int n = data.Length;
            for (int i = 1; i < n; i++)
            {
                int j = i;
                T item = data[j];
                while (j > 0 && data[j - 1].CompareTo(item) < 0)
                {
                    data[j] = data[j-- - 1];
                }
                data[j] = item;
            }
        }

        /// <summary>
        /// Sorts the array ascendingly with InsertionSort Algorithm
        /// </summary>
        /// <typeparam name="T">Type of data</typeparam>
        /// <param name="data">The array to sort</param>
        public static void InsertionSortASC<T>(this T[] data) where T : IComparable
        {
            int n = data.Length;
            for (int i = 1; i < n; i++)
            {
                int j = i;
                T item = data[j];
                while (j > 0 && data[j - 1].CompareTo(item) > 0)
                {
                    data[j] = data[j-- - 1];
                }
                data[j] = item;
            }
        }

        #endregion

        #region SelectionSort

        /// <summary>
        /// Sorts the array descendingly with SelectionSort Algorithm
        /// </summary>
        /// <typeparam name="T">The array to sort</typeparam>
        /// <param name="data"></param>
        public static void SelectionSortDESC<T>(this T[] data) where T : IComparable
        {
            int n = data.Length - 1;
            for (int i = 0; i < n; i++)
            {
                int k = i;
                T m = data[i];
                for (int j = i + 1; j <= n; j++)
                {
                    if (data[j].CompareTo(m) > 0)
                    {
                        k = j;
                        m = data[j];
                    }
                }
                data.exchange<T>(i, k);
            }
        }

        /// <summary>
        /// Sorts the array ascendingly with SelectionSort Algorithm
        /// </summary>
        /// <typeparam name="T">The array to sort</typeparam>
        /// <param name="data"></param>
        public static void SelectionSortASC<T>(this T[] data) where T : IComparable
        {
            int n = data.Length - 1;
            for (int i = 0; i < n; i++)
            {
                int k = i;
                T m = data[i];
                for (int j = i + 1; j <= n; j++)
                {
                    if (data[j].CompareTo(m) < 0)
                    {
                        k = j;
                        m = data[j];
                    }
                }
                data.exchange<T>(i, k);
            }
        }

        #endregion

        #region QuickSort


        /// <summary>
        /// Sorts the array ascendingly with the QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The array to sort</param>
        /// <param name="low">start index of the array</param>
        /// <param name="high">end index of the array</param>
        private static void QuickSortASC<T>(T[] data, int low, int high) where T : IComparable
        {
            int left = low, right = high;
            T item = data[right];
            while (left <= right)
            {
                while (data[left].CompareTo(item) < 0) left++;
                while (data[right].CompareTo(item) > 0) right--;
                if (left <= right)
                {
                    data.exchange<T>(left, right);
                    left++; right--;
                }
            }
            if (low < right) QuickSortASC<T>(data, low, right);
            if (left < high) QuickSortASC<T>(data, left, high);
        }

        /// <summary>
        /// Sorts the array ascendingly with the QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T">The array to sort</typeparam>
        /// <param name="data"></param>
        public static void QuickSortASC<T>(this T[] data) where T : IComparable
        {
            QuickSortASC<T>(data, 0, data.Length - 1);
        }

        /// <summary>
        /// Sorts the array descendingly with the QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The array to sort</param>
        /// <param name="low">start index of the array</param>
        /// <param name="high">end index of the array</param>
        private static void QuickSortDESC<T>(T[] data, int low, int high) where T : IComparable
        {
            int left = low, right = high;
            T item = data[right];
            while (left <= right)
            {
                while (data[left].CompareTo(item) > 0) left++;
                while (data[right].CompareTo(item) < 0) right--;
                if (left <= right)
                {
                    data.exchange<T>(left, right);
                    left++; right--;
                }
            }
            if (low < right) QuickSortDESC<T>(data, low, right);
            if (left < high) QuickSortDESC<T>(data, left, high);
        }

        /// <summary>
        /// Sorts the array descendingly with the QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T">The array to sort</typeparam>
        /// <param name="data"></param>
        public static void QuickSortDESC<T>(this T[] data) where T : IComparable
        {
            QuickSortDESC<T>(data, 0, data.Length - 1);
        }

        /// <summary>
        /// Sorts the array ascendingly with the prohabilistic version of QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The array to sort</param>
        /// <param name="low">start index of the array</param>
        /// <param name="high">end index of the array</param>
        private static void QuickSortProhASC<T>(T[] data, int low, int high) where T : IComparable
        {
            int left = low, right = high;
            T item = data[new Random().Next(left, right + 1)];
            while (left <= right)
            {
                while (data[left].CompareTo(item) < 0) left++;
                while (data[right].CompareTo(item) > 0) right--;
                if (left <= right)
                {
                    data.exchange<T>(left, right);
                    left++; right--;
                }
            }
            if (low < right) QuickSortProhASC<T>(data, low, right);
            if (left < high) QuickSortProhASC<T>(data, left, high);
        }

        /// <summary>
        /// Sorts the array ascendingly with the prohabilistic version of QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T">The array to sort</typeparam>
        /// <param name="data"></param>
        public static void QuickSortProhASC<T>(this T[] data) where T : IComparable
        {
            QuickSortProhASC<T>(data, 0, data.Length - 1);
        }

        /// <summary>
        /// Sorts the array descendingly with the prohabilistic version of QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The array to sort</param>
        /// <param name="low">start index of the array</param>
        /// <param name="high">end index of the array</param>
        private static void QuickSortProhDESC<T>(T[] data, int low, int high) where T : IComparable
        {
            int left = low, right = high;
            T item = data[new Random().Next(left, right + 1)];
            while (left <= right)
            {
                while (data[left].CompareTo(item) > 0) left++;
                while (data[right].CompareTo(item) < 0) right--;
                if (left <= right)
                {
                    data.exchange<T>(left, right);
                    left++; right--;
                }
            }
            if (low < right) QuickSortProhDESC<T>(data, low, right);
            if (left < high) QuickSortProhDESC<T>(data, left, high);
        }

        /// <summary>
        /// Sorts the array descendingly with the prohabilistic version of QuickSort Algorithm
        /// </summary>
        /// <typeparam name="T">The array to sort</typeparam>
        /// <param name="data"></param>
        public static void QuickSortProhDESC<T>(this T[] data) where T : IComparable
        {
            QuickSortProhDESC<T>(data, 0, data.Length - 1);
        }

        #endregion 

    }
}
