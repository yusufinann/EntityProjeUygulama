using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityProjeUygulama
{
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            LblToplamKtgrSayisi.Text = db.TBLURUN.Count().ToString();
            LblToplmUrun.Text = db.TBLURUN.Count().ToString();
            LblAktfMusteriSysı.Text = db.TBLMUSTERI.Count(x => x.DURUM == true).ToString();  // " => " ifadesi lamda anlamına gelir."x öyle ki... "diyerek şart koşar.(175.DERS)
            LblPaisMusteriSysı.Text = db.TBLMUSTERI.Count(x => x.DURUM == false).ToString();

            LblStok.Text = db.TBLURUN.Sum(y => y.STOK).ToString(); //TOPLAM STOK SAYISI
            LblKasaToplm.Text = db.TBLSATIS.Sum(z => z.FIYAT).ToString() + " TL ";     //KASA TOPLAM
            LblEnYuksekFıyt.Text = (from x in db.TBLURUN orderby x.FIYAT descending select x.URUNAD).FirstOrDefault(); //En yüksek fiyatlı ürünü getirme.
            LblEnDusukFıyt.Text = (from x in db.TBLURUN orderby x.FIYAT ascending select x.URUNAD).FirstOrDefault(); //En düşük fiyatlı ürünü getirme.
            LblByzEsyaSyısı.Text=db.TBLURUN.Count(x=>x.KATEGORI==1).ToString();  //Beyaz eşya nın kategorisi 1.Beyaz eşya kategorisindeki ürün sayıları gelcek
            LblBuzdolabıSysı.Text = db.TBLURUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();//BUZDOLABI sayısını getidik.
            LblSehirSysı.Text = (from x in db.TBLMUSTERI select x.SEHIR).Distinct().Count().ToString();//Şehir Sayısını bulma sorgusu.

            // LblEnFazlaUrunluMarka.Text = db.MARKAGETIR().FirstOrDefault();

            //var markalar = db.MARKAGETIR().ToList().ToString();
           // LblEnFazlaUrunluMarka.Text = markalar.FirstOrDefault();

        }
    }
}
