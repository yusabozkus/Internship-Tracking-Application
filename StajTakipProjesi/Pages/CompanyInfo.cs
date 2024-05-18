using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StajTakipProjesi.Pages
{
    public partial class CompanyInfo : Form
    {
        public CompanyInfo()
        {
            InitializeComponent();
        }

        SqlConnection sql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Okul.mdf;Integrated Security=True");

        private void CompanyInfo_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'okulDataSet.Company' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.companyTableAdapter.Fill(this.okulDataSet.Company);

        }

        private void LoadData()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Company", sql);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme sırasında hata: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                sql.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO Company (company_name, company_boss, company_phone, company_mail, company_location) " +
                    "VALUES (@p1, @p2, @p3, @p4, @p5)", sql);

                command.Parameters.AddWithValue("@p1", txtName.Text);
                command.Parameters.AddWithValue("@p2", txtNoss.Text);
                command.Parameters.AddWithValue("@p3", txtPhone.Text);
                command.Parameters.AddWithValue("@p4", txtMail.Text);
                command.Parameters.AddWithValue("@p5", txtLocation.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Kayıt başarıyla eklendi.");
                    // Veri eklendikten sonra `DataGridView`'i güncelle
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Kayıt eklenemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                sql.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeacherInfo teacherInfo = new TeacherInfo();
            this.Hide();
            teacherInfo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentInfo studentInfo = new StudentInfo();
            this.Hide();
            studentInfo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
            txtNoss.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
            txtPhone.Text = dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString();
            txtMail.Text = dataGridView1.Rows[selectedIndex].Cells[4].Value.ToString();
            txtLocation.Text = dataGridView1.Rows[selectedIndex].Cells[5].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("Delete From Company Where company_id=@p1", sql);
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            sql.Close();
            LoadData();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("UPDATE Company SET " +
                "company_name = @p1, " +
                "company_boss = @p2, " +
                "company_phone = @p3, " +
                "company_mail = @p4, " +
                "company_location = @p5 " + // Fazladan virgül kaldırıldı
                "WHERE company_id = @p6", sql);

            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtNoss.Text);
            command.Parameters.AddWithValue("@p3", txtPhone.Text);
            command.Parameters.AddWithValue("@p4", txtMail.Text);
            command.Parameters.AddWithValue("@p5", txtLocation.Text);
            command.Parameters.AddWithValue("@p6", txtID.Text); // Doğru parametre adı kullanıldı

            command.ExecuteNonQuery();
            sql.Close();
            LoadData();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtLocation.Text = "";
            txtMail.Text = "";
            txtNoss.Text = "";
            txtPhone.Text = "";
            txtID.Text = "";
        }
    }
}
