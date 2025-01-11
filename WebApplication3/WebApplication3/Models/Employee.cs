using Microsoft.Data.SqlClient;
using System.Data; 

namespace WebApplication3.Models
{
    public class Employee
    {
        public int EmpNO { get; set; }
        public string Name { get; set; }
        public double Basic { get; set; }
        public int DeptNo { get; set; }

        private static Employee GetAllEmployeeById(int empNo)
        {
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
                    Console.WriteLine(dr["EmpNo"]);
                    Console.WriteLine(dr["Name"]);
                    Console.WriteLine(dr["Basic"]);
                    Console.WriteLine(dr["DeptNo"]);
                }



                Employee emp = new Employee();

                return emp;

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
    }
}
