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
    public partial class noticese : Form
    {
        public noticese()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void noticese_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=WIN-I4CR061GMDC;Initial Catalog=tea-stu;Integrated Security=True");
            conn.Open();
            string notice;
            notice = richTextBox1.Text.Trim();
            string usname;
            usname = login.curuser;
            string a;
            a = "select notice.tid from notice,teacher where notice.tid = teacher.tid and tname =  '" + usname + "'";
            SqlCommand b = new SqlCommand("", conn);
            b.CommandText = a;
            if (null != b.ExecuteScalar())
            {            
                string sel;
                DataTable dt = new DataTable();
                SqlDataAdapter sqldap = new SqlDataAdapter(a, conn);
                sqldap.Fill(dt);
                sel = dt.Rows[0][0].ToString();
                string sql1 = "update notice set comment = '" + notice + "' where tid = '"+sel+"'";
                SqlCommand cmd = new SqlCommand("", conn);
                //cmd.CommandText = sql1;
                int num = cmd.ExecuteNonQuery();
                if (num > 0)
                {
                    var f = new success();
                    f.Show();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
            }
            if (null == b.ExecuteScalar())
            {
                string sql1 = "insert into notice select tid,comment = '" + notice + "' from teacher where tname = '"+usname+"'";
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = sql1;
                int num = cmd.ExecuteNonQuery();
                if (num > 0)
                {
                    var f = new success();
                    f.Show();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
            }
        }
    }
}
