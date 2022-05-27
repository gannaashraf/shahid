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
    public partial class searchForm : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;
        public searchForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            listView1.Clear();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            if (radioButton1.Checked == true)
            {
                cmd.CommandText = "getFilms";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("categoryy", textBox1.Text);
                cmd.Parameters.Add("FilmData", OracleDbType.RefCursor, ParameterDirection.Output);

                OracleDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listView1.Items.Add(dr[0].ToString());
                    if (dr[1].ToString() == "1")
                    {
                        listView1.Items.Add("Paid");
                    }
                    else
                    {
                        listView1.Items.Add("Not Paid");
                    }
                }
                dr.Close();
            }
            else if (radioButton2.Checked == true)
            {
                cmd.CommandText = "getFilm";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("filmName", textBox1.Text);
                cmd.Parameters.Add("categoryy", OracleDbType.Varchar2, 2000, null, ParameterDirection.Output);
                cmd.Parameters.Add("paid", OracleDbType.Int32, ParameterDirection.Output);
                cmd.ExecuteNonQuery();
                listView1.Items.Add(cmd.Parameters["categoryy"].Value.ToString());
                if (cmd.Parameters["paid"].Value.ToString() == "1")
                {
                    listView1.Items.Add("Paid");
                }
                else
                {
                    listView1.Items.Add("Not Paid");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SubscriptionForm f = new SubscriptionForm();
            f.Show();
            this.Hide();
        }

    }
}
