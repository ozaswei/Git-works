using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToSqlProject
{
    public partial class Form6 : Form
    {
        CompanyDBDataContext dc;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            dc = new CompanyDBDataContext();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            int? Eno = null; //when we say '?' then here if the Eno is nullable then also we can assign
            dc.Employee_Insert(textBox2.Text,textBox3.Text,decimal.Parse(textBox4.Text),textBox5.Text,ref Eno);
            textBox1.Text = Eno.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            foreach(Control ctrl in this.Controls)
            {
                if(ctrl is TextBox)
                {
                    TextBox tab = ctrl as TextBox;
                    tab.Clear();
                }
            }
            textBox2.Focus();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
