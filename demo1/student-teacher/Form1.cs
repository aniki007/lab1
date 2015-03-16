using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace student_teacher
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=tea-stu;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=tea-stu;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("",conn);
            string sql = "select sid from student where sname='" + textBox1.Text.Trim() + "' and password='" + textBox2.Text.Trim() + "'";
            cmd.CommandText = sql;
            if (null != cmd.ExecuteScalar())
            {
                var form = new Form2();
                form.Show();
            }

        }

    }
}
