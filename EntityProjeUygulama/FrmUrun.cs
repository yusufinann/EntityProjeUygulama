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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db = new DbEntityUrunEntities();
        public void IstedigimTabloyuGetir()
        {
            dataGridView1.DataSource = (from t in db.TBLURUN
                                        select new
                                        {
                                            t.URUNID,
                                            t.URUNAD,
                                            t.MARKA,
                                            t.STOK,
                                            t.FIYAT,
                                            t.TBLKATEGORI.AD,
                                            t.DURUM
                                        }).ToList();

        }
        private void FrmUrun_Load(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = db.TBLURUN.ToList();

            dataGridView1.DataSource = (from t in db.TBLURUN    //İstediğim Tablonun istediğim sütunlarını getireyim veya ilişkili tablo sütunlarını getireyim.
                                        select new
                                        {
                                            t.URUNID,
                                            t.URUNAD,
                                            t.MARKA,
                                            t.STOK,
                                            t.FIYAT,
                                            t.TBLKATEGORI.AD,
                                            t.DURUM
                                        }).ToList();

            //Combobox a TBLKATEGORI tablomun Kategori adlarını gösterdiği AD sütununu çekelim.
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ID,
                                   x.AD
                               }
                              ).ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "AD";
            comboBox1.DataSource = kategoriler;

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = db.TBLURUN.ToList();
            IstedigimTabloyuGetir();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.URUNAD = TxtUrunAd.Text;
            t.MARKA = TxtMarka.Text;
            t.STOK = short.Parse(TxtStok.Text);
            t.FIYAT = decimal.Parse(TxtFiyat.Text);
            t.DURUM = true;
            t.KATEGORI = int.Parse(comboBox1.SelectedValue.ToString());
            db.TBLURUN.Add(t);     // t den gelen değerleri TBLURUN tabloma ekle
            db.SaveChanges();     //Değişiklikleri kaydet,İlgili sorguyu çalıştır,SQL e kaydet anlamları taşır.
            MessageBox.Show("ÜRÜN Eklendi");
            IstedigimTabloyuGetir();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtUrunId.Clear();
            TxtUrunAd.Clear();
            TxtMarka.Clear();
            TxtStok.Clear();
            TxtFiyat.Clear();
            TxtDurum.Clear();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunId.Text);
            var Urunler = db.TBLURUN.Find(x);
            Urunler.URUNAD = TxtUrunAd.Text;
            Urunler.MARKA = TxtMarka.Text;
            Urunler.STOK = short.Parse(TxtStok.Text);
            Urunler.FIYAT = decimal.Parse(TxtFiyat.Text);
            //Urunler.DURUM = bool.Parse(TxtDurum.Text);
            Urunler.KATEGORI = int.Parse(comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = Urunler;
            db.SaveChanges();
            MessageBox.Show("Güncelleme İşlemi YAPILDI");
            IstedigimTabloyuGetir();



        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtUrunId.Text);
            var Urunler = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(Urunler);
            db.SaveChanges();
            MessageBox.Show("Silme İşlemi YAPILDI");
            IstedigimTabloyuGetir();

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtUrunId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtUrunAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtMarka.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtDurum.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }
    }
}
