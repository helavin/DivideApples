using System;
using System.Collections.Generic;
using System.Linq;



namespace Apples
{
    class Person
    {
        internal bool isNation = false;
        internal string name;
        internal int countOfApples = 0;

        internal List<int> apples = new List<int>();

        public Person(string name)
        {
            this.name = name;
        }

        public Person(bool isNation)
        {
            this.isNation = isNation;
            this.name = "Государства";
        }

        public void SetCountOfApples()
        {
            if (isNation)
                return;
            decimal number;
            Console.Write($"Введите количество яблок для {name}: ");
            string input = Console.ReadLine();

            bool result = decimal.TryParse(input, out number);
            if (result == true && number >= 0 && number < int.MaxValue)
            {
                countOfApples = (int)number;
                apples.Add((int)number);
                Console.WriteLine($"У {name} {countOfApples} яблок.");
            }
            else
            {
                Console.WriteLine("Упс! Что-то пошло не так...");
                Console.WriteLine($"У {name} {countOfApples} яблок.");
            }
        }        

        public void GetInfo()
        {
            Console.WriteLine($"\tУ {name} {countOfApples} яблок.");
            Console.WriteLine($"\tИстория изменения количества яблок у {name}: {string.Join(", ", apples)}");
            Console.WriteLine($"\tВсего у {name} {apples.Sum()} яблок!\n");
        }
    }
}
