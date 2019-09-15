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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        public void Form4_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CompanyDBDataContext d = new CompanyDBDataContext();
            if (textBox1.ReadOnly == false) // as we this method will be called while we press insert as well a update , so the difference between the insert and the update  is the textBox.ReadOnly as false or true. Hence we can use it as a condition to differentiate if its a insert or update.
            {
                Employee obj = new Employee(); // to access the Employee class we created the instance

             //Assigning the values to the property 

                obj.Eno = int.Parse(textBox1.Text); //here we have to explicitly convert the string value to int .int.Parse converts strings to int.
                obj.Ename = textBox2.Text;//it is string 
                obj.Job = textBox3.Text;
                obj.Salary = decimal.Parse(textBox4.Text); // because we used type money in database so we have to convert into decimal or int 
                obj.Dname = textBox5.Text;
                d.Employees.InsertOnSubmit(obj);//InsertOnSubmit(obj) inserts the record to the table but wont commit (appending k)
                d.SubmitChanges(); // this will commit the data changes
                MessageBox.Show("The Record has been inserted into the table");
            }
            else
            {
                //Creating a refernce to an existing record
                Employee obj = d.Employees.SingleOrDefault(E => E.Eno==int.Parse(textBox1.Text)); //here the Eno. becomes a refernce to the existing records
                obj.Ename = textBox2.Text;//now if user doesnt modifies it then the old value will be overridden to the old values but if the user modifies it with a new value then the new value overrides the old value.
                obj.Job = textBox3.Text;
                obj.Salary = decimal.Parse(textBox4.Text);  
                obj.Dname = textBox5.Text;
                d.SubmitChanges(); // this will commit the data changes
                MessageBox.Show("The Record has been Updated into the table","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls) // this will clear all the textbox data
            {                                       //using the class Control (its a type like as an int)
                if (ctrl is TextBox)                //ctrl is a variable
                {                                   //is represent a boolean true or false value
                    TextBox tb = ctrl as TextBox;   //calling TextBox class , tb is instance 
                    tb.Clear(); // clears the textbox
                }

            }
            textBox1.Focus(); // it will set the input control to the textbox1
        }
    }
}

//change all the Modifiers of Textbox and save and clear button to internal from private(default)
//Internal means we can access it within the project