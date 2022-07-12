// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Bank;

/// <summary>Базовый класс данных для события в банке.</summary>
public class BankEventArgs : IBanktEventArgs  {

  /// Инициализирует новый экземпляр класса.</summary>
  public BankEventArgs() { }

  public string Msg { get; set; }
  public int Sum { get; set; }
}