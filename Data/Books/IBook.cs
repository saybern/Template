// ----------------------------------------------------------------------------
namespace Template.Data.Books; 

/// <summary>Интерфейс книги.</summary>
public interface IBook {

  /// <summary>Идентификатор книги.</summary>
  int Id { get; set; }

  /// <summary>Название книги.</summary>
  string Title { get; set; }
}