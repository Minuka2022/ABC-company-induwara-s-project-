using ABC_company;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ABC_company
{
    public partial class Main : Form
    {
        int Emp_NO;
        public Main()
        {
            InitializeComponent();
            show();
        }

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-OI2O0B7\\SQLEXPRESS;Initial Catalog=AbcCompanyDB;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {



            // Add an Edit button column if it does not already exist.
            if (!dataGridView1.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
                editColumn.Name = "Edit";
                editColumn.HeaderText = "Edit";
                editColumn.Text = "Edit";
                editColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(editColumn);
            }

            // Add a Delete button column if it does not already exist.
            if (!dataGridView1.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
                deleteColumn.Name = "Delete";
                deleteColumn.HeaderText = "Delete";
                deleteColumn.Text = "Delete";
                deleteColumn.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(deleteColumn);
            }

            show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate the input fields for empty values before proceeding.
            if (string.IsNullOrWhiteSpace(text_fname.Text) ||
                string.IsNullOrWhiteSpace(textLastname.Text) ||
                string.IsNullOrWhiteSpace(richTextAddress.Text) ||
                string.IsNullOrWhiteSpace(textEmail.Text) ||
                string.IsNullOrWhiteSpace(textM_phone.Text) ||
                string.IsNullOrWhiteSpace(textHome_phone.Text) ||
                string.IsNullOrWhiteSpace(textDepartmnet.Text) ||
                string.IsNullOrWhiteSpace(textDesignation.Text) ||
                string.IsNullOrWhiteSpace(textEmploye_type.Text))
            {
                MessageBox.Show("Enter valid data for all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the event handler if validation fails.
            }

            // Continue with the process since validation passed.
            string DOB = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            // Ensure that phone numbers are valid integers before parsing.
            bool isValidMPhone = int.TryParse(textM_phone.Text, out int M_phone);
            bool isValidHPhone = int.TryParse(textHome_phone.Text, out int H_phone);
            if (!isValidMPhone || !isValidHPhone)
            {
                MessageBox.Show("Enter valid phone numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the event handler if phone number validation fails.
            }

            Employee emp1 = new Employee();
            emp1.AddEmployee(text_fname.Text, textLastname.Text, DOB, comboBox1.Text, richTextAddress.Text, textEmail.Text, M_phone, H_phone, textDepartmnet.Text, textDesignation.Text, textEmploye_type.Text);

            MessageBox.Show("Employee Added successfully", "Record Added", MessageBoxButtons.OK);

            // Clear the form fields
            EMPID.Text = "";
            text_fname.Text = "";
            textLastname.Text = "";
            dateTimePicker1.Value = DateTime.Now; // Resetting the DateTimePicker to current date.
            comboBox1.SelectedIndex = -1; // Reset the ComboBox selection.
            richTextAddress.Text = "";
            textEmail.Text = "";
            textM_phone.Text = "";
            textHome_phone.Text = "";
            textDepartmnet.Text = "";
            textDesignation.Text = "";
            textEmploye_type.Text = "";

            // Refresh the DataGridView to show the new data
            show();
        }

        void show()
        {
            conn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Employee", conn);
            DataTable dtb1 = new DataTable();
            sqlDa.Fill(dtb1);

            dataGridView1.DataSource = dtb1;
            conn.Close();

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {

                DataGridViewRow SelectedRow = dataGridView1.Rows[e.RowIndex];

                EMPID.Text = SelectedRow.Cells[2].Value?.ToString();
                text_fname.Text = SelectedRow.Cells[3].Value?.ToString();
                textLastname.Text = SelectedRow.Cells[4].Value?.ToString();

                if (SelectedRow.Cells[5].Value is DateTime dateValue)
                {
                    dateTimePicker1.Value = dateValue;
                }

                comboBox1.Text = SelectedRow.Cells[6].Value?.ToString();
                richTextAddress.Text = SelectedRow.Cells[7].Value?.ToString();
                textEmail.Text = SelectedRow.Cells[8].Value?.ToString();
                textM_phone.Text = SelectedRow.Cells[9].Value?.ToString();
                textHome_phone.Text = SelectedRow.Cells[10].Value?.ToString();
                textDepartmnet.Text = SelectedRow.Cells[11].Value?.ToString();
                textDesignation.Text = SelectedRow.Cells[12].Value?.ToString();
                textEmploye_type.Text = SelectedRow.Cells[13].Value?.ToString();

            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult = MessageBox.Show("Do you really want to delete this employee?", "Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int Emp_NO = int.Parse(EMPID.Text);
                    Employee emp3 = new Employee();
                    emp3.DeleteEmployee(Emp_NO);
                    show();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string DOB = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            int M_phone = int.Parse(textM_phone.Text);
            int H_phone = int.Parse(textHome_phone.Text);
            int EmpID = int.Parse(EMPID.Text);
            
            Employee emp2 = new Employee();

            emp2.UpdateEmployee(EmpID, text_fname.Text, textLastname.Text, DOB, comboBox1.Text, richTextAddress.Text, textEmail.Text, M_phone, H_phone, textDepartmnet.Text, textDesignation.Text, textEmploye_type.Text);

           //MessageBox.Show("Employee updated successfully", "Record Updated" , MessageBoxButtons.OK);

            text_fname.Text = "";
            textLastname.Text = "";
            richTextAddress.Text = "";
            textEmail.Text = "";
            textM_phone.Text = "";
            textHome_phone.Text = "";
            textDepartmnet.Text = "";
            textDesignation.Text = "";
            textEmploye_type.Text = "";

            show();


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            EMPID.Text = "";
            text_fname.Text = "";
            textLastname.Text = "";
            richTextAddress.Text = "";
            textEmail.Text = "";
            textM_phone.Text = "";
            textHome_phone.Text = "";
            textDepartmnet.Text = "";
            textDesignation.Text = "";
            textEmploye_type.Text = "";

        }
    }
}




