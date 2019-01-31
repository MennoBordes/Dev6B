using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace map_reduce
{
  static class map_reduce
  {
    public static IEnumerable<T2> Map<T1, T2>(IEnumerable<T1> collection, Func<T1, T2> transformation)
    {
      T2[] result = new T2[collection.Count()];
      for (int i = 0; i < collection.Count(); i++)
      {
        result[i] = transformation(collection.ElementAt(i));
      }
      return result;
    }

    public static IEnumerable<T> Where<T>(IEnumerable<T> collection, Func<T, bool> condition)
    {
      List<T> result = new List<T>();
      for (int i = 0; i < collection.Count(); i++)
      {
        if(condition(collection.ElementAt(i)))
        {
          result.Add(collection.ElementAt(i));
        }
      }
      return result;
    }
  }
  class Intermediate
  {
    public static int[] Square(int[] l)
    {
      int[] squares = new int[l.Length];
      for (int i = 0; i < l.Length; i++)
      {
        squares[i] = l[i] * l[i];
      }
      return squares;
    }

    public static string[] Convert<T>(T[] input)
    {
      string[] result = new string[input.Length];
      for (int i = 0; i < input.Length; i++)
      {
        result[i] = input[i].ToString();
      }
      return result;
    }
  }

  class EmployeeTuple
  {
    public Tuple<int, string, string, char, double> Tuple { get; set; }

    public EmployeeTuple(Tuple<int, string, string, char, double> tuple)
    {
      this.Tuple = tuple;
    }
    public EmployeeTuple(int id, string name, string surname, char sex, double salary)
    {
      Tuple = new Tuple<int, string, string, char, double>(id, name, surname, sex, salary);
    }

    public static List<EmployeeTuple> RaiseSalary(List<EmployeeTuple> employees)
    {
      List<EmployeeTuple> result = new List<EmployeeTuple>();
      for (int i = 0; i < employees.Count; i++)
      {
        result[i] = new EmployeeTuple
        (
          employees[i].Tuple.Item1,
          employees[i].Tuple.Item2,
          employees[i].Tuple.Item3,
          employees[i].Tuple.Item4,
          employees[i].Tuple.Item5 + employees[i].Tuple.Item5 * 0.1
        );
      }
      return result;
    }
  }
  class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public char Sex { get; set; }
    public double Salary { get; set; }
    public Employee(int id, string name, string surname, char sex, double salary)
    {
      Id = id;
      Name = name;
      Surname = surname;
      Sex = sex;
      Salary = salary;
    }
    public static List<Employee> RaiseSalary(List<Employee> employees)
    {
      List<Employee> result = new List<Employee>();
      for (int i = 0; i < employees.Count; i++)
      {
        result.Add(new Employee
        (
          employees[i].Id,
          employees[i].Name,
          employees[i].Surname,
          employees[i].Sex,
          employees[i].Salary + employees[i].Salary * 0.1
        ));
      }
      return result;
    }
  }
}
