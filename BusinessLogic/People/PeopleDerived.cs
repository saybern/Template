using Template.Data.Persons;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.People;

/// <summary>Наследуемый класс людей.</summary>
public class PeopleDerived : People {

  /// <summary>
  /// Инициализирует новый экземпляр класса с добавлением человека.
  /// </summary>
  /// <param name="person">Человек.</param>
  public PeopleDerived(IPerson person)
    : base(person) { }
}