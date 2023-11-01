using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ABC_company
{
    public partial class Reigster : Form
    {
        public Reigster()
        {
            InitializeComponent();

            
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OI2O0B7\\SQLEXPRESS;Initial Catalog=AbcCompanyDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Reigster_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(textUsername.Text == "" && textComPassword.Text == "" && textPassword.Text == "")
            {
                MessageBox.Show("Username and password fields are empty", "Registration Failed " , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textComPassword.Text == textComPassword.Text)
            {
                conn.Open();
                string register = "INSERT INTO Users VALUES ('" + textUsername.Text + "' , '" + textComPassword.Text + "')";
                cmd =  new SqlCommand(register,conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                textComPassword.Text = "";
                textPassword.Text = "";
                textUsername.Text = "";

                MessageBox.Show("Your account successfully created", "Registration success ", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Password does not match Please re-enter" , "Registration Failed" , MessageBoxButtons.OK , MessageBoxIcon.Error);

                textComPassword.Text = "";
                textPassword.Text = "";
                textPassword.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textPassword.PasswordChar = '\0';
                textComPassword.PasswordChar = '\0';
            }
            else
            {
                textPassword.PasswordChar = '*';
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {

            textComPassword.Text = "";
            textPassword.Text = "";
            textUsername.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}
