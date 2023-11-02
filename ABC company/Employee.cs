using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Windows.Forms;

namespace ABC_company
{
    internal class Employee
    {
      
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OI2O0B7\\SQLEXPRESS;Initial Catalog=AbcCompanyDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();


        public void AddEmployee(string Firstname, string Lastname, string DOB, string Gender, string Address, string Email, int M_phone, int H_phone, string Department_name, string Designation, string Employee_type)
        {
            try
           {
                conn.Open();

                string Sql = "INSERT INTO Employee (Firstname ,  Lastname , DOB ,Gender ,Address , Email , M_phone , H_phone ,  Department_name , Designation , Employee_type )" +
                              "VALUES (@Firstname , @Lastname , @DOB , @Gender , @Address , @Email , @M_phone , @H_phone , @Department_name , @Designation,@Employee_type)";

                using(SqlCommand cmd = new SqlCommand(Sql,conn))
                {
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@M_phone", M_phone);
                    cmd.Parameters.AddWithValue("@H_phone", H_phone);
                    cmd.Parameters.AddWithValue("@Department_name", Department_name);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@Employee_type", Employee_type);


                    cmd.ExecuteNonQuery();



                }
                conn.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurd" + ex);
            }
        }

        public void UpdateEmployee(int Emp_NO, string Firstname, string Lastname, string DOB, string Gender, string Address, string Email, int M_phone, int H_phone, string Department_name, string Designation, string Employee_type)
        {
            try
            {
                conn.Open();
                string sql = "UPDATE Employee SET " +   // Ensure there's a space after SET
                             "Firstname = @Firstname, " +
                             "Lastname = @Lastname, " +
                             "DOB = @DOB, " +
                             "Gender = @Gender, " +
                             "Address = @Address, " +
                             "Email = @Email, " +
                             "M_phone = @M_phone, " +
                             "H_phone = @H_phone, " +
                             "Department_name = @Department_name, " +   // Corrected parameter name
                             "Designation = @Designation, " +
                             "Employee_type = @Employee_type " +   // Removed comma here
                             "WHERE Emp_NO = @Emp_NO";   // Removed comma here

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Firstname", Firstname);
                    cmd.Parameters.AddWithValue("@Lastname", Lastname);
                    cmd.Parameters.AddWithValue("@DOB", DOB);
                    cmd.Parameters.AddWithValue("@Gender", Gender);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@M_phone", M_phone);
                    cmd.Parameters.AddWithValue("@H_phone", H_phone);
                    cmd.Parameters.AddWithValue("@Department_name", Department_name);
                    cmd.Parameters.AddWithValue("@Designation", Designation);
                    cmd.Parameters.AddWithValue("@Employee_type", Employee_type);
                    cmd.Parameters.AddWithValue("@Emp_NO", Emp_NO);

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows == 0)
                    {
                        Console.WriteLine("No rows updated.");
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteEmployee (int Emp_NO)
        {
            try
            {
                conn.Open();
                string sql = "DELETE FROM Employee WHERE Emp_NO = @Emp_NO";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Emp_NO", Emp_NO);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
                MessageBox.Show("Employee deleted successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }





}
