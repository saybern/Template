using System.ComponentModel.DataAnnotations;
// ----------------------------------------------------------------------------
namespace Template.Data.Persons;

/// <summary>Базовый класс работника.</summary>
public class Employee : Person, IEmployee {

  public int IdCompany { get; set; }

  [StringLength(100,MinimumLength = 5,ErrorMessage =
    "Допустимое значение {0}: {2} - {1} символов")]
  public virtual string Post { get; set; }

  [DataType(DataType.Date)]
  [Range(typeof(DateTime),"1/1/1950","1/1/2050",ErrorMessage =
    "Допустимое значение {0}: {1} - {2}")]
  public virtual DateTime RegistrationDate { get; set; }

  [Range(10000,1000000,ErrorMessage =
    "Допустимое значение {0}: {1} - {2}")]
  public virtual decimal Salary { get; set; }

  [RegularExpression(
    @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$",
    ErrorMessage = "Допустимое значение {0} указано не верно")]
  public virtual string Email { get; set; }
}