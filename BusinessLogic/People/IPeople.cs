using Template.Data.Persons;
// ----------------------------------------------------------------------------
namespace Template.BusinessLogic.People;

/// <summary>Интерфейс людей.</summary>
public interface IPeople : IEnumerable<IPerson> {

  /// <summary>Получить всех людей.</summary>
  List<IPerson> GetPeople();    
  
  /// <summary>Получить работников.</summary>
  List<IEmployee> GetEmployees();
}

/* Example of execution in the executing code.
 
  Console.WriteLine("IPeople = new People");
  IPeople iPeople = new People();

  foreach(Person person in iPeople)
    Console.WriteLine(person.Name);

  // --
  Console.WriteLine("\nPeople = new People");
  People people = new();
  IEnumerator<IPerson> enumerator = people.GetEnumerator();

  while(enumerator.MoveNext())
    Console.WriteLine(enumerator.Current.Name);

  // --
  Console.WriteLine("\nPeopleDerived = new PeopleDerived");
  PeopleDerived peopleDrived = new PeopleDerived(new Person() { Name="Jon" });

  foreach(IPerson person in peopleDrived.GetEnumerator(20))
    Console.WriteLine(person.Name);
*/