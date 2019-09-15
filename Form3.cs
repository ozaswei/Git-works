using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace LinqToSqlProject
{
    public partial class Form3 : Form
    {
        CompanyDBDataContext dc;//Global declaration
        public Form3()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            dc = new CompanyDBDataContext();
            Table<Employee> tab = dc.Employees;
            dgView.DataSource = tab;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog(); //it shows the form as a model dialogue of form 4 as f is form4 instance
            LoadData();
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            //YOU NEED TO SELECT THE RECORD FIRST BEFORE UPDATING             
            if (dgView.SelectedRows.Count > 0)
            {
                f.button2.Enabled = false;
                f.button1.Text = "Update";
                f.textBox1.ReadOnly = true; // use this if u want to make a certain textbox non-editable. Here Eno. isnt editable
                f.textBox1.Text = dgView.SelectedRows[0].Cells[0].Value.ToString(); // as the value will be object, so ToString is used to convert it into string value
                f.textBox2.Text = dgView.SelectedRows[0].Cells[1].Value.ToString();
                f.textBox3.Text = dgView.SelectedRows[0].Cells[2].Value.ToString();
                f.textBox4.Text = dgView.SelectedRows[0].Cells[3].Value.ToString();
                f.textBox5.Text = dgView.SelectedRows[0].Cells[4].Value.ToString();
                f.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Select the rows you want to update first then only click Delete","There was an Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void DgView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (dgView.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("Are you sure you want to delete this particular row", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    int Eno = Convert.ToInt32(dgView.SelectedRows[0].Cells[0].Value); // this converts the object to integer
                    Employee obj = dc.Employees.SingleOrDefault(E=>E.Eno==Eno); // here now the obj becomes the refernce of the existing record
                    dc.Employees.DeleteOnSubmit(obj); // this deletes the record on a pending delete state, that is it hasnt commited the data
                    dc.SubmitChanges(); // this will commit the data
                    MessageBox.Show("The record has been sucessfully deleted!!","Success!!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Select the rows you want to delete first then only click Update", "There was an Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
