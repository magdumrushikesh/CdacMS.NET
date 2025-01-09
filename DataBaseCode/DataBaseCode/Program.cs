using Microsoft.Data.SqlClient;
using System.Data;

namespace DataBaseCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Connect();
            Employee e1 = new Employee { EmpNo = 110, Name="Lokare", Basic=10000,DeptNo=2 };
            // Insert2(e1);
            InsertWithParameterWithSP(e1);

        }

        static void InsertWithParameterWithSP(Employee e1)
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Procedure";

                cmd.Parameters.AddWithValue("@EmpNo", e1.EmpNo);
                cmd.Parameters.AddWithValue("@Name", e1.Name);
                cmd.Parameters.AddWithValue("@Basic", e1.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", e1.DeptNo);
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Insert emp Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        static void InsertWithParameter(Employee e1)
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo", e1.EmpNo);
                cmd.Parameters.AddWithValue("@Name", e1.Name);
                cmd.Parameters.AddWithValue("@Basic", e1.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", e1.DeptNo);
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Insert emp Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        
          
        }

        static void Connect()
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                Console.WriteLine("Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    
        
        static void Insert()
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType=CommandType.Text;
                cmd.CommandText = "insert into Departments values(4,'Frontend')";
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Insert Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        static void Insert2(Employee e1)
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"insert into Employees values({e1.EmpNo},'{e1.Name}',{e1.Basic},{e1.DeptNo})";
                cmd.ExecuteNonQuery();
                Console.WriteLine(" Insert emp Ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }

        public double Basic { get; set; }

        public int DeptNo { get; set; }
    }
}
