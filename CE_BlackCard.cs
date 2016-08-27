using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_Black_Card
{
    internal class CE_BlackCard
    {
        private static void Main(string[] args)
        {
            var line = "Zacf Hzzemo Pixud Zeuvbe Zwek Yop | 15";
            var arr = line.Split('|').ToList();
            var num = int.Parse(arr[arr.Count - 1]);
            var index = 0;
            arr.RemoveAt(arr.Count - 1);
            var arr1 = arr[0].Split(' ').ToList();
            arr1.Remove("");

            Console.WriteLine(GetName(arr1, num, index));
        }

        private static string GetName(List<String> arr1, int num, int index)
        {
            if (arr1.Count() == 1)
                return arr1[0].ToString();

            for (int i = 0; i < num; i++)
            {
                if (index > arr1.Count() - 1)
                    index = 0;

                index++;

                if (i == num - 1)
                {
                    arr1.RemoveAt(index - 1);
                    index = 0;
                    GetName(arr1, num, index);
                }
            }

            return arr1[0].ToString();
        }
    }
}