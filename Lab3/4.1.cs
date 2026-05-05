//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lab.Lab3
//{
//    class Program
//    {
  
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Введите число дней");
//            int number = Convert.ToInt32(Console.ReadLine());
//            Console.WriteLine("Введите год");
//            int numberYear = Convert.ToInt32(Console.ReadLine());

//            int dayFeb = 28;
//            if ((numberYear / 4 == 0) && (numberYear / 100 != 0 && numberYear / 400 != 0)) 
//            {
//                dayFeb = 29;
//            }

//            if (number < 1)
//            {
//                Console.WriteLine($"{number} меньше 1");
//                return;
//            }
//            if (number > 365)
//            {
//                Console.WriteLine($"{number} больше 365");
//                return;
//            }

//            if (number <= 31)
//            {
//                Console.WriteLine($"{number} Января"); 
//                return;
//            }
//            else
//            {
//                number -= 31;
//            }

//            if (number <= dayFeb)
//            {
//                Console.WriteLine($"{number} Февраля");
//                return;
//            }
//            else
//            {
//                number -= dayFeb;
//            }

//            if (number <= 31)
//            {
//                Console.WriteLine($"{number} Марта");
//                return;
//            }
//            else
//            {
//                number -= 31;
//            }





//            if (number <= 30)
//            {
//                Console.WriteLine($"{number} Апреля");
//                return;
//            }
//            else
//            {
//                number -= 30;
//            }


//            if (number <= 31)
//            {
//                Console.WriteLine($"{number} Мая");
//                return;
//            }
//            else
//            {
//                number -= 31;
//            }


//            if (number <= 30)
//            {
//                Console.WriteLine($"{number} Июня");
//                return;
//            }
//            else
//            {
//                number -= 30;
//            }

//            if (number <= 31)
//            {
//                Console.WriteLine($"{number} Июля");
//                return;
//            }
//            else
//            {
//                number -= 31;
//            }


//            if (number <= 31)
//            {
//                Console.WriteLine($"{number} Августа");
//                return;
//            }
//            else
//            {
//                number -= 31;
//            }


//            if (number <= 30)
//            {
//                Console.WriteLine($"{number} Сентября");
//                return;
//            }
//            else
//            {
//                number -= 30;
//            }


//            if (number <= 31)
//            {
//                Console.WriteLine($"{number} Октября");
//                return;
//            }
//            else
//            {
//                number -= 31;
//            }


//            if (number <= 30)
//            {
//                Console.WriteLine($"{number} Ноября");
//                return;
//            }
//            else
//            {
//                number -= 30;
//            }


//            if (number <= 31)
//            {
//                Console.WriteLine($"{number} Декабря");
//                return;
//            }
//            else
//            {
//                number -= 31;
//            }

//        }



//    }
//}
