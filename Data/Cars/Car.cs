// ----------------------------------------------------------------------------
namespace Template.Data.Cars;

/// <summary>Базовый структура машины.</summary>
public struct Car : ICar {

  public int Id { get; set; }

  public string Brand { get; set; }

  public double EngineCapacity { get; set; }

  public string Color { get; set; }

  public DateTime ProductionDate { get; set; }
}

/// <summary>
/// Базовый класс машины для сравнения производительности.
/// </summary>
public class CarClass : ICar {

  public int Id { get; set; }

  public string Brand { get; set; }

  public double EngineCapacity { get; set; }

  public string Color { get; set; }

  public DateTime ProductionDate { get; set; }
}