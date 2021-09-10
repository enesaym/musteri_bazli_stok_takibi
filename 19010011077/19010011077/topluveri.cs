using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace _19010011077
{
    public partial class topluveri : Form
    {
        public topluveri()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void topluveri_Load(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Lütfen bir dosya seçiniz";
            openFileDialog1.FileName = "Dosya seç";
            openFileDialog1.Filter = "Text files(.txt)|*.txt";
            listele();
            button2.Enabled = false;
        }
        private void listele() //veritabanındaki verilerin datagridviewe aktarılmasını saglayan fonksıyon
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select*from ürünler", baglanti);
                DataSet hafıza = new DataSet();
                listele.Fill(hafıza);
                dataGridView1.DataSource = hafıza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader okuyucu = File.OpenText(textBox1.Text);
                string satir = okuyucu.ReadLine();
                string[] parca = satir.Split(',');
                baglanti.Open();
                OleDbCommand ekle = new OleDbCommand("insert into ürünler(barkodno,kategori,marka,model,adet,fiyat,tarih) values('" + parca[0] + "','" + parca[1] + "','" + parca[2] + "','" + parca[3] + "','" + parca[4] + "','" + parca[5] + "','" + parca[6] + "')", baglanti);
                ekle.ExecuteNonQuery();
                baglanti.Close();
                while (true)
                {
                    satir = okuyucu.ReadLine();
                    if (satir == null)
                    {
                        break;
                    }
                    string[] parcas = satir.Split(',');
                    baglanti.Open();
                    OleDbCommand ekle2 = new OleDbCommand("insert into ürünler(barkodno,kategori,marka,model,adet,fiyat,tarih) values('" + parcas[0] + "','" + parcas[1] + "','" + parcas[2] + "','" + parcas[3] + "','" + parcas[4] + "','" + parcas[5] + "','" + parcas[6] + "')", baglanti);
                    ekle2.ExecuteNonQuery();
                    baglanti.Close();

                }    
                okuyucu.Close();
                MessageBox.Show("VERİLER EKLENDİ.");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
            listele();




        }
    }
}
