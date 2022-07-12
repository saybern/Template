using Template.Data.Countries;
// ----------------------------------------------------------------------------
namespace Template.Data.Persons;

/// <summary>Интерфейс человека.</summary>
public interface IPerson {

  /// <summary>Идентификатор человека.</summary>
  int Id { get; set; }

  /// <summary>Имя человека.</summary>
  string Name { get; set; }

  /// <summary>Пол человека.</summary>
  bool Gender { get; set; }

  /// <summary>Возраст человека.</summary>
  int Age { get; set; }

  /// <summary>Вес человека.</summary>
  double Weight { get; set; }

  /// <summary>Страна проживания человека.</summary>
  ECountry Country { get; set; }
}