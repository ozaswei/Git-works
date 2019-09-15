using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToSqlProject
{
    public partial class Form2 : Form
    {
        CompanyDBDataContext dc;    //declaring it. It is a proper method and so that u can access it throughout the class
        List<Employee> emp; // declaring the list of Employee
        int rno = 0; // declaring a variable
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dc = new CompanyDBDataContext();//this is used to establish connection with the database
            emp = dc.Employees.ToList();//once u call the property ToList() then the data of the data will be transfered to the list
            ShowData();

        }
        private void ShowData()
        {
            textBox1.Text = emp[rno].Eno.ToString(); // ToString, because i wamt to assign the value to the textbox
            textBox2.Text = emp[rno].Ename.ToString();//textBox1.Text= is the code that represents the First Text box we created
            textBox6.Text = emp[rno].Job.ToString();//weirdly this was TextBox6 -_- . Check it by rightclicking the textbox and click properties
            textBox4.Text = emp[rno].Salary.ToString();
            textBox5.Text = emp[rno].Dname.ToString();
        }                                           

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (rno > 0)
            { 
                rno -= 1;
                ShowData();
            }
            else
            {
                MessageBox.Show("This is the First Record of the Table"); // This is the code for Message Box
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(rno<emp.Count-1)//because the Index is always 1 less than the count
            { 
            rno += 1;
            ShowData();
            }
            else
            {
                MessageBox.Show("This is the Last Record of the Table"); // This is the code for Message Box
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
