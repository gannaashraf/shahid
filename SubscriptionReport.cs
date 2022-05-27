﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace WindowsFormsApp1
{
    public partial class SubscriptionReport : Form
    {

        CrystalReport1 CR;

        public SubscriptionReport()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            CR = new CrystalReport1();
            foreach(ParameterDiscreteValue v in CR.ParameterFields[0].DefaultValues)
            {
                comboBox1.Items.Add(v.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CR.SetParameterValue(0, comboBox1.Text);
            crystalReportViewer1.ReportSource = CR;
        }

    }
}
