using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Number n0 = new Number(0);
            Number n1 = new Number(2);
            Number n2 = new Number(1);

            Number[] numbers = new Number[3];
            numbers[0] = n0;
            numbers[1] = n1;
            numbers[2] = n2;

            NumberComparer numCompare = new NumberComparer();

            Array.Sort(numbers, numCompare);

            foreach(Number number in numbers)
            {
                Console.WriteLine(number.Num);
            }
            Console.ReadLine();
        }
    }

    public class NumberComparer : IComparer<Number>
    {
        public int Compare(Number x, Number y)
        {
            if(x.Num > y.Num)
            {
                return -1;
            }
            else if(x.Num < y.Num)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }


    public class Number
    {
        private int num;

        public Number(int num)
        {
            this.Num = num;
        }

        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }
    }
}
