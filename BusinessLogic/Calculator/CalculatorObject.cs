using System.Dynamic;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Calculator;

/// <summary>Класс калькулятора на основе DLR.</summary>
public class CalculatorObject<T> : DynamicObject 
  where T: struct {

  // Словарь для хранения свойств.
  readonly Dictionary<string,object> _members = new();

  // Установка свойства.
  public override bool TrySetMember(SetMemberBinder binder,object value) {
    if(value is null) return false;

    _members[binder.Name]=value;

    return true;
  }

  // Получение свойства.
  public override bool TryGetMember(
    GetMemberBinder binder,out object result) {
    result=null;

    if(!_members.ContainsKey(binder.Name)) return false;

    result=_members[binder.Name];

    return true;
  }

  // Вызов метода.
  public override bool TryInvokeMember(
    InvokeMemberBinder binder,object[] args,out object result) {

    // Получаем метод по имени.
    dynamic method = _members[binder.Name];

    // Вызываем метод, передавая значение параметров args.
    method((T)args[0]);

    // Указываем, что метод выполнился успешно.
    result=this;

    return result is not null;
  }
}

/* Example of execution in the executing code.

  dynamic dyn = new CalculatorObject<int>();
  dyn.Result=0;
  Action<int> Add = (int num) => { dyn.Result+=num; };
  Action<int> Sub = (int num) => { dyn.Result-=num; };
  dyn.Add=Add;
  dyn.Sub=Sub;
  dyn.Add(10).Sub(100).Add(50);
  Console.WriteLine(dyn.Result);
*/