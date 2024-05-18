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
    public partial class TeacherInfo : Form
    {
        public TeacherInfo()
        {
            InitializeComponent();
        }

        SqlConnection sql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Okul.mdf;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentInfo studentInfo = new StudentInfo();
            this.Hide();
            studentInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompanyInfo companyInfo = new CompanyInfo();
            this.Hide();
            companyInfo.Show();
        }

        private void TeacherInfo_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'okulDataSet.Teacher' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.teacherTableAdapter.Fill(this.okulDataSet.Teacher);
        }

        private void LoadData()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Teacher", sql);
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
                    "INSERT INTO Teacher (teacher_name, teacher_surname, teacher_section, teacher_no)" +
                    "VALUES (@p1, @p2, @p3, @p4)", sql);

                command.Parameters.AddWithValue("@p1", textBox1.Text);
                command.Parameters.AddWithValue("@p2", textBox2.Text);
                command.Parameters.AddWithValue("@p3", textBox3.Text);
                command.Parameters.AddWithValue("@p4", textBox4.Text);

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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("Delete From Teacher Where teacher_id=@p1", sql);
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            sql.Close();
            LoadData();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("UPDATE Teacher SET " +
                "teacher_name = @p2, " +
                "teacher_surname = @p3, " +
                "teacher_section = @p4, " +
                "teacher_no = @p1 " + // Fazladan virgül kaldırıldı
                "WHERE teacher_id = @p5", sql);

            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            command.Parameters.AddWithValue("@p3", textBox3.Text);
            command.Parameters.AddWithValue("@p4", textBox4.Text);
            command.Parameters.AddWithValue("@p5", txtID.Text);

            command.ExecuteNonQuery();
            sql.Close();
            LoadData();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            txtID.Text = "";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString();
            textBox1.Text = dataGridView1.Rows[selectedIndex].Cells[4].Value.ToString();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
