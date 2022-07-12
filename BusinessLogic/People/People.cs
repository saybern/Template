using System.Collections;
// --
using Template.Data.Persons;
using Template.Data.Countries;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.People;

/// <summary>Базовый класс людей.</summary>
public class People : IPeople {

  private protected List<IPerson> _persons = new() {
    new Person {
      Id = 1,
      Name = "Николай",
      Gender = true,
      Age = 44,
      Weight = 86,
      Country = ECountry.Russia,
    },
    new Person {
      Id = 36,
      Name = "Олеся",
      Gender = false,
      Age = 38,
      Weight = 55,
      Country = ECountry.Ukraine,
    },
    new Person {
      Id = 71,
      Name = "Nik",
      Gender = true,
      Age = 24,
      Weight = 72,
      Country = ECountry.USA,
    }
  };
  private protected List<IEmployee> _employees = new() {
    new Employee {
      Id = 23,
      Name = "Anthony",
      Gender = true,
      Age = 32,
      Weight = 102,
      Country = ECountry.France,
      IdCompany = 1,
      Post = "Директор",
      RegistrationDate = new DateTime(2019,10,24),
      Salary = 152832.27m,
      Email = "director@mail.ru",
    },
    new Employee {
      Id = 41,
      Name = "Ирина",
      Gender = false,
      Age = 49,
      Weight = 49,
      Country = ECountry.Russia,
      IdCompany = 6,
      Post = "Бухгалтер",
      RegistrationDate = new DateTime(2010,2,28),
      Salary = 52300.09m,
      Email = "accountant@mail.ru",
    },
    new Employee {
      Id = 71,
      Name = "Nik",
      Gender = true,
      Age = 24,
      Weight = 72,
      Country = ECountry.USA,
      IdCompany = 30,
      Post = "Электрик",
      RegistrationDate = new DateTime(2022,12,15),
      Salary = 38500,
      Email = "electrician@mail.ru",
    }
  };

  /// <summary>Инициализирует новый экземпляр класса.</summary>
  public People() {  }

  /// <summary>
  /// Инициализирует новый экземпляр класса c добавлением человека.
  /// </summary>
  /// <param name="person">Человек.</param>
  public People(IPerson person) {
    _persons.Add(person);
  }

  public virtual List<IPerson> GetPeople() {
    List<IPerson> persons = _persons;

    persons.AddRange(_employees.Select(t => (IPerson)t));

    return persons;
  }

  public List<IEmployee> GetEmployees() => _employees;
  
  public IEnumerator<IPerson> GetEnumerator() {
    List<IPerson> persons = GetPeople();

    for(int t = 0; t<persons.Count; t++)
      yield return persons[t];
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

  public IEnumerable<IPerson> GetEnumerator(int quantity) {
    List<IPerson> persons = GetPeople();

    for(int t = 0; t<quantity; t++)
      if(t<persons.Count) yield return persons[t];
      else yield break;
  }
}