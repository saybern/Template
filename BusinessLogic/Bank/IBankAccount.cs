// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Bank;

/// <summary>Делегат для события.</summary>
/// <param name="sender">Отправитель.</param>
/// <param name="e">Аргументы события.</param>
public delegate void BankHandler(IBankAccount sender,IBanktEventArgs e);

/// <summary>Интерфейс банка.</summary>
public interface IBankAccount {

  /// <summary>Событие для обработчиков.</summary>
  event BankHandler Notify;

  /// <summary>Сумма на банковском счете.</summary>
  int Sum { get; }

  /// <summary>Добавляет средства на банковский счет.</summary>
  /// <param name="sum">Сумма операции.</param>
  void Put(int sum);

  /// <summary>Снимает средства с банковского счета.</summary>
  /// <param name="sum">Сумма операции.</param>
  void Take(int sum);
}

/* Example of execution in the executing code.

  IBankAccount bank = new BankAccount(new BankEventArgs(), 1000);
  IBankAccountHandlers bankH = new BankAccountHandlers(Console.WriteLine);

  bank.Notify+=bankH.Print;
  bank.Put(100);
  bank.Take(100);
*/