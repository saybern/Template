using System.Text;
// --
using Template.Data.Books;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Editor;

/// <summary>Наследуемый класс редактора.</summary>
public sealed class EditorDerived : Editor {

  private bool _disposed = false;

  /// <summary>Инициализирует новый экземпляр класса.</summary>
  public EditorDerived()
    : base(new Book() { Id = 1,Title = "Наследник редактора" }) { }

  public override string Read() {
    Valid();
    FS(FileMode.OpenOrCreate);

    StreamReader sr = new(_fs,Encoding.Default);
    string text = sr.ReadToEnd();
    
    sr.Dispose();
    _fs.Dispose();

    return $"{text}Базовый метод {nameof(Read)} переопределен.";
  }

  /// <summary>Редактор делает запись в книгу.</summary>
  /// <param name="text">Текст для записи.</param>
  public new void Record(string text = "Привет всем в мире!") {
    Valid();
    FS(FileMode.Create);

    StreamWriter sw = new(_fs,Encoding.Default);
    sw.WriteLine($"{text}\nБазовый метод {nameof(Record)} скрыт.");
    
    sw.Dispose();
    _fs.Dispose();
  }

  protected override void Dispose(bool disposing) {
    if(_disposed)
      return;

    if(disposing) { 
      /* Освобождаем управляемые ресурсы этого класса, не базового.
       *
      */ 
    }

    /* Освобождаем неуправляемые ресурсы этого класса, не базового.
      *
    */

    _disposed = true; // Указываем, что освобождение было выполнено.

    // Вызываем реализацию базового класса.
    base.Dispose(disposing);
  }
}