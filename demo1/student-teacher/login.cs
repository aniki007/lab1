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
using System.Configuration;

namespace student_teacher
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        public static string curuser = "";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            conn.Open();
            SqlCommand cmd = new SqlCommand("",conn);
            string sql = "select sid from student where sname='" + textBox1.Text.Trim() + "' and password='" + textBox2.Text.Trim() + "'";
            cmd.CommandText = sql;
            
            if (null != cmd.ExecuteScalar())
            {
                var form = new stulo();
                form.Show();
                var form2 = new success();
                form2.Show();
                this.Visible = false;
                curuser = textBox1.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            if (null == cmd.ExecuteScalar())
            {
                var form = new fail();
                form.Show();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=192.168.1.101;Initial Catalog=tea-stu;User id = sa;password = sa");
            conn.Open();
            SqlCommand cmd = new SqlCommand("",conn);
            string sql = "select tid from teacher where tname='" + textBox1.Text.Trim() + "' and password='" + textBox2.Text.Trim() + "'";
            cmd.CommandText = sql;
            if (null != cmd.ExecuteScalar())
            {
                var form = new tealo();
                form.Show();
                var form2 = new success();
                form2.Show();
                this.Visible = false;
                curuser = textBox1.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            if (null == cmd.ExecuteScalar())
            {
                var form = new fail();
                form.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        }

    }
