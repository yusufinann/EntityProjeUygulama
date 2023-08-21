using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityProjeUygulama;
namespace EntityProjeUygulama
{
    public partial class FrmKategoriler : Form
    {
        //***162.DERS Entity Framework ToList Metodu ***
        public FrmKategoriler()
        {
            InitializeComponent();
        }

        DbEntityUrunEntities db=new DbEntityUrunEntities();  //Bu satır, DbEntityUrunEntities adlı bir Entity Framework veritabanı bağlamını (context) temsil eden bir nesne oluşturur. Bu nesne, veritabanı işlemlerini gerçekleştirmek için kullanılır
        private void BtnListele_Click(object sender, EventArgs e)
        {
            //***162.DERS Entity Framework ToList Metodu ***
            var kategoriler = db.TBLKATEGORI.ToList(); //Listeleme işlemi (SELECT)
            dataGridView1.DataSource=kategoriler;   
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
          // *** KATEGORİ EKLEME İŞLEMİ YAPALIM (163.DERS)- Entity Framework Add Metodu ***
            TBLKATEGORI t = new TBLKATEGORI();
            t.AD = TxtKategoriAd.Text;
            db.TBLKATEGORI.Add(t);  //t den gelen değerleri ekle dedik.
            db.SaveChanges();     //Değişiklikleri kaydet,İlgili sorguyu çalıştır,SQL e kaydet anlamları taşır.
            MessageBox.Show("Kategori Eklendi");
            dataGridView1.DataSource = db.TBLKATEGORI.ToList();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBLKATEGORI.ToList(); //Kategorileri datagridview e çekme(Listeleme)işlemi***
        }

     

        private void BtnSil_Click(object sender, EventArgs e)
        {   
            //*** 164. DERS Entity Framework Remove Metodu *** 
            int x=Convert.ToInt32(TxtKategoriId.Text); //ID değerini x değişkenine atadım.
            var ktgr=db.TBLKATEGORI.Find(x);  //x' ten gelen değeri hafızaya al,tut.Find metodu aracılığıyla bu değeri Tablomda buldum.
            db.TBLKATEGORI.Remove(ktgr);
            db.SaveChanges();
            MessageBox.Show("Kategori silindi");
            dataGridView1.DataSource = db.TBLKATEGORI.ToList();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtKategoriId.Text); //ID değerini x değişkenine atadım.
            var ktgr = db.TBLKATEGORI.Find(x);
            ktgr.AD= TxtKategoriAd.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
            dataGridView1.DataSource = db.TBLKATEGORI.ToList();
        }
    }
}
