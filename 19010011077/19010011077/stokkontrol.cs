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
    public partial class stokkontrol : Form
    {
        public stokkontrol()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.JET.Oledb.4.0;Data Source=" + Application.StartupPath + "//takip.mdb");
        private void stokkontrol_Load(object sender, EventArgs e)
        {
            listele();
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)  //2 adettan az kalan ürünleri kırmızı olarak datagridview nesnesinde gösterir
            {
                if (int.Parse(dataGridView1.Rows[i].Cells["adet"].Value.ToString())>= 2)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele2 = new OleDbDataAdapter("select*from ürünler where barkodno like'" + textBox1.Text + "%'", baglanti);
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
    }
}
