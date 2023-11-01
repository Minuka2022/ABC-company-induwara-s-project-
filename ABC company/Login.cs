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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OI2O0B7\\SQLEXPRESS;Initial Catalog=AbcCompanyDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login = "SELECT * FROM Users WHERE username= '" + textUsername.Text + "' and password = '" + textPassword.Text + "' ";
            cmd =  new SqlCommand(login , conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                new Main().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password Try again" , "Login failed" , MessageBoxButtons.OK , MessageBoxIcon.Error);
                textUsername.Text = "";
                textPassword.Text = "";
                textUsername.Focus();
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
 
            textPassword.Text = "";
            textUsername.Text = "";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new Reigster().Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
