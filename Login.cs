using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;

        public Login()
        {

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select ADMINFLAG from Users where UserName=:username and Pass=:password and Email=:email";
            cmd.Parameters.Add("UserName", textBox1.Text);
            cmd.Parameters.Add("Password", textBox2.Text);
            cmd.Parameters.Add("Email", textBox3.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            int flag = 2;
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    flag = Convert.ToInt32(dr[0]);
                    MessageBox.Show("Logged in Successfully");
                }
                dr.Close();
                if (flag == 0)
                {
                    searchForm f = new searchForm();
                    f.Show();
                    this.Hide();
                }
                else if (flag == 1)
                {
                    AddFilm f = new AddFilm();
                    f.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Information is not correct");
            }
        }


    }
}
