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
    public partial class ödeme : Form
    {
        public ödeme()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void listele() //veritabanındaki verilerin datagridviewe aktarılmasını saglayan fonksıyon
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select taksit,tcno,barkodno,ürünadi,fiyat,tarih from mstdetay", baglanti);
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

        private void ödeme_Load(object sender, EventArgs e)
        {
            listele();
        }
        float x,w,toplam;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand mstd = new OleDbCommand("delete from mstdetay where id='" + textBox2.Text + "'and tcno='"+textBox1.Text+"'", baglanti);
                mstd.ExecuteNonQuery();
                baglanti.Close();
                x = Convert.ToInt32(textBox3.Text);
                baglanti.Open();
                OleDbCommand yapma = new OleDbCommand("select * from müşteriler where tc='" + textBox1.Text + "'", baglanti);
                OleDbDataReader okuma = yapma.ExecuteReader();
                while (okuma.Read())
                {
                    w = Convert.ToInt32(okuma["borc"]);
                    toplam = w-x;
                }
                baglanti.Close();
                baglanti.Open();
                OleDbCommand ödeme = new OleDbCommand("update müşteriler set borc='" + toplam + "'where tc='" + textBox1.Text + "'", baglanti);
                ödeme.ExecuteNonQuery();
                baglanti.Close();
                listele();
                MessageBox.Show("ÖDEME ALINDI.");
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATA!");
                baglanti.Close();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele2 = new OleDbDataAdapter("select taksit,tcno,barkodno,ürünadi,fiyat,tarih from mstdetay where tcno like'" + textBox1.Text + "%'", baglanti);
                DataSet hafıza2 = new DataSet();
                listele2.Fill(hafıza2);
                dataGridView1.DataSource = hafıza2.Tables[0];
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
            string taksit = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            string tcno = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            string tutar= dataGridView1.Rows[secim].Cells[4].Value.ToString();
            textBox2.Text = taksit;
            textBox1.Text = tcno;
            textBox3.Text = tutar;

        }
    }
}
