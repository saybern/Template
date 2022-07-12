// ----------------------------------------------------------------------------
namespace Template.Data.Persons;

/// <summary>Интерфейс работника.</summary>
public interface IEmployee {

  /// <summary>Идентификатор работника в компании.</summary>
  int IdCompany { get; set; }

  /// <summary>Должность работника в компании.</summary>
  string Post { get; set; }

  /// <summary>Дата оформления работника в компании.</summary>
  DateTime RegistrationDate { get; set; }

  /// <summary>Зарплата работника в компании.</summary>
  decimal Salary { get; set; }

  /// <summary>Электронная почта работника в компании.</summary>
  string Email { get; set; }
}