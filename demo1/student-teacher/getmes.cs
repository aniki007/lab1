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
    public partial class getmes : Form
    {
        public getmes()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void getmes_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=WIN-I4CR061GMDC;Initial Catalog=tea-stu;user id = sa;password = sa");
            conn.Open();
            string usname = login.curuser;
            string sql1 = "select fromna from comment where tona = '" + usname + "'";
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = sql1;
            string sel;
            DataTable dt = new DataTable();
            SqlDataAdapter sqldap = new SqlDataAdapter(sql1, conn);
            sqldap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sel = dt.Rows[i][0].ToString();
                comboBox1.Items.Add(sel);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=WIN-I4CR061GMDC;Initial Catalog=tea-stu;user id = sa;password = sa");
            conn.Open();
            string na;
            na = comboBox1.Text;
            string sql2 = "select comment from comment where fromna ='" + na + "'";
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = sql2;
            DataTable dt = new DataTable();
            SqlDataAdapter sqldap = new SqlDataAdapter(sql2, conn);
            sqldap.Fill(dt);
            string not;
            not = dt.Rows[0][0].ToString();
            richTextBox1.Text = not;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new sendmes();
            f.Show();
        }
    }
}
