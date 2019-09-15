using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.Linq; // we need to write this if we dont wanna write all of this at the bottom program codes
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToSqlProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CompanyDBDataContext dc = new CompanyDBDataContext();
            //dataGridView1.DataSource = dc.Employees; //remember this ,this will show all the data from the database table Employee
            Table<Employee> tab = dc.Employees;
            dataGridView1.DataSource = tab; // THE TABLE IS NOW BOUND TO GRIDVIEW
        }
    }
}
