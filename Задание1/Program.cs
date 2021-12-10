using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание1
{/*Модель  компьютера  характеризуется  кодом  и  названием  марки компьютера,  типом  процессора,  частотой  работы  процессора,  
  * объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты, стоимостью компьютера в условных единицах и количеством экземпляров,
  * имеющихся в наличии. Создать список, содержащий 6-10 записей с различным набором значений характеристик.
Определить:
- все компьютеры с указанным процессором. Название процессора запросить у пользователя;
- все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя;
- вывести весь список, отсортированный по увеличению стоимости;
- вывести весь список, сгруппированный по типу процессора;
- найти самый дорогой и самый бюджетный компьютер;
- есть ли хотя бы один компьютер в количестве не менее 30 штук?
 */
    class Program
    {
        static void Main(string[] args)
        {

            List<Computer> list_computers = new List<Computer>()


            {
                new Computer() { Code = 1, Brand = "Accer", ProcessorType = "Intel Core i5", Frequency = "2900 МГц", RAM = 8, HardDrive = "250 ГБ ", VideoCard = "3000 МБ", Cost = "130000 ", Count = 3 },
                new Computer() { Code = 1, Brand = "Lenovo", ProcessorType = "Intel Core i7", Frequency = "3800 МГц", RAM = 8, HardDrive = "400 ГБ", VideoCard = "3100 МБ", Cost = "134990", Count = 7 },
                new Computer() { Code = 1, Brand = "Asus", ProcessorType = "AMD Ryzen 5", Frequency = "3800 МГц", RAM = 16, HardDrive = "500 ГБ", VideoCard = "3000 МБ", Cost = "124990", Count = 3 },
                new Computer() { Code = 1, Brand = "Dell", ProcessorType = "DELL Intel Xeon E7", Frequency = "3300 МГц", RAM = 16, HardDrive = "600 ГБ", VideoCard = "3000 МБ", Cost = "155000", Count = 3 },
                new Computer() { Code = 1, Brand = "Msi", ProcessorType = "Intel Core i5", Frequency = "3200 МГц", RAM = 16, HardDrive = "700 ГБ", VideoCard = "3000 МБ", Cost = "160000", Count = 3 },
                new Computer() { Code = 1, Brand = "Accer", ProcessorType = "Intel Core i5", Frequency = "3000 МГц", RAM = 8, HardDrive = "500 ГБ", VideoCard = "3072 МБ", Cost = "131000", Count = 33 },
              };

            //1. Список всех компьютеров с указанным процессором. Название процессора запросить у пользователя;
            Console.WriteLine("Введите нужный тип процессора :  ");
            string pt = Console.ReadLine();
            List<Computer> computers1 = list_computers.Where(d => d.ProcessorType == pt).ToList();

            foreach (Computer d in computers1)
            {
                Console.WriteLine($"Компьюеры с указанным типом процессора {pt}:  {d.Brand }  ");
            }

            // 2.Список всех компьютеров с объемом ОЗУ ( RAM) не ниже, чем указано. Объем ОЗУ запросить у пользователя;

            Console.WriteLine("Введите нужный объем опартивной памяти в ГБ ( целое число):");

            int a = Convert.ToInt32(Console.ReadLine());

            List<Computer> computers2 = list_computers.Where(d => d.RAM >= a).ToList();

            foreach (Computer d in computers2)
            {
                Console.WriteLine($"Компьюеры с с объемом ОЗУ ( RAM) в Гб не ниже указанного: {d.Brand } ,{d.RAM } ");
            }

            //  Cписок, отсортированный по увеличению стоимости
            // SQL 

            //Console.WriteLine("Список , отсортированный по увеличению стоимости ");
            //var computers3 = (from d in list_computers
            //                  orderby d.Cost ascending
            //                  select d).ToList();
            //foreach (var d in computers3)
            //{
            //    Console.WriteLine($" {d.Cost} рублей, {d.Brand} , {d.ProcessorType}, {d.Frequency} , {d.RAM} ,  {d.HardDrive}, {d.VideoCard} ,  {d.Count}  ");
            //}

            // 3. Cписок, отсортированный по увеличению стоимости . LINQ

            Console.WriteLine("Cписок, отсортированный по увеличению стоимости:  ");
            List<Computer> computers4 = list_computers
                                       .OrderBy(d => d.Cost)
                                       .ToList();
            foreach (Computer d in computers4)
            {
                Console.WriteLine($" {d.Cost} рублей, {d.Brand} , {d.ProcessorType}, {d.Frequency} , {d.RAM} ,  {d.HardDrive}, {d.VideoCard} ,  {d.Count}  ");
            }





            //4.вывести весь список, сгруппированный по типу процессора;

            var Groups = from d in list_computers
                         group d by d.ProcessorType;

            foreach (IGrouping<string, Computer> g in Groups)
            {
                Console.WriteLine(g.Key);
                foreach (var t in g)
                { Console.WriteLine($"Марка: {t.Brand}, Частота:{t.Frequency} , Оперативная памнять:{t.RAM} , Жесткий диск:{t.HardDrive}, Видео карта:{t.VideoCard},  Цена:{t.Cost}"); }
                Console.WriteLine();
            }





            //5.найти самый дорогой и самый бюджетный компьютер;

            // -самый дорогой компьютер
            var max = list_computers.Max(d => d.Cost);

            Console.WriteLine($" Максимальная цена компьютера : {max}, рублей  ");

            // - самый дешевый компьютер 

            var min = list_computers.Min(d => d.Cost);

            Console.WriteLine($" Минимальная цена компьютера : {min}, рублей  ");

            //6. Есть ли хотя бы один компьютер в количестве не менее 30 штук?

            Console.WriteLine(" Список компьютеров , которые есть в наличии не менее 30 штук ");

            int b = 30;

            List<Computer> computers6 = list_computers.Where(d => d.Count >= b).ToList();

            foreach (Computer d in computers6)
            {
                Console.WriteLine($"Компьюеры с с объемом ОЗУ ( RAM) в Гб не ниже указанного: {d.Brand } ,колличество : {d.Count } ");
            }





            Console.ReadKey();
        }
        class Computer
        {
            public int Code { get; set; } // код 
            public string Brand { get; set; } // марка компьютера 

            public string ProcessorType { get; set; } // тип процессора

            public string Frequency { get; set; } // частота

            public int RAM { get; set; }// объем оперативной памяти Гб

            public string HardDrive { get; set; }// объем жесткого памяти

            public string VideoCard { get; set; }// объем видеокарты

            public string Cost { get; set; }// стоимость 

            public int Count { get; set; } // колличество  




        }
    }
}
