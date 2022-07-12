using Template.Data.Books;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.Editor;

/// <summary>Интерфейс редактора.</summary>
public interface IEditor : IDisposable {

  /// <summary>Книга.</summary>
  IBook Book { get; }

  /// <summary>Редактор читает книгу.</summary>
  /// <returns>Содержимое книги.</returns>
  string Read();

  /// <summary>Редактор делает запись в книгу.</summary>
  /// <param name="text">Текст для записи.</param>
  void Record(string text = "Привет мир!");
}

/* Example of execution in the executing code.
 
  Console.WriteLine("IEditor = new Editor");
  IEditor iEditor = new Editor();
  iEditor.Record();
  Console.WriteLine(iEditor.Read());
  iEditor.Dispose();

  // --
  Console.WriteLine("\nEditor = new Editor");
  using(Editor editor = new Editor()) {
    editor.Record();
    Console.WriteLine(editor.Read());
  }

  // --
  Console.WriteLine("\nEditor = new EditorDerived");
  Editor editorDerived = new EditorDerived();
  try {
    editorDerived.Record();
    Console.WriteLine(editorDerived.Read());
  }
  finally {
    editorDerived.Dispose();
  }

  // --
  Console.WriteLine("\nEditorReflection = new EditorReflection");
  using EditorReflection editorReflection = new EditorReflection();
  editorReflection.Record();
  Console.WriteLine(editorReflection.Read());
 */