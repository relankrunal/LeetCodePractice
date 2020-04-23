using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice
{
    class Program
    {
        static void Main(string[] args)
        {


            Solution s = new Solution();

            var output = s.Maximum69Number(6699); ///9669 6699 [-10,12,-20,-8,15]
            int[] arr = { 1111, 7644, 1107, 6978, 8742, 1, 7403, 7694, 9193, 4401, 377, 8641, 5311, 624, 3554, 6631 };
            //{ 1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
            //{ 10, 100, 1000, 10000 };//{ 0,1,2,3,4,5,6,7,8};// 

            int[] nums = { 1, 2, 3, 4, 5 };
            int[] index = { 0, 1, 2, 3, 1 };
            s.CreateTargetArray(nums, index);
            arr = s.SortByBits(arr);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            bool returnValue = s.CheckIfExist(arr);

            Console.WriteLine(returnValue);
            Console.ReadLine();
        }
    }


    public class Solution
    {
        public int Maximum69Number(int num)
        {

            if (num == 0)
            {
                int[] num1 = new int[1] { 0 };
            }

            var digits = new List<int>();
            while (num > 0)
            {
                digits.Add(num % 10);
                num /= 10;
            }

            var arr = digits.ToArray().Reverse().ToArray();
            bool flag = false;
            for (int i = 0; i < arr.Length; i++)
            {

                if (arr[i] == 6 && !flag)
                {
                    arr[i] = 9;
                    flag = true;
                }
                num += arr[i] * Convert.ToInt32(Math.Pow(10, arr.Length - i - 1));

            }

            //for (int i = 0; i < arr.Length; i++)
            //{

            //}
            return num;
        }

        public bool CheckIfExist(int[] arr)
        {
            List<int> arraList = arr.ToList();
            arraList.Sort();
            for (int i = 0; i < arraList.Count() - 1; i++)
            {
                for (int j = i + 1; j < arraList.Count(); j++)
                {
                    if (arraList[i] == 0 && arraList[j] == 0)
                    {
                        return true;
                    }
                    else if (arraList[i] == 2 * arraList[j] || 2 * arraList[i] == arraList[j])
                    {
                        return true;
                    }
                }

            }

            return false;
        }

        public int[] SortByBits(int[] arr)
        {
            List<int> numbers = new List<int>();
            Dictionary<int, List<int>> pairs = new Dictionary<int, List<int>>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (!pairs.TryGetValue(Convert.ToString(arr[i], 2).Count(x => x == '1'), out numbers))
                {
                    numbers = new List<int>();
                }
                else
                {
                    pairs.Remove(Convert.ToString(arr[i], 2).Count(x => x == '1'));
                }
                numbers.Add(arr[i]);

                pairs.Add(Convert.ToString(arr[i], 2).Count(x => x == '1'), numbers);

            }

            numbers = new List<int>();
            //iterate through Dic<int,List<int>>

            var Keys = pairs.Keys.OrderBy(x => x).ToList();

            foreach (var item in Keys)
            {
                pairs[item].Sort();
                foreach (var items in pairs[item])
                {
                    numbers.Add(items);
                }

                // numbers.Add();
            }




            /*
            pairs.ToList()
               .ForEach(a => a.Value.ForEach(num => numbers.Add(num))
            );*/

            if (pairs.Count() == 1)
            {
                return numbers.ToArray().OrderBy(i => i).ToArray();
            }

            else
                return numbers.ToArray();
        }

        public static string GetnonRepeatingChar(string abc)
        {
            char[] stringS = abc.ToCharArray();

            stringS.OrderBy(x => x);

            List<string> matching = new List<string>();

            for (int i = 0; i < stringS.Length; i++)
            {
                for (int j = i + 1; j < stringS.Length; j++)
                {
                    if (stringS[i] == stringS[j])
                    {
                        break;
                    }
                    else if (j == stringS.Length)
                    {
                        return stringS[i].ToString();
                    }

                }
            }
            return "no Result found";
        }

        public int[] CreateTargetArray(int[] nums, int[] index)
        {
            int[] targetArray = new int[nums.Length];

            foreach (int i in index)
            {
                if (targetArray[i] != 0)
                {

                    for (int j = 0; j < targetArray.Count(); j++)
                    {
                        if (targetArray[j] == 0)
                        {
                            targetArray[j] = targetArray[j - 1];
                        }
                    }

                    if (i + 1 != targetArray.Count())
                    {

                        targetArray[i] = nums[i];
                    }



                }
                else
                {
                    targetArray[i] = nums[i];
                }


            }

            return targetArray;
        }

       

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {

            return t1;

        }

    }
}
