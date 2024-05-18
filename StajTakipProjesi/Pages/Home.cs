using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StajTakipProjesi.Pages
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'okulDataSet.Teacher' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.teacherTableAdapter.Fill(this.okulDataSet.Teacher);
            // TODO: Bu kod satırı 'okulDataSet.Company' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.companyTableAdapter.Fill(this.okulDataSet.Company);
            // TODO: Bu kod satırı 'okulDataSet.Student' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.studentTableAdapter.Fill(this.okulDataSet.Student);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StudentInfo studentInfo = new StudentInfo();
            this.Hide();
            studentInfo.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
