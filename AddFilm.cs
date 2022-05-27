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
    public partial class AddFilm : Form
    {
        string ordb = "Data source=orcl;User Id=scott;Password=tiger;";
        OracleConnection conn;

        public AddFilm()
        {
            InitializeComponent();
        }

        private void AddFilm_Load(object sender, EventArgs e)
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

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into Films values (:category,:name,:isPaid)";
            cmd.Parameters.Add("category", textBox2.Text);
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("isPaid", textBox3.Text);

            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("New Film is added");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminReport f = new AdminReport();
            f.Show();
            this.Hide();
        }
    }
}
