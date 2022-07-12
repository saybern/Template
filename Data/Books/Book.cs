using System.ComponentModel.DataAnnotations;
// ----------------------------------------------------------------------------
namespace Template.Data.Books;

/// <summary>Базовый класс книги.</summary>
public sealed class Book : IBook {

  [Required()]
  public int Id { get; set; }

  [StringLength(100,MinimumLength = 2,ErrorMessage =
    "Допустимое значение {0}: {2} - {1} символов")]
  public string Title { get; set; }
}
