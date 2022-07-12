// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Bank;

/// <summary>Интерфейс обработчиков для события в банке.</summary>
public interface IBankAccountHandlers {

  /// <summary>Вывод данных на пользовательский интерфейс.</summary>
  /// <param name="sender">Отправитель.</param>
  /// <param name="e">Аргументы события.</param>
  void Print(IBankAccount sender,IBanktEventArgs e);
}