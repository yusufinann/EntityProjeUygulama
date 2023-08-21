﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmKategoriler fr = new FrmKategoriler();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUrun fr = new FrmUrun(); 
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmIstatistik frm = new FrmIstatistik();
            frm.Show();
        }
    }
}