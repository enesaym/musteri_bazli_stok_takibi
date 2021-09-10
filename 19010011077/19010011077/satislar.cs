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
    public partial class satislar : Form
    {
        public satislar()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        DataTable tablo = new DataTable();
        private void listele() //veritabanındaki verilerin datagridviewe aktarılmasını saglayan fonksıyon
        {
            try
            {
                tablo.Clear();
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select*from satislar where tarih between tr1 and tr2", baglanti);
                listele.SelectCommand.Parameters.AddWithValue("tr1", dateTimePicker1.Value.ToShortDateString());
                listele.SelectCommand.Parameters.AddWithValue("tr2", dateTimePicker2.Value.ToShortDateString());
                listele.Fill(tablo);
                dataGridView1.DataSource =tablo;
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();

            }
        }
        private void satislar_Load(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
