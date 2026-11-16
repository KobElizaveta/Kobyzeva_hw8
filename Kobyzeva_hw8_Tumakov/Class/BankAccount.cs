using Kobyzeva_hw8_Tumakov.Enum;

namespace Kobyzeva_hw8_Tumakov.Class
{
    public class BankAccount
    {
        private static ulong accountNumberInf = 0;
        private Queue<BankTransaction> Transactions = new Queue<BankTransaction>();
        public string AccountNumber;
        public decimal Balance;
        public AccountType AccountType;
        public BankAccount()
        {
            accountNumberInf++;
            AccountNumber = accountNumberInf.ToString("D20");
            Balance = 0;
            AccountType = AccountType.DepositeAccount;
        }
        public BankAccount(decimal balanceUser, AccountType typeAccountUser)
        {
            accountNumberInf++;
            AccountNumber = accountNumberInf.ToString("D20");
            Balance = balanceUser;
            AccountType = typeAccountUser;
        }

        public void PrintOnConsole()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}\nБаланс: {Balance}\nТип счета: {AccountType}");
        }

        public bool Deposit(decimal sum)
        {
            Balance += sum;

            BankTransaction newTransaction = new BankTransaction(sum);
            Transactions.Enqueue(newTransaction);

            return true;
        }

        public bool Withdrawal(decimal sum)
        {
            if ((Balance - sum) < 0)
            {
                return false;
            }
            else
            {
                Balance -= sum;

                BankTransaction newTransaction = new BankTransaction(sum);
                Transactions.Enqueue(newTransaction);

                return true;
            }
        }

        public bool Transfer(BankAccount AccountFrom, decimal sum)
        {
            bool isWithdrawal = AccountFrom.Withdrawal(sum);
            if (isWithdrawal)
            {
                Deposit(sum);

                BankTransaction newTransaction = new BankTransaction(sum);
                Transactions.Enqueue(newTransaction);

                return true;
            }
            return false;
        }

        public void ReadTransaction()
        {
            Console.WriteLine($"Информация о транзакции банка с номером {AccountNumber}");
            foreach(BankTransaction transaction in Transactions)
            {
                Console.WriteLine($"Дата: {transaction.Time.ToString()} ; сумма : {transaction.Sum.ToString()}");
            }
        }

    }
}
