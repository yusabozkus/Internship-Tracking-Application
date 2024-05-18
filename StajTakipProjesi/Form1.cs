using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using StajTakipProjesi.Pages;

namespace StajTakipProjesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sql = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Okul.mdf;Integrated Security=True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand command = new SqlCommand("Select * from Teacher where teacher_name = @p1 and teacher_password = @p2", sql);
            command.Parameters.AddWithValue("@p1", textBox1.Text);
            command.Parameters.AddWithValue("@p2", textBox2.Text);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Home home = new Home();
                this.Hide();
                home.Show();
            }
            else
            {
                MessageBox.Show("Yanlış girdi.");
            }

            sql.Close();
        }
    }
}
