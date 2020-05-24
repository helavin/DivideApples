using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Apples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Жили-были Маша и Витя. Однажды послала их мама за яблоками.");

            List<Person> persons = new List<Person>();
            Person Masha = new Person("Маши");
            Person Vitya = new Person("Вити");
            Person Nation = new Person(true);
            persons.AddRange(new List<Person> { Masha, Vitya, Nation });
            bool isFirst = true;

            string ifContinue = "";
            do
            {
                if (!isFirst)
                {
                    Console.Write("\n Отправить детей за яблоками ещё раз? (Да - y / Нет - n): ");
                    ifContinue = Console.ReadLine();
                }
                isFirst = false;

                if (!ifContinue.Equals("n"))
                {
                    persons.ForEach(p => p.SetCountOfApples());
                    DivideEqually(ref persons, ref Nation.countOfApples);
                }
                else
                {
                    Console.WriteLine("Досвидания.");
                }

            } while (ifContinue != "n");
        }

        private static void DivideEqually(ref List<Person> persons, ref int countNation)
        {
            int amount = 0;
            persons.Where(x => !x.isNation).ToList()
                .ForEach(p => amount += p.countOfApples);
            Console.WriteLine($"Всего у детей: {amount} яблок.");

            Console.Write("Процент яблок для государства: ");
            decimal percent;
            var input = Console.ReadLine();
            bool result = decimal.TryParse(input, out percent);
            if (result == true && percent > 0 || percent <= 100)
                countNation = amount * (int)percent / 100;
            var balance = amount - countNation;

            if (balance % 2 != 0)
            {
                balance--;
                countNation++;
            }

            Console.WriteLine($"Государству отдали {countNation} яблок, осталось {balance} " +
                $"\nТеперь поделим яблоки поровну между детьми...\n");

            int equally = balance / 2;
            foreach (var p in persons)
            {
                if (!p.isNation)
                {
                    p.countOfApples = equally;
                    p.apples.Add(-(p.apples.Last() - equally));
                }
                else
                {
                    p.apples.Add(p.countOfApples);
                }
                p.GetInfo();
            }
        }
    }
}
