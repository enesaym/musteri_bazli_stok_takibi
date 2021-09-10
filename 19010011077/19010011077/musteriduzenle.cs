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

namespace _19010011077
{
    public partial class musteriduzenle : Form
    {
        public musteriduzenle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void musteriduzenle_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void listele() //veritabanındaki verilerin datagridviewe aktarılmasını saglayan fonksıyon
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select*from müşteriler", baglanti);
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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            string tc = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            string tel = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            string adres = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            string eposta = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            string borc=dataGridView1.Rows[secim].Cells[6].Value.ToString();

            textBox1.Text = tc;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = tel;
            textBox5.Text = eposta;
            textBox6.Text = adres;
            textBox7.Text = borc;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand mstd = new OleDbCommand("update müşteriler set ad='"+textBox2.Text+"',soyad='"+textBox3.Text+"',tel='"+textBox4.Text+"',adres='"+textBox6.Text+"',email='"+textBox5.Text+"',borc='"+textBox7.Text+"'where tc='"+textBox1.Text+"'",baglanti);
                mstd.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("Müşteri bilgileri güncellendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!");
                baglanti.Close();
                
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

