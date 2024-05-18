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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {

            timer1.Start();
            progressBar1.Visible = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;

            if (progressBar1.Value == 100)
            {
                timer1.Stop();
                Form1 form1 = new Form1();
                this.Hide();
                form1.Show();
            }
        }
    }
}
