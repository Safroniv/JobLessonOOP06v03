using System;

namespace JobLessonOOP06v03Part01
{
    class BankAccount
    {
        // закрытые поля номер счета, баланс, тип банковского счета из задания 2.5.
        private readonly int _numberBankAccount;
        private decimal _ballanceBankAccount;
        private readonly TypeBankAccount _typeBankAccount;
        // закрытые поля суммы для снятия и суммы которую кладут на счёт из задания 2.5.
        private decimal _sumWithdrawFormBankAccount;
        private decimal _sumPutOnBankAccount;
        //поле генератора уникального номера счёта:
        private static int _generateNumberBankAccount = 0000_0000_1000_0000;
        //Свойства для получения значений полей
        //номер счета, баланс, тип банковского счета из задания 2.4.
        public int NumberBankAccount { get { return _numberBankAccount; } }
        public decimal BallanceBankAccount { get { return _ballanceBankAccount; } }
        public TypeBankAccount TypeBankAccount { get { return _typeBankAccount; } }
        //Свойства для получения и передачи
        //значений суммы для снятия и суммы которую кладут на счёт из задания 2.5.
        public decimal SumWithdrawFormBankAccount
        {
            get { return _sumWithdrawFormBankAccount; }
            set { _sumWithdrawFormBankAccount = value; }
        }
        public decimal SumPutOnBankAccount
        {
            get { return _sumPutOnBankAccount; }
            set { _sumPutOnBankAccount = value; }
        }
        /// <summary>
        /// Метод генерации уникального номера счёта
        /// </summary>
        /// <returns>уникальный номер счёта</returns>
        public static int GenerateNumberBankAccount() { return _generateNumberBankAccount++; }

        /// <summary>
        /// Метод пополняющий сумму на счёте, по заданию 2.5.
        /// </summary>
        /// <param name="sumPutOn">сумма пополнения счёта</param>
        /// <returns>Возвращает балланс</returns>
        public decimal PutOnBankAccount(decimal sumPutOn)
        {
            _sumPutOnBankAccount = sumPutOn;
            if (NumberBankAccount == _numberBankAccount)
            {
                _ballanceBankAccount += _sumPutOnBankAccount;
                PrintPutOn();

            }
            Print();
            return _ballanceBankAccount;

        }
        /// <summary>
        /// Метод для снятия суммы со счёта, с проверкой возможности снятия, по заданию 2.5.
        /// </summary>
        /// <param name="sumWithdraw">сумма снятия со счёта</param>
        /// <returns>Возвращает балланс</returns>
        public decimal WithdrawFromBankAccount(decimal sumWithdraw)
        {
            SumWithdrawFormBankAccount = sumWithdraw;
            if (NumberBankAccount == NumberBankAccount)
            {
                if (SumWithdrawFormBankAccount > BallanceBankAccount)
                {
                    PrintWithdrowError();
                }
                if (SumWithdrawFormBankAccount <= BallanceBankAccount)
                {
                    _ballanceBankAccount -= _sumWithdrawFormBankAccount;
                    PrintWithdrowSucsess();
                }
            }
            Print();
            return _ballanceBankAccount;
        }
        /// <summary>
        /// Метод для перевода денежных средств от одного пользователя дугому, по заданию 3.1.
        /// </summary>
        /// <param name="bankAccountTo">Аккаут пользователя куда переводятся средства</param>
        /// <param name="summTransfer">Сумма для перевода от одного пользователя другому</param>
        public void Transfer(BankAccount bankAccountTo, decimal summTransfer)
        {
            WithdrawFromBankAccount(summTransfer);
            SumWithdrawFormBankAccount = summTransfer;
            if (SumWithdrawFormBankAccount > BallanceBankAccount)
            {
                Console.WriteLine("Невозможно выполнить операцию!" + "\n" +
                    "??????????????????????????????????????????? ");
                bankAccountTo.Print();
            }
            else
            {
                bankAccountTo.PutOnBankAccount(summTransfer);
            }

        }
        //Конструктор по умолчанию
        public BankAccount() : this(100, TypeBankAccount.Current) { }
        //Конструктор для заполнения поля баланс
        public BankAccount(decimal ballanceBankAccount) : this(ballanceBankAccount, TypeBankAccount.Budget) { }
        //Конструктор для заполнения поля тип банковского счета        
        public BankAccount(TypeBankAccount typeBankAccount) : this(2000, typeBankAccount) { }
        //Конструктор для заполнения баланса и типа банковского счета
        public BankAccount(decimal ballanceBankAccount, TypeBankAccount typeBankAccount)
        {
            _numberBankAccount = GenerateNumberBankAccount();
            _ballanceBankAccount = ballanceBankAccount;
            _typeBankAccount = typeBankAccount;
        }

        /// <summary>
        /// Метод вывода информации о счёте пользователя.
        /// </summary>
        public void Print()
        {
            Console.WriteLine(
                $"Банковский счёт пользователя: # {NumberBankAccount} " + "\n" +
                $"Количество средств на счёте пользователя: {BallanceBankAccount } " + "\n" +
                $"Тип счёта: {TypeBankAccount}" + "\n" +
                $"======================================================== ");
        }

        /// <summary>
        /// Метод вывода информации об ошибке снятия средств с банковского счёта
        /// </summary>
        public void PrintWithdrowError()
        {
            Console.WriteLine(
                $"Счёт (Аккаунт) № {NumberBankAccount}" + "\n" +
                $"Невозможно снять данную сумму со счёта № {NumberBankAccount}. " + "\n" +
                $"Сумма {SumWithdrawFormBankAccount} превышает балланс {BallanceBankAccount}" + "\n" +
                $"======================================================== ");
        }
        /// <summary>
        /// Метод вывода информации об успешном снятии средств с банковского счёта
        /// </summary>
        public void PrintWithdrowSucsess()
        {
            Console.WriteLine(
                $"Счёт (Аккаунт) № {NumberBankAccount}" + "\n" +
                $"Сумма {SumWithdrawFormBankAccount} снята со счёта № {NumberBankAccount}. " + "\n" +
                $"Текущий балланс на счёте № {NumberBankAccount} составляет: {BallanceBankAccount}" + "\n" +
                $"-------------------------------------------------------- ");
        }
        /// <summary>
        /// Метод вывода информации о пополнении банковского счёта.
        /// </summary>
        public void PrintPutOn()
        {
            Console.WriteLine(
                $"Счёт (Аккаунт) № {NumberBankAccount}" + "\n" +
                $"Сумма {SumPutOnBankAccount} пополнена на счёт № {NumberBankAccount}. " + "\n" +
                $"Текущий балланс на счёте № {NumberBankAccount} составляет: {BallanceBankAccount}" + "\n" +
                $"+++++++++++++++++++++++++++++++++++++++++++++++++++++++++ ");
        }
        /// <summary>
        /// Переопределение метода Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Возвращает сравнение двух счетов</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            BankAccount bankAccount1 = obj as BankAccount;
            if (ReferenceEquals (this, bankAccount1)) return false;
            return (bankAccount1.BallanceBankAccount==this.BallanceBankAccount)&&(bankAccount1.TypeBankAccount==this.TypeBankAccount);
        }
        /// <summary>
        /// Переопределение метода GetHashCode()
        /// </summary>
        /// <returns>Возвращает Хэш код</returns>
        public override int GetHashCode()
        {
            int hashCode = -1551301353;
            hashCode = hashCode * -1521134295 + _numberBankAccount.GetHashCode();
            hashCode = hashCode * -1521134295 + _ballanceBankAccount.GetHashCode();
            hashCode = hashCode * -1521134295 + _typeBankAccount.GetHashCode();
            hashCode = hashCode * -1521134295 + NumberBankAccount.GetHashCode();
            hashCode = hashCode * -1521134295 + BallanceBankAccount.GetHashCode();
            hashCode = hashCode * -1521134295 + TypeBankAccount.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Для класса банковский счет переопределение оператора == 
        /// </summary>
        /// <param name="bankAccount1">первый банковский счёт для сравнения</param>
        /// <param name="bankAccount2">второй банковский счёт для сравнения</param>
        /// <returns></returns>
        public static bool operator ==(BankAccount bankAccount1, BankAccount bankAccount2)
        {
            return bankAccount1.NumberBankAccount == bankAccount2.NumberBankAccount;
        }
        /// <summary>
        /// Для класса банковский счет переопределение оператора !=
        /// </summary>
        /// <param name="bankAccount1">первый банковский счёт для сравнения</param>
        /// <param name="bankAccount2">второй банковский счёт для сравнения</param>
        /// <returns></returns>
        public static bool operator !=(BankAccount bankAccount1, BankAccount bankAccount2)
        {
            return bankAccount1.NumberBankAccount != bankAccount2.NumberBankAccount;
        }
        /// <summary>
        /// Переопределённый метод ToString()
        /// </summary>
        /// <returns>Возвращает строку информации о счёте</returns>
        public override string ToString()
        {
            return $"Банковский счёт пользователя: # {NumberBankAccount} " + "\n" +
                $"Количество средств на счёте пользователя: {BallanceBankAccount } " + "\n" +
                $"Тип счёта: {TypeBankAccount}" + "\n" +
                $"======================================================== ";
        }

    }
}
