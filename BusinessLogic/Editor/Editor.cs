using System.Text;
using System.ComponentModel.DataAnnotations;
// --
using Template.Data.Books;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Editor;

/// <summary>Базовый класс редактора.</summary>
public class Editor : IEditor {

  // Флаг управления для очистки мусора.
  private bool _disposed = false;

  // Создаем управляемый ресурс.
  private protected FileStream _fs;

  // Указатель на внешний неуправляемый ресурс.
  private IntPtr _handle;

  private protected readonly IBook _book;

  /// <summary>Инициализирует новый экземпляр класса.</summary>
  public Editor() 
    : this(new Book() { Id = 1, Title = "Тестовая книга"}) {}

  /// <summary>
  /// Инициализирует новый экземпляр класса c добавлением книги.
  /// </summary>
  /// <param name="book">Книга.</param>
  public Editor(IBook book) => _book = book;

  public IBook Book => _book;

  /// <summary>Валидация книги.</summary>
  private protected void Valid() {
    ValidationContext context = new(_book);
    List<ValidationResult> results = new();

    if(!Validator.TryValidateObject(_book,context,results,true)) {
      string error = "";
      results.ForEach(t => error += $"\n{t.ErrorMessage}.");

      throw new ArgumentException($"{nameof(_book)} типа {typeof(IBook)} " +
        $"не прошел валидацию. {error}.",
        $"{nameof(_book)} = {_book}.");
    }
  }

  /// <summary>
  /// Считываем файл для чтения, записи и локируем FileStream.
  /// </summary>
  private protected void FS(FileMode fileMode) {
    _fs = new FileStream($"{_book.Title}.txt",
        fileMode,FileAccess.ReadWrite);
    
    _fs.Lock(0,_fs.Length);
  }

  public virtual string Read() {
    Valid();
    FS(FileMode.OpenOrCreate);

    // Выделяем массив для считывания данных из файла.
    byte[] buffer = new byte[_fs.Length];
      
    // Cчитываем данные
    _fs.Read(buffer,0,buffer.Length);
    _fs.Dispose();

    // Декодируем байты в строку.
    return Encoding.Default.GetString(buffer);
  }

  public virtual void Record(string text = "Привет мир!") {
    Valid();
    FS(FileMode.Create);

    // Преобразуем строку в байты.
    byte[] buffer = Encoding.Default.GetBytes($"{text}\n");

    // Запись массива байтов в файл.
    _fs.Write(buffer,0,buffer.Length);
    _fs.Dispose();   
  }

  /* Очистка мусора. 
   * - Данный шаблон, как и все в библиотеки используется только для тестов.
   * - Не применять до тех пор, пока это действительно не понадобится.
   * - Если класс владеет управляемыми ресурсами, 
   * реализуем IDisposable, но не финализатор.
   * - Если класс владеет неуправляемыми ресурсами,
   * реализуем IDisposable и финализатор.
   * - В классах наследниках, переопределяется только метод
   * Dispose(bool disposing), где освобождаются ресурсы наследника
   * и по окончанию вызывается base.Dispose(bool disposing).
  */

  /// <summary>Реализация IDisposable.</summary>
  /* Нельзя делать этот метод виртуальным. 
   * Производный класс не должен иметь возможности переопределять этот метод.
  */
  public void Dispose() {
    Dispose(true); // Освобождаем управляемые и неуправляемые ресурсы.      
    GC.SuppressFinalize(this); // Подавляем финализацию.
  }

  /* Выполняется в двух разных сценариях. 
   * 1. Если disposing имеет значение true, то метод был вызван прямо
   * или косвенно пользовательским кодом. Управляемые и неуправляемые
   * ресурсы могут быть освобождены.
   * 2. Если disposing равно false, метод был вызван средой выполнения
   * из финализатора, и мы не должны ссылаться на другие объекты.
   * Только неуправляемые ресурсы могут быть освобождены.
  */
  protected virtual void Dispose(bool disposing) {
    if(!_disposed) {

      if(disposing) {
        _fs?.Dispose(); // Освобождаем управляемые ресурсы.
      }

      // Освобождаем неуправляемые ресурсы.
      CloseHandle(_handle);
      _handle = IntPtr.Zero;

      _disposed = true; // Указываем, что освобождение было выполнено.
    }
  }

  // Используем interop для вызова метода,
  // необходимого для очистки неуправляемого ресурса.
  [System.Runtime.InteropServices.DllImport("Kernel32")]
  private extern static Boolean CloseHandle(IntPtr handle);

  // Используем синтаксис финализатора C# для завершения кода.
  // Этот финализатор будет запущен только в том случае,
  // если метод Dispose не будет вызван.
  // Это дает нашему базовому классу возможность завершить работу.
  // Нельзя предоставляйть финализатор в типах, производных от этого класса.
  ~Editor() => Dispose(false);
}