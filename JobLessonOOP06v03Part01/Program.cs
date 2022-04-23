using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobLessonOOP06v03Part01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount mybankAccount1 = new BankAccount(50000.99m);
            BankAccount mybankAccount2 = new BankAccount(TypeBankAccount.Debet);
            //Тестирование функционирования переопределенных методов и операторов
            Console.WriteLine(mybankAccount1==mybankAccount2);
            Console.WriteLine(mybankAccount1.ToString());
            Console.WriteLine(mybankAccount2.ToString());

            Console.WriteLine($"Сравнение равенства счетов ==. если равны то True, если нет Falce. В итоге получили:" + (mybankAccount1 == mybankAccount2));
            Console.WriteLine($"Сравнение равенства счетов !=. если равны то True, если нет Falce. В итоге получили:" + (mybankAccount1 != mybankAccount2));
            Console.WriteLine(mybankAccount1.Equals(mybankAccount2));
            Console.WriteLine(mybankAccount2.Equals(mybankAccount1));
            Console.WriteLine(mybankAccount1.GetHashCode());
            Console.WriteLine(mybankAccount2.GetHashCode());
            Console.ReadLine();
        }
    }
}
