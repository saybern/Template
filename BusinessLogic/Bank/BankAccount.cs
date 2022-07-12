// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Bank;

/// <summary>Базовый класс банка.</summary>
public class BankAccount : IBankAccount {  

  private int _sum;
  private BankHandler _notify;
  private readonly IBanktEventArgs  _baea;

  /// <summary>
  /// Инициализирует новый экземпляр класса с начальной суммой средств.
  /// </summary>
  /// <param name="baea">Данные для события в банке.</param>
  /// <param name="sum">Сумма средств на банковском счете.</param>
  public BankAccount(IBanktEventArgs baea,int sum) {
    _baea=baea;
    _sum=sum;
  }

  public int Sum => _sum;

  public event BankHandler Notify {
    add => _notify+=value;
    remove => _notify-=value;
  }

  public void Put(int sum) {
    _sum+=sum;

    _baea.Sum=sum;
    _baea.Msg=$"На банковский счет поступило {sum} руб.";

    _notify?.Invoke(this,_baea);
  }
  
  public void Take(int sum) {
    if(_sum>=sum) {
      _sum-=sum;

      _baea.Sum=sum;
      _baea.Msg=$"C банковского счета снято {sum} руб.";

      _notify?.Invoke(this,_baea);
    }
    else {

      _baea.Sum=sum;
      _baea.Msg=$"Недостаточно средств на счете.";

      _notify?.Invoke(this,_baea); 
    }
  }
}