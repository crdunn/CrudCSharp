using System;
using System.Collections;

namespace CrudOperation
{
class UIDriver
  {
    static ArrayList employees = new ArrayList();
    static int counter = 1;
    static void Main(string[] args)
    {
      seeMenu();
      string option = "";
      while (true) {
        Console.WriteLine("What you you like to do?\n 0: See Menu");
        option = Console.ReadLine(); 
        if (option == "0"){
          seeMenu();
        } else if  (option == "1") {
          seeEmployees(); 
        } else if (option == "2") {
          addEmployee();
        }else if (option == "3") {
          getEmployee();
        } else if  (option == "4") {
          updateEmployee();
        } else if  (option == "5") {
          removeEmployee();
        } else if (option == "6"){
          Console.WriteLine("Goodbye!");
          break;
        } else {
          Console.WriteLine("Not a valid option\n (unlike you.  You are Valid.)");
        }
      }
    }

    public static void seeMenu() {
      Console.WriteLine("Welcome to the Employee Management System!\n" +
          "1. See all employees\n" +
          "2. Add an employeee\n" +
          "3. Find an employee\n" + 
          "4. Update an employee\n" +
          "5. Remove an employee\n" +
          "6. exit");
    }
    public static void seeEmployees() {
      foreach (Employee employee in employees) {
        Console.WriteLine(employee.ToString());
      }
    }
    private static void addEmployee() {
      Console.WriteLine("Enter the Employee's name");
      string name = Console.ReadLine();
      int salary = 0;
      Console.WriteLine("Enter the Employee's salary");
      while (true) {
        string entry = Console.ReadLine();
        if (Int32.TryParse(entry, out salary)) {
          break;
        } else {
          Console.WriteLine("Enter an integer");
        }
      }
      Employee employee = new Employee(counter++, name, salary);
      Console.WriteLine(employee.ToString());
      employees.Add(employee);
    }

    private static void getEmployee() {
      int empId = 0;
      Console.WriteLine("There are " + employees.Count + " employees. Which employee would you like to find?");
      while (true) {
        string entry = Console.ReadLine();
        if (Int32.TryParse(entry, out empId)) {
          break;
        } else {
          Console.WriteLine("Enter an integer");
        }
      }
      Employee selected = null;
      foreach (Employee employee in employees) {
        if (employee.EmpId == empId) {
           selected = employee;
           Console.WriteLine(employee.Name);
           break;
        }
      }
      if (selected == null) {
        Console.WriteLine("Employee not found");
      } else {
        Console.WriteLine(selected.ToString());
      }
    }

    private static void updateEmployee() {
      int empId = 0;
      Console.WriteLine("There are " + employees.Count + " employees. Which employee would you like to update?");
      while (true) {
        string entry = Console.ReadLine();
        if (Int32.TryParse(entry, out empId)) {
          break;
        } else {
          Console.WriteLine("Enter an integer");
        }
      }
      Employee selected = null;
      foreach (Employee employee in employees) {
        if (employee.EmpId == empId) {
           selected = employee;
           Console.WriteLine(employee.Name);
           break;
        }
      }
      if (selected == null) {
        Console.WriteLine("Employee not found");
      } else {
        employees.Remove(selected);
      }

      Console.WriteLine("Enter the Employee's name");
      string name = Console.ReadLine();
      int salary = 0;
      Console.WriteLine("Enter the Employee's salary");
      while (true) {
        string entry = Console.ReadLine();
        if (Int32.TryParse(entry, out salary)) {
          break;
        } else {
          Console.WriteLine("Enter an integer");
        }
      }
      Employee employee = new Employee(empId, name, salary);
      Console.WriteLine(employee.ToString());
      employees.Add(employee);
    }

    private static void removeEmployee() {
      int empId = 0;
      Console.WriteLine("There are " + employees.Count + " employees. Which employee would you like to remove?");
      while (true) {
        string entry = Console.ReadLine();
        if (Int32.TryParse(entry, out empId)) {
          break;
        } else {
          Console.WriteLine("Enter an integer");
        }
      }
      Employee selected = null;
      foreach (Employee employee in employees) {
        if (employee.EmpId == empId) {
           selected = employee;
           Console.WriteLine(employee.Name);
           break;
        }
      }
      if (selected == null) {
        Console.WriteLine("Employee not found");
      } else {
        employees.Remove(selected);
      }
    }

    }
  

  class Employee {

    private int empId;

    public int EmpId {
      get { return empId; }
    }

    private string name;

    public string Name  
    {
      get { return name; }   
      set { name = value; }  
    }

    private int salary;

    public int Salary  
    {
      get { return salary; }   
      set { salary = value; }  
    }

    public Employee() { }
    public Employee(int empId, string name, int salary) {
      this.empId = empId; 
      this.name = name;
      this.salary = salary;
    }

    public override string ToString() {
      return "Employee [ id: " + empId + ", Name: " + name + ", Salary: " + salary + " ]";
    }
  }
}