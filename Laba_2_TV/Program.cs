using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_2_TV
{
    class Program
    {
        private static readonly int Range = 200;
        private static readonly int N = 5;
        private static  double Min;
        private static double Max;
        static void Main(string[] args)
        {
            double[] random = Randomayz();
            double[] x = new double[Range];
            for(int i=0;i<random.Length;i++)
            {
                x[i] = Function(random[i]);
            }
            (Min, Max) = Min_and_Max(x);
            var part = Part(Min, Max);
            var count_interval = Raspred(x, part);

            Out(random);
            Out(x);
            Out(count_interval);
            Console.WriteLine(Min);
            Console.WriteLine(Max);
        }
        private static int[] Raspred(double[] x, double[] part)
        {
            int[] count = new int[6];
            for(int i=0;i<part.Length-1;i++)
            {
                for (int j = 0; j < x.Length;j++)
                {
                    if(part[i]<=x[j]&& x[j]<part[i+1])
                    {
                        count[i]++;
                    }
                }
            }
            return count;
        }
        private static double[] Part(double min, double max)
        {
            double[] partArr = new double[6];
            partArr[0] = Min;
            partArr[5] = Max;
            double sum = Max + Math.Abs(Min);
            var part = sum / N;
            for(int i=1;i<5;i++)
            {
                partArr[i] = partArr[0] + i * part;
            }
            return partArr;
        }
        private static double Function(double lambda)
        {
            return Math.Tan(lambda * Math.PI);
        }
        private static (double , double) Min_and_Max(double[] arr)
        {
            double min = double.MaxValue;
            double max = 0;
            for(int i=0;i<arr.Length;i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }
            return (min, max + 1);
        }
        private static double[] Randomayz()
        {
            Random r = new Random();
            double[] random = new double[Range];
            for(int i=0;i<Range;i++)
            {
                random[i] = r.NextDouble();
            }
            return random;
        }
        private static void Out(Array arr)
        {
            foreach(var e in arr)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine();
        }
    }

    
}
