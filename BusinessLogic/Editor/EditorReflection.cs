using System.Reflection;
// --
using Template.Data.Books;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Editor;

/// <summary>Класс редактора с примером рефлексии.</summary>
public sealed class EditorReflection : IEditor {

  private readonly IBook _book;
  private Type _dllType;
  public object _dllInstance;

  /// <summary>Инициализирует новый экземпляр класса.</summary>
  public EditorReflection() 
    => _book=new Book() { Id=1,Title="Отражение редактора" };

  public IBook Book => _book;

  /// <summary>Получаем тип и экземпляр инстанса dll сборки.</summary>
  private void GetDllInstance() {
    // Загружаем сборку.
    Assembly asm = Assembly.LoadFrom("Template.dll");
    
    // Получаем тип данных.
    _dllType = asm.GetType("Template.BusinessLogic.Editor.Editor")
      ??throw new Exception("В сборке отсутствует необходимый тип данных."+
      "\nTestData.BusinessLogic.BLEditor.Editor.");

    // Создаем экземпляр класса.
    _dllInstance=Activator.CreateInstance(_dllType,new object[] { _book });
  }

  public string Read() {
    if(_dllInstance is null) GetDllInstance();

    // Получаем метод.
    MethodInfo read = _dllType.GetMethod("Read");

    // Получаем параметры.
    object[] parameters = read.GetParameters()
      .Select(t => t.RawDefaultValue).ToArray();

    // Вызываем метод.
    string res = read?.Invoke(_dllInstance,parameters).ToString();

    return res;
  }

  public void Record(string text = "Привет мир!" +
    "\nТестовый пример отражения.") {
    if(_dllInstance is null) GetDllInstance();

    MethodInfo read = _dllType.GetMethod("Record");

    object[] parameters = read.GetParameters()
      .Select(t => t.RawDefaultValue).ToArray();

    parameters[0]=text;

    read?.Invoke(_dllInstance,parameters);
  }

  public void Dispose() {
    if(_dllInstance is null) return;

    MethodInfo dispose = _dllType.GetMethod("Dispose");
    dispose?.Invoke(_dllInstance,null);

    GC.SuppressFinalize(this);
  }
}