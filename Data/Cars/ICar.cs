// ----------------------------------------------------------------------------
namespace Template.Data.Cars;

/// <summary>Базовый интерфейс машины для тестов.</summary>
public interface ICar {

  /// <summary>Идентификатор.</summary>
  int Id { get; set; }

  /// <summary>Марка.</summary>
  string Brand { get; set; }

  /// <summary>Объем двигателя.</summary>
  double EngineCapacity { get; set; }

  /// <summary>Цвет.</summary>
  string Color { get; set; }

  /// <summary>Дата изготовления.</summary>
  DateTime ProductionDate { get; set; }
}