using System.ComponentModel.DataAnnotations;
// --
using Template.Data.Countries;
// ----------------------------------------------------------------------------
namespace Template.Data.Persons; 

/// <summary>Базовый класс человека.</summary>
public class Person : IPerson {

  [Required()]
  public int Id { get; set; }

  [Required(AllowEmptyStrings = false,ErrorMessage =
    "Значение {0} является обязательным")]
  public virtual string Name { get; set; }

  public virtual bool Gender { get; set; }

  [Range(0,150,ErrorMessage = "Допустимое значение {0}: {1} - {2}")]
  public virtual int Age { get; set; }

  [Range(2,200,ErrorMessage = "Допустимое значение {0}: {1} - {2}")]
  public virtual double Weight { get; set; }

  public virtual ECountry Country { get; set; }
}