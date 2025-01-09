namespace Day7_File_Handling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello, World!");

           // Directory.CreateDirectory(@"D:\ASP.NET\Ms.net git\Day7 File handling\Day7 File Handling\emp.txt");
            FileInfo file = new FileInfo("D:\\ASP.NET\\Ms.net git\\Day7 File handling\\Day7 File Handling\\emp.txt");
            StreamWriter writter = file.CreateText();
           
            
            Employee employee = new Employee(101,"Rajesh",50000.00);

            writter.WriteLine(employee.Id);
            writter.WriteLine(employee.Name);
            writter.WriteLine(employee.Salary);
            writter.Close();



        }
    }
    public class Employee {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee() { }
        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;

        }
    }

}
