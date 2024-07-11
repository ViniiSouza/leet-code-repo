using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Questions
    {
        public static int[][] Merge(int[][] intervals)
        {
            intervals = intervals.OrderBy(key => key[0]).ToArray();

            List<int[]> result = new List<int[]> { intervals[0] };

            for (int i = 1; i < intervals.Length; i++)
            {
                int lastEnd = result.LastOrDefault()[1];
                int thisStart = intervals[i][0];

                if (lastEnd < thisStart)
                    result.Add(intervals[i]);
                else
                {
                    var start = result.LastOrDefault()[0];
                    result.RemoveAt(result.Count - 1);
                    result.Add(new int[] { start, int.Max(intervals[i][1], lastEnd) });
                }
            }

            return result.ToArray();

            throw new Exception("Sem choro");
        }
        public static int LongestConsecutive()
        {
            int[] nums = [100, 4, 200, 1, 3, 2, 2];
            if (nums.Length == 0)
                return 0;
            HashSet<int> set = new HashSet<int>(nums);
            int maxLength = 1;

            foreach (int i in nums)
            {
                if (set.Contains(i - 1))
                {
                    continue;
                }

                int length = 1;
                while (set.Contains(i + length))
                {
                    length++;
                }

                maxLength = Math.Max(maxLength, length);
            }

            return maxLength;
        }
        public static int Trap()
        {
            int[] height = [1,0,2,1,0,1,3,1,1,1,1];
            int n = height.Length;
            if (n == 0) return 0;

            int leftMax = 0;
            int rightMax = 0;
            int left = 0;
            int right = n - 1;
            int waterTrapped = 0;

            while (left < right)
            {
                if (height[left] < height[right])
                {
                    if (height[left] >= leftMax)
                    {
                        leftMax = height[left];
                    }
                    else
                    {
                        waterTrapped += leftMax - height[left];
                    }
                    left++;
                }
                else
                {
                    if (height[right] >= rightMax)
                    {
                        rightMax = height[right];
                    }
                    else
                    {
                        waterTrapped += rightMax - height[right];
                    }
                    right--;
                }
            }

            return waterTrapped;
        }
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (var s in strs)
            {
                char[] caracteres = s.ToCharArray();
                Array.Sort(caracteres);
                var key = new string(caracteres);

                if (!map.ContainsKey(key))
                    map[key] = new List<string>();

                map[key].Add(s);
            }

            return new List<IList<string>>(map.Values);
        }
        public static void Rotate()
        {
            int[][] matrix = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
            // expected: [[7,4,1],[8,5,2],[9,6,3]]
            int left = 0;
            int right = matrix.Count() - 1;

            while (left < right)
            {
                for (int i = 0; i < right - left; i++)
                {
                    int top = left;
                    int bottom = right;

                    int topLeft = matrix[top][left + i];

                    matrix[top][left + i] = matrix[bottom - i][left];

                    matrix[bottom - i][left] = matrix[bottom][right - i];

                    matrix[bottom][right - i] = matrix[top + i][right];

                    matrix[top + i][right] = topLeft;
                }

                right--;
                left++;
            }
        }
        public static object TwoSum()
        {
            int[] numbers = [2, 7, 11, 15];
            int target = 9;

            int i = 0;
            int j = numbers.Count() - 1;

            while (i < j)
            {
                var result = numbers[i] + numbers[j];
                if (result == target)
                    return new int[i, j];

                if (result > target)
                    j--;
                else
                    i++;
            }

            throw new Exception("No two sum solution");
        }
        public static IList<IList<int>> ThreeSum()
        {
            int[] nums = [0, 0, 0, 0];
            Array.Sort(nums);

            // iterates the array
            IList<IList<int>> valid = new List<IList<int>>();
            for (int i = 0; i < nums.Count(); i++)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                var baseNumber = nums[i];
                var left = i + 1;
                var right = nums.Count() - 1;
                while (left < right)
                {
                    var result = baseNumber + nums[left] + nums[right];
                    if (result == 0)
                    {
                        valid.Add([baseNumber, nums[left], nums[right]]);
                        left++;
                        while (nums[left] == nums[left - 1] && left < right)
                        {
                            left++;
                        }
                    }
                    if (result < 0)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return valid;
        }
    }
}
