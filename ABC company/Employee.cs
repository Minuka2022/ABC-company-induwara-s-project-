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

                string Sql = "INSERT INTO Employe (Firstname ,  Lastname , DOB ,Gender ,Address , Email , M_phone , H_phone ,  Department_name , Designation , Employee_type )" +
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


    }

 

  
}
