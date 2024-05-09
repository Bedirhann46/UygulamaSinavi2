using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UygulamaSinavi2
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=tsomtal.com;Initial Catalog=UyeDb565;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                string sqlCum = "INSERT INTO uyelers565 (KAdi,AdiSoyadi,EPosta,Sifre) VALUES('" + textBoxKullaniciAdi.Text + "','" + textBoxAdiSoyadi.Text + "','" + textBoxEPosta.Text + "','" + textBoxSifre.Text + "');";
                SqlCommand cmd = new SqlCommand(sqlCum,baglanti);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Veriler başarı ile kaydedildi.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası\n"+ex. Message);
            }
            finally 
            {
                if (baglanti != null) baglanti.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'uyeDb565DataSet.Uyelers565' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uyelers565TableAdapter.Fill(this.uyeDb565DataSet.Uyelers565);

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible=true;
        }
    }
}
