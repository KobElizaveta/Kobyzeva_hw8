using Kobyzeva_hw8_Tumakov.Class;
using Kobyzeva_hw8_Tumakov.Enum;

namespace Kobyzeva_hw8_Tumakov
{
    internal class Program
    {
        static BankAccount AddAccount()
        {
            bool flag = true;
            BankAccount NewAccount = null;
            while (flag)
            {
                Console.Write("Баланс счета: ");
                bool isParseBalance = decimal.TryParse(Console.ReadLine(), out decimal balance);
                Console.Write("Тип счета (DepositeAccount, CreditAccount, CurrentAccount): ");
                bool isParseTypeAcc = AccountType.TryParse(Console.ReadLine(), out AccountType accountType);
                if (!isParseBalance | !isParseTypeAcc)
                {
                    Console.WriteLine("Неверно введены данные, попробуйте заново");
                }
                else
                {
                    try
                    {
                        NewAccount = new BankAccount(balance, accountType);
                        Console.WriteLine("Данные добавлены.");
                        return NewAccount;
                    }
                    catch
                    {
                        Console.WriteLine("Возникла ошибка. Данные не добавлены.");
                    }
                }
            }
            return NewAccount;
        }

        static void Task92()
        {
            Console.WriteLine("Упражнение 9.2");
            Console.WriteLine("Добавление счёта");
            BankAccount bank = AddAccount();
            bool isContinue = true;
            while (isContinue)
            {
                Console.WriteLine("1 - Снятие со счета; 2 - Пополнение счёта; 3 - Чтение данных; " +
                    "4 - Перевод с другого счёта; 5 - Чтение информации о транзакций; 6 - Выйти");
                Console.Write("Выберите номер действия:  ");
                int.TryParse(Console.ReadLine(), out int action);
                bool isCommit = true;
                if (action == 1 || action == 2 || action == 4)
                {
                    Console.Write("Введите сумму: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal sum))
                    {
                        if (action == 1) { isCommit = bank.Withdrawal(sum); }
                        else if (action == 2) { isCommit = bank.Deposit(sum); }
                        else
                        {
                            Console.WriteLine("Добавление счета - отправителя");
                            BankAccount bankFrom = AddAccount();
                            isCommit = bank.Transfer(bankFrom, sum);
                        }
                    }
                    else { Console.WriteLine("Сумма введена неверно. Операция не выполнена"); }
                }
                else if (action == 3) { bank.PrintOnConsole(); }
                else if (action == 5) { bank.ReadTransaction(); }
                else if (action == 6) { isContinue = false; }
                else { Console.WriteLine("Не удалось распознать номер команды"); }

                if (isCommit) { Console.WriteLine("Действие выполнено"); }
                else { Console.WriteLine("Действие НЕ выполнено"); }
            }
        }

        static void Task91_hw()
        {
            Console.WriteLine("Создание пустого экземпляра песни: ");
            Song songEmpty = new Song();
            songEmpty.PrintInfo();

            Console.WriteLine("Создание экземпляра песни с данными о имени и исполнителе: ");
            Console.Write("Название:  ");
            string name = Console.ReadLine();
            Console.Write("Исполнитель:  ");
            string author = Console.ReadLine();
            Song songWithoutPrev = new Song(name, author);
            songWithoutPrev.PrintInfo();

            Console.WriteLine("Создание экземпляра песни с данными о имени и исполнителе и указанием предыдущей песни: ");
            Console.Write("Название:  ");
            string name2 = Console.ReadLine();
            Console.Write("Исполнитель:  ");
            string author2 = Console.ReadLine();
            Song songWithtPrev = new Song(name2, author2, songWithoutPrev);
            songWithtPrev.PrintInfo();
            Console.WriteLine($"Предыдущая песня: {songWithtPrev.Prev.Name}");
        }
        static void Main(string[] args)
        {
            Task92();
            Task93();

            Task91_hw();
        }
    }
}
