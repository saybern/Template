// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Bank; 

/// <summary>Базовый класс обработчиков для события в банке.</summary>
public class BankAccountHandlers : IBankAccountHandlers {

 private readonly Action<string> _action;

  /// <summary>
  /// Инициализирует новый экземпляр класса с начальной суммой средств.
  /// </summary>
  /// <param name="action">Обработчик.</param>
  public BankAccountHandlers(Action<string> action) => _action=action;

  public void Print(IBankAccount sender,IBanktEventArgs e) {
    _action($"Сумма транзакции: {e.Sum} руб.");
    _action(e.Msg);
    _action($"Текущая сумма на счете {sender.Sum} руб.");
  }
}