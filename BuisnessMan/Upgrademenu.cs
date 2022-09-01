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
    public partial class Upgrademenu : Form
    {
        public Upgrademenu()
        {
            InitializeComponent();
            Timer timer = new Timer();
            timer.Interval = (10000);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            Timer timer2 = new Timer();
            timer2.Interval = (10);
            timer2.Tick += new EventHandler(timer_Tick2);
            timer2.Start();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Data.MenuOpen = false;
            this.Close();
        }
        private void timer_Tick2(object sender, EventArgs e)
        {
            if(DataUpgradeMenu.Slot1Free == false)
            {
                Name1.Visible = true;
            }
            Name1.Text = DataUpgradeMenu.Name1;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Enterprises Enterprise1 = new  Enterprises();
            if (DataUpgradeMenu.Slot1Free == false && Enterprise1.OfferTime > 0)
            {
                Enterprise1.OfferTime--;
            }
            if (DataUpgradeMenu.Slot1Free == true ||(Enterprise1.OfferTime == 0 && DataUpgradeMenu.Slot1Free == false))
            {
                Random Rand = new Random();               
                int Name1 = Rand.Next(1, 2);
                int Name2 = Rand.Next(1, 6);
                int Name1A = Name1 * 10 + Name2;
                DataUpgradeMenu.Slot1Free = false;
                switch (Name1A)
                {
                    case 11:
                        Enterprise1.Name = "Como";
                        break;
                    case 12:
                        Enterprise1.Name = "Cogla";
                        break;
                    case 13:
                        Enterprise1.Name = "Coton";
                        break;
                    case 14:
                        Enterprise1.Name = "Cojo";
                        break;
                    case 15:
                        Enterprise1.Name = "Codaw";
                        break;
                }
                Enterprise1.OfferTime = 5;
                DataUpgradeMenu.Name1 = Enterprise1.Name;   
            }
            
        }

    }
    public class Enterprises
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public int profit { get; set; }
        public int OfferTime { get; set; }
    }
    public static class DataUpgradeMenu
    {
        public static bool Slot1Free = true;
        public static bool Slot2Free = true;
        public static bool Slot3Free = true;
        public static bool Slot4Free = true;
        public static bool Slot5Free = true;
        public static string Name1;
    }
}
    





