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
    public partial class SubscriptionForm : Form
    {
        OracleDataAdapter Adapter;
        DataSet ds;
        DataSet ds2;
        OracleDataAdapter Adapter2;
        OracleCommandBuilder Builder;

        public SubscriptionForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string constr = "User Id=scott;Password=tiger;Data Source=orcl";
            string cmdstr = @"Select UserId From Users where username =:username and pass=:password";

            Adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();

            Adapter.SelectCommand.Parameters.Add("username", textBox1.Text);
            Adapter.SelectCommand.Parameters.Add("password", textBox2.Text);
            Adapter.Fill(ds);
            string cmdstr2 = @"Select* From Subscriptions  where userid =:userid";

            Adapter2 = new OracleDataAdapter(cmdstr2, constr);
            Adapter2.SelectCommand.Parameters.Add("id", ds.Tables[0].Rows[0][0]);
            ds2 = new DataSet();
            Adapter2.Fill(ds2);

            dataGridView1.DataSource = ds2.Tables[0];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Builder = new OracleCommandBuilder(Adapter2);
            Adapter2.Fill(ds2);
            Adapter2.Update(ds2.Tables[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubscriptionReport f = new SubscriptionReport(); 
            f.Show();
            this.Hide();
        }
    }

}
