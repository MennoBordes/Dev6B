using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using map_reduce;

namespace map_reduce
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] intArray = new int[] { 0, 5, 8, 6, 4, 8, 8, 52 };
      int[] res = Intermediate.Square(intArray);

      int[] numbers = { 3, -1, 4, -20, 6 };
      List<Employee> employeeTable = new List<Employee>(new Employee[]
      {
          new Employee(3952,"Frank","Moses",'M',2500.50),
          new Employee(1403,"john","Ford",'M',1200.50),
          new Employee(3433,"Michelle","Brown",'F',3250.25),
          new Employee(3540,"Daniel","Smith",'M',2500.50),
      });
      IEnumerable<Employee> raised = map_reduce.Map(employeeTable, employee =>
      {
        return
            new Employee(
                employee.Id,
                employee.Name,
                employee.Surname,
                employee.Sex,
                employee.Salary + employee.Salary * 0.1);
      });
      IEnumerable<String> converted = map_reduce.Map(numbers, x => x.ToString());
      foreach (var item in converted)
      {
          Console.WriteLine(item);
      }
      IEnumerable<String> converted2 = map_reduce.Map(employeeTable, x => x.ToString());
      foreach (var item in converted2)
      {
          Console.WriteLine(item);
      }
    }
  }
}
