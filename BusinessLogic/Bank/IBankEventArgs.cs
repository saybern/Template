// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Bank;

/// <summary>Интерфейс данных для события в банке.</summary>
public interface IBanktEventArgs {

  /// <summary>Сообщение.</summary>
  string Msg { get; set; }

  /// <summary>Сумма операции.</summary>
  int Sum { get; set; }
}