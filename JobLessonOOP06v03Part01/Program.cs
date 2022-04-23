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
            mybankAccount1.Print();
            BankAccount mybankAccount2 = new BankAccount(TypeBankAccount.Debet);
            mybankAccount2.Print();
            mybankAccount1.Transfer(mybankAccount2, 500);

            Console.ReadLine();
        }
    }
}
