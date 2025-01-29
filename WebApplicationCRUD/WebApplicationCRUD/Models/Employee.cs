using Microsoft.Data.SqlClient;
using System.Data;

namespace WebApplicationCRUD.Models
{
    public class Employee
    {
        public int EmpNo{set; get;}
        public string Name { set; get; }

        public decimal Basic { set; get; }

        public int DeptNo { set; get; }

        public static void UpdateEmployee(int id,Employee emp)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update employees set Basic=@Basic,Name=@Name,DeptNo=@DeptNo where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", id);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();

                //Console.WriteLine("Data updated successfully");

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //Console.WriteLine(message);
            }
            finally
            {
                cn.Close();
            }

        }

        public static void DeleteEmployeeById(int v)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from employees where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", v);


                cmd.ExecuteNonQuery();

                Console.WriteLine("Data Deleted successfully");

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

        public static void InsertWithParameterWithSP(Employee e1)
        {
            //Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "dbo.InsertEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", e1.EmpNo);
                cmd.Parameters.AddWithValue("@Name", e1.Name);
                cmd.Parameters.AddWithValue("@Basic", e1.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", e1.DeptNo);
                cmd.ExecuteNonQuery();
                //Console.WriteLine(" Insert emp SP Ok");
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }


        }

        public static List<Employee> GetAllEmployees()
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";
                var employees = new List<Employee>();

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Employee emp = new Employee();
                    emp.EmpNo = Convert.ToInt32(dr["EmpNo"]);
                    emp.Name = (string)dr["Name"];
                    emp.Basic = (decimal)(dr["Basic"]);
                    emp.DeptNo = (int)dr["DeptNo"];

                    employees.Add(emp);
                }

                return employees;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }

            return null;


        }

        public static Employee GetEmployeeById(int empNo) {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ActsJan25;Integrated Security=True";

            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo =@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", empNo);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Employee employee = new Employee { EmpNo = (int)dr[0], Name = (string)dr[1], Basic = (decimal)dr[2], DeptNo = (int)dr[3] };
                    return employee;
                }
                return null;


                //Employee e1 = new Employee { EmpNo = 102,Name="Rushi",Basic=15000,DeptNo=2 };





            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }

        }


    }
}
