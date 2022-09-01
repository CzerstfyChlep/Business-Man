using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuisnessMan
{
    public partial class CompCreateMenu : Form
    {
        public CompCreateMenu()
        {
            InitializeComponent();
            if (Form1.Data.PrivateMoney < 10000)
            {
                trackBar1.Enabled = false;
                CreateButton.Enabled = false;
                label2.Text = "0$";
            }
            trackBar1.Maximum = (int)Math.Floor(Form1.Data.PrivateMoney / 10000);
        }

        private void CompCreateMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Form1.Data.MenuOpen = false;
            this.Close();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Form1.Data.YrCompnyName = textBox1.Text;
            Form1.Data.CompanyMoney = trackBar1.Value * 10000;
            Form1.Data.PrivateMoney -= trackBar1.Value * 10000;
            Form1.Data.Company = true;
            Form1.Data.MenuOpen = false;
            this.Close();

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = (trackBar1.Value * 10000).ToString() + "$";
        }
    }
}
