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
    public partial class Form5 : Form
    {
        CompanyDBDataContext dc;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dc = new CompanyDBDataContext();
           ISingleResult<Employee_SelectResult> tab = dc.Employee_Select("Department Of IT"); // u will automaqtically get the results into the tab 
            dataGridView1.DataSource = tab;

        }
    }
}
