using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_PhamGiaBao
{
    internal class Problem1
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                return FindMedianSortedArrays(nums2, nums1);
            }

            int m = nums1.Length;
            int n = nums2.Length;
            int left = 0, right = m;

            while (left <= right)
            {
                int partitionX = (left + right) / 2;
                int partitionY = (m + n + 1) / 2 - partitionX;

                int maxX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
                int minX = (partitionX == m) ? int.MaxValue : nums1[partitionX];

                int maxY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
                int minY = (partitionY == n) ? int.MaxValue : nums2[partitionY];

                if (maxX <= minY && maxY <= minX)
                {
                    if ((m + n) % 2 == 0)
                    {
                        return (Math.Max(maxX, maxY) + Math.Min(minX, minY)) / 2.0;
                    }
                    else
                    {
                        return Math.Max(maxX, maxY);
                    }
                }
                else if (maxX > minY)
                {
                    right = partitionX - 1;
                }
                else
                {
                    left = partitionX + 1;
                }
            }

            throw new InvalidOperationException("Input arrays are not sorted.");
        }

        /*public static void Main(string[] args)
        {
            Console.WriteLine("Enter elements of the first sorted array (comma-separated, within -10^6 to 10^6): ");
            int[] nums1 = Console.ReadLine()
                                 .Split(',')
                                 .Select(int.Parse)
                                 .ToArray();

            Console.WriteLine("Enter elements of the second sorted array (comma-separated, within -10^6 to 10^6): ");
            int[] nums2 = Console.ReadLine()
                                 .Split(',')
                                 .Select(int.Parse)
                                 .ToArray();

            if (nums1.Length + nums2.Length > 2000 || nums1.Length + nums2.Length < 1)
            {
                Console.WriteLine("Invalid input. Ensure 1 <= m + n <= 2000.");
                return;
            }

            double result = FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"The median is: {result}");
        }*/


    }
}
