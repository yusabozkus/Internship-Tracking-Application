using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace StajTakipProjesi.Pages
{
    public partial class StudentInfo : Form
    {
        public StudentInfo()
        {
            InitializeComponent();
        }

        SqlConnection sql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Okul.mdf;Integrated Security=True");
        private void StudentInfo_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'okulDataSet.Student' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.studentTableAdapter.Fill(this.okulDataSet.Student);
            // Form yüklendiğinde verileri yükle
            LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql.Open();

                SqlCommand command = new SqlCommand(
                    "INSERT INTO Student (student_no, student_name, student_surname, student_class, student_section, student_location, teacher_no, company_no, company_name) " +
                    "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9)", sql);

                command.Parameters.AddWithValue("@p1", textBox1.Text);
                command.Parameters.AddWithValue("@p2", textBox2.Text);
                command.Parameters.AddWithValue("@p3", textBox3.Text);
                command.Parameters.AddWithValue("@p4", textBox4.Text);
                command.Parameters.AddWithValue("@p5", textBox5.Text);
                command.Parameters.AddWithValue("@p6", textBox6.Text);
                command.Parameters.AddWithValue("@p7", textBox7.Text);
                command.Parameters.AddWithValue("@p8", textBox8.Text);
                command.Parameters.AddWithValue("@p9", textBox9.Text);

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

        private void LoadData()
        {
            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM Student", sql);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yükleme sırasında hata: " + ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TeacherInfo studentInfo = new TeacherInfo();
            this.Hide();
            studentInfo.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompanyInfo companyInfo = new CompanyInfo();
            this.Hide();
            companyInfo.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedIndex = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[selectedIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[selectedIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[selectedIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[selectedIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[selectedIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[selectedIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[selectedIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[selectedIndex].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[selectedIndex].Cells[8].Value.ToString();
            textBox9.Text = dataGridView1.Rows[selectedIndex].Cells[9].Value.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("Delete From Student Where student_id=@p1", sql);
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            sql.Close();
            LoadData();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("UPDATE Student SET " +
                "student_no = @p1, " +
                "student_name = @p2, " +
                "student_surname = @p3, " +
                "student_class = @p4, " +
                "student_section = @p5, " +
                "student_location = @p6, " +
                "teacher_no = @p7, " +
                "company_no = @p8, " +
                "company_name = @p9 " +
                "WHERE student_id = @p10", sql);

            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            command.Parameters.AddWithValue("@p3", textBox3.Text);
            command.Parameters.AddWithValue("@p4", textBox4.Text);
            command.Parameters.AddWithValue("@p5", textBox5.Text);
            command.Parameters.AddWithValue("@p6", textBox6.Text);
            command.Parameters.AddWithValue("@p7", textBox7.Text);
            command.Parameters.AddWithValue("@p8", textBox8.Text);
            command.Parameters.AddWithValue("@p9", textBox9.Text);
            command.Parameters.AddWithValue("@p10", txtID.Text);

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
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            txtID.Text = "";
        }
    }
}
