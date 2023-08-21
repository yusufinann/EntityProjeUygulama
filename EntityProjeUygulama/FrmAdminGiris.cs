using System;
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
    public partial class FrmAdminGiris : Form
    {
        public FrmAdminGiris()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db =new DbEntityUrunEntities();
        private void BtnGiris_Click(object sender, EventArgs e)
        {
            var sorgu =from x in db.TBLADMIN where x.KULLANICI==textBox1.Text && x.SIFRE==textBox2.Text select x;
            if(sorgu.Any() )
            {
                FrmAnaForm fr = new FrmAnaForm();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı GİRİŞ","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
