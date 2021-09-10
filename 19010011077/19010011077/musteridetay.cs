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
    public partial class musteridetay : Form
    {
        public musteridetay()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void musteridetay_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select*from müşteriler where tc like'" + textBox1.Text + "%'", baglanti);
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
    }
}
