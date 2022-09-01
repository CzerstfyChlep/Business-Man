using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
   

namespace BuisnessMan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random rand = new Random();
            Timer timer = new Timer();
            timer.Interval = (10);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            Timer timer2 = new Timer();
            timer2.Interval = (5000);
            timer2.Tick += new EventHandler(timer_Tick2);
            timer2.Start();
            Data.CompanyIDividmentRate = rand.Next(1, 101);
            Data.CompanyIIDividmentRate = rand.Next(1, 101);
            Data.CompanyIIIDividmentRate = rand.Next(1, 101);
            Data.CompanyIVDividmentRate = rand.Next(1, 101);
            Data.CompanyVDividmentRate = rand.Next(1, 101);
            Data.CompanyVIDividmentRate = rand.Next(1, 101);
            IniFile INF = new IniFile(Data.Path);
            #region INI

            if (File.Exists(Data.Path) && INF.Read("Version") == "0.5.0")
            {
                Data.PrivateMoney = double.Parse(INF.Read("PrivateMoney"));
                Data.CompanyMoney = double.Parse(INF.Read("CompanyMoney"));
                Data.CompanyIWorth = double.Parse(INF.Read("CompanyIWorth"));
                Data.CompanyIWorthRise = double.Parse(INF.Read("CompanyIWorthRise"));
                Data.CompanyIPercentageOfRise = float.Parse(INF.Read("CompanyIPercentageOfRise"));
                Data.CompanyIShares = double.Parse(INF.Read("CompanyIShares"));
                Data.CompIAllShares = double.Parse(INF.Read("CompIAllShares"));
                Data.CompanyIDividmentRate = double.Parse(INF.Read("CompanyIDividmentRate"));
                Data.CompanyIIWorth = double.Parse(INF.Read("CompanyIIWorth"));
                Data.CompanyIIWorthRise = double.Parse(INF.Read("CompanyIIWorthRise"));
                Data.CompanyIIPercentageOfRise = float.Parse(INF.Read("CompanyIIPercentageOfRise"));
                Data.CompanyIIShares = float.Parse(INF.Read("CompanyIIShares"));
                Data.CompanyIIDividmentRate = float.Parse(INF.Read("CompanyIIDividmentRate"));
                Data.CompanyIIIWorth = double.Parse(INF.Read("CompanyIIIWorth"));
                Data.CompanyIIIWorthRise = double.Parse(INF.Read("CompanyIIIWorthRise"));
                Data.CompanyIIIPercentageOfRise = float.Parse(INF.Read("CompanyIIIPercentageOfRise"));
                Data.CompanyIIIShares = float.Parse(INF.Read("CompanyIIIShares"));
                Data.CompanyIIIDividmentRate = float.Parse(INF.Read("CompanyIIIDividmentRate"));
                Data.CompanyIVWorth = double.Parse(INF.Read("CompanyIVWorth"));
                Data.CompanyIVWorthRise = double.Parse(INF.Read("CompanyIVWorthRise"));
                Data.CompanyIVPercentageOfRise = float.Parse(INF.Read("CompanyIVPercentageOfRise"));
                Data.CompanyIVShares = float.Parse(INF.Read("CompanyIVShares"));
                Data.CompanyIVDividmentRate = float.Parse(INF.Read("CompanyIVDividmentRate"));
                Data.CompanyVWorth = double.Parse(INF.Read("CompanyVWorth"));
                Data.CompanyVWorthRise = double.Parse(INF.Read("CompanyVWorthRise"));
                Data.CompanyVPercentageOfRise = float.Parse(INF.Read("CompanyVPercentageOfRise"));
                Data.CompanyVShares = float.Parse(INF.Read("CompanyVShares"));
                Data.CompanyVDividmentRate = float.Parse(INF.Read("CompanyVDividmentRate"));
                Data.CompanyVIWorth = double.Parse(INF.Read("CompanyVIWorth"));
                Data.CompanyVIWorthRise = double.Parse(INF.Read("CompanyVIWorthRise"));
                Data.CompanyVIPercentageOfRise = float.Parse(INF.Read("CompanyVIPercentageOfRise"));
                Data.CompanyVIShares = float.Parse(INF.Read("CompanyVIShares"));
                Data.CompanyVIDividmentRate = float.Parse(INF.Read("CompanyVIDividmentRate"));


                



                Data.Company = bool.Parse(INF.Read("Company"));
                if (Data.Company == true)
                {
                    Data.YrCompnyName = INF.Read("YrCompanyName");
                    Data.YrCompanyWorth = double.Parse(INF.Read("YrCompanyWorth"));
                    Data.YrCompanyWorthRise = double.Parse(INF.Read("YrCompanyWorthRise"));
                    Data.YrCompanyPercentageOfRise = float.Parse(INF.Read("YrCompanyPercentageOfRise"));
                    Data.YrCompanyShares = double.Parse(INF.Read("YrCompanyShares"));
                    Data.YrCompanyDividmentRate = float.Parse(INF.Read("YrCompanyDividmentRate"));
                    Data.CompanyIncome = double.Parse(INF.Read("CompanyIncome"));
                    Data.NumberOfUpgrades = int.Parse(INF.Read("NumberOfUpgrades"));
                }




            }
            else
            {
                Directory.CreateDirectory(@"C:\Busisnessman");
                File.Delete(Data.Path);

            }
            #endregion
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            Data.YrCompanyDividmentRate = trackBar1.Value;
            YrDividmentRate.Text = Data.YrCompanyDividmentRate.ToString() + "%";
            MoneyLabel.Text = Data.PrivateMoney.ToString() + "$";
            #region CompanyIText
            CompanyIWorth.Text = Data.CompanyIWorth.ToString() + "$";
            ComIWorthRise.Text = Data.CompanyIWorthRise.ToString() + "$";
            ComIPercentageRise.Text = Data.CompanyIPercentageOfRise.ToString() + "%";
            CompISharesLabel.Text = Data.CompanyIShares.ToString() + "0";
            CompIYrSharesPercent.Text = Math.Ceiling((Data.CompanyIShares / (Data.CompIAllShares + Data.CompanyIShares)) * 100).ToString() + "%";
            #endregion
            #region CompanyIIText
            CompanyIIWorth.Text = Data.CompanyIIWorth.ToString() + "$";
            ComIIWorthRise.Text = Data.CompanyIIWorthRise.ToString() + "$";
            ComIIPercentageRise.Text = Data.CompanyIIPercentageOfRise.ToString() + "%";
            CompIISharesLabel.Text = Data.CompanyIIShares.ToString() + "0";
            CompIIYrSharesPercent.Text = Math.Ceiling((Data.CompanyIIShares / (Data.CompIIAllShares + Data.CompanyIIShares)) * 100).ToString() + "%";
            #endregion
            #region CompanyIIIText
            CompanyIIIWorth.Text = Data.CompanyIIIWorth.ToString() + "$";
            ComIIIWorthRise.Text = Data.CompanyIIIWorthRise.ToString() + "$";
            ComIIIPercentageRise.Text = Data.CompanyIIIPercentageOfRise.ToString() + "%";
            CompIIISharesLabel.Text = Data.CompanyIIIShares.ToString() + "0";
            CompIIIYrSharesPercent.Text = Math.Ceiling((Data.CompanyIIIShares / (Data.CompIIIAllShares + Data.CompanyIIIShares)) * 100).ToString() + "%";
            #endregion
            #region CompanyIVText
            CompanyIVWorth.Text = Data.CompanyIVWorth.ToString() + "$";
            ComIVWorthRise.Text = Data.CompanyIVWorthRise.ToString() + "$";
            ComIVPercentageRise.Text = Data.CompanyIVPercentageOfRise.ToString() + "%";
            CompIVSharesLabel.Text = Data.CompanyIVShares.ToString() + "0";
            CompIVYrSharesPercent.Text = Math.Ceiling((Data.CompanyIVShares / (Data.CompIVAllShares + Data.CompanyIVShares)) * 100).ToString() + "%";
            #endregion
            #region CompanyVText
            CompanyVWorth.Text = Data.CompanyVWorth.ToString() + "$";
            ComVWorthRise.Text = Data.CompanyVWorthRise.ToString() + "$";
            ComVPercentageRise.Text = Data.CompanyVPercentageOfRise.ToString() + "%";
            CompVSharesLabel.Text = Data.CompanyVShares.ToString() + "0";
            CompVYrSharesPercent.Text = Math.Ceiling((Data.CompanyVShares / (Data.CompVAllShares + Data.CompanyVShares)) * 100).ToString() + "%";
            #endregion
            #region CompanyVIText
            CompanyVIWorth.Text = Data.CompanyVIWorth.ToString() + "$";
            ComVIWorthRise.Text = Data.CompanyVIWorthRise.ToString() + "$";
            ComVIPercentageRise.Text = Data.CompanyVIPercentageOfRise.ToString() + "%";
            CompVISharesLabel.Text = Data.CompanyVIShares.ToString() + "0";
            CompVIYrSharesPercent.Text = Math.Ceiling((Data.CompanyVIShares / (Data.CompVIAllShares + Data.CompanyVIShares)) * 100).ToString() + "%";
            #endregion
            #region YrCompanyText
            YrCompanyWorth.Text = Data.YrCompanyWorth.ToString() + "$";
            YrCompanyWorthRise.Text = Data.YrCompanyWorthRise.ToString() + "$";
            YrCompanyPercentageRise.Text = Data.YrCompanyPercentageOfRise.ToString() + "%";
            YrCompSharesLabel.Text = Data.YrCompanyShares.ToString() + "0";
            YrCompYrSharesPercent.Text = Math.Ceiling((Data.YrCompanyShares / (Data.YrCompAllShares + Data.YrCompanyShares)) * 100).ToString() + "%";
            CompanyMoney.Text = Data.CompanyMoney.ToString() + "$";
            CompanyIncome.Text = Data.CompanyIncome.ToString() + "$";
            YrDividmentRate.Text = Data.YrCompanyDividmentRate.ToString() + "%";
            Data.CompanyIncome = 10 + 5 * Data.NumberOfUpgrades;
            #endregion


            #region CompanyIButtons
            if (Data.CompanyIShares == 0)
            {
                CompISellShares.Enabled = false;              
            }
            else
            {
                CompISellShares.Enabled = true;
                
            }
            if (Data.CompanyIShares < 10)
            {
                CompISell10Shares.Enabled = false;
            }
            else
            {
                CompISell10Shares.Enabled = true;
            }
            if (Data.PrivateMoney < (Data.CompanyIWorth * 10) || Data.CompIAllShares == 0)
            {
                CompIBuyShares.Enabled = false;
            }
            else
            {
                CompIBuyShares.Enabled = true;
            }
            Data.A = Data.CompanyIWorth * 110;
            if (Data.PrivateMoney < Data.A || Data.CompIAllShares < 10)
            {
                CompIBuy10Shares.Enabled = false;
            }
            else
            {
                CompIBuy10Shares.Enabled = true;
            }
            #endregion
            #region CompanyIIButtons
            if (Data.CompanyIIShares == 0)
            {
                CompIISellShares.Enabled = false;
            }
            else
            {
                CompIISellShares.Enabled = true;

            }
            if (Data.CompanyIIShares < 10)
            {
                CompIISell10Shares.Enabled = false;
            }
            else
            {
                CompIISell10Shares.Enabled = true;
            }
            if (Data.PrivateMoney < (Data.CompanyIIWorth * 10) || Data.CompIIAllShares == 0)
            {
                CompIIBuyShares.Enabled = false;
            }
            else
            {
                CompIIBuyShares.Enabled = true;
            }

            Data.B = Data.CompanyIIWorth * 110;
            if (Data.PrivateMoney < Data.B || Data.CompIIAllShares < 10)
            {
                CompIIBuy10Shares.Enabled = false;
            }
            else
            {
                CompIIBuy10Shares.Enabled = true;
            }
            #endregion
            #region CompanyIIIButtons
            if (Data.CompanyIIIShares == 0)
            {
                CompIIISellShares.Enabled = false;
            }
            else
            {
                CompIIISellShares.Enabled = true;

            }
            if (Data.CompanyIIIShares < 10)
            {
                CompIIISell10Shares.Enabled = false;
            }
            else
            {
                CompIIISell10Shares.Enabled = true;
            }
            if (Data.PrivateMoney < (Data.CompanyIIIWorth * 10) || Data.CompIIIAllShares == 0)
            {
                CompIIIBuyShares.Enabled = false;
            }
            else
            {
                CompIIIBuyShares.Enabled = true;
            }

            Data.C = Data.CompanyIIIWorth * 110;
            if (Data.PrivateMoney < Data.C || Data.CompIIIAllShares < 10)
            {
                CompIIIBuy10Shares.Enabled = false;
            }
            else
            {
                CompIIIBuy10Shares.Enabled = true;
            }
            #endregion
            #region CompanyIVButtons
            if (Data.CompanyIVShares == 0)
            {
                CompIVSellShares.Enabled = false;
            }
            else
            {
                CompIVSellShares.Enabled = true;

            }
            if (Data.CompanyIVShares < 10)
            {
                CompIVSell10Shares.Enabled = false;
            }
            else
            {
                CompIVSell10Shares.Enabled = true;
            }
            if (Data.PrivateMoney < (Data.CompanyIVWorth * 10) || Data.CompIVAllShares == 0)
            {
                CompIVBuyShares.Enabled = false;
            }
            else
            {
                CompIVBuyShares.Enabled = true;
            }
            if (Data.PrivateMoney < Data.CompanyIVWorth * 110 || Data.CompIVAllShares < 10)
            {
                CompIVBuy10Shares.Enabled = false;
            }
            else
            {
                CompIVBuy10Shares.Enabled = true;
            }
            #endregion
            #region CompanyVButtons
            if (Data.CompanyVShares == 0)
            {
                CompVSellShares.Enabled = false;
            }
            else
            {
                CompVSellShares.Enabled = true;

            }
            if (Data.CompanyVShares < 10)
            {
                CompVSell10Shares.Enabled = false;
            }
            else
            {
                CompVSell10Shares.Enabled = true;
            }
            if (Data.PrivateMoney < (Data.CompanyVWorth * 10) || Data.CompVAllShares == 0)
            {
                CompVBuyShares.Enabled = false;
            }
            else
            {
                CompVBuyShares.Enabled = true;
            }
            if (Data.PrivateMoney < Data.CompanyVWorth * 110 || Data.CompVAllShares < 10)
            {
                CompVBuy10Shares.Enabled = false;
            }
            else
            {
                CompVBuy10Shares.Enabled = true;
            }
            #endregion
            #region CompanyVIButtons
            if (Data.CompanyVIShares == 0)
            {
                CompVISellShares.Enabled = false;
            }
            else
            {
                CompVISellShares.Enabled = true;

            }
            if (Data.CompanyVIShares < 10)
            {
                CompVISell10Shares.Enabled = false;
            }
            else
            {
                CompVISell10Shares.Enabled = true;
            }
            if (Data.PrivateMoney < (Data.CompanyVIWorth * 10) || Data.CompVIAllShares == 0)
            {
                CompVIBuyShares.Enabled = false;
            }
            else
            {
                CompVIBuyShares.Enabled = true;
            }
            if (Data.PrivateMoney < Data.CompanyVIWorth * 110 || Data.CompVIAllShares < 10)
            {
                CompVIBuy10Shares.Enabled = false;
            }
            else
            {
                CompVIBuy10Shares.Enabled = true;
            }
            #endregion
            #region YrCompanyButtons
            if (Data.YrCompanyShares == 0 && Data.Company == false)
            {
                YrCompSellShares.Enabled = false;
            }
            else
            {
                YrCompSellShares.Enabled = true;

            }
            if (Data.YrCompanyShares < 10 && Data.Company == false)
            {
                YrCompSell10Shares.Enabled = false;
            }
            else
            {
                YrCompSell10Shares.Enabled = true;
            }
            if ((Data.CompanyMoney < (Data.YrCompanyWorth * 10) || Data.YrCompAllShares == 0) || Data.Company == false)
            {
                YrCompBuyShares.Enabled = false;
            }
            else
            {
                YrCompBuyShares.Enabled = true;
            }
            if ((Data.CompanyMoney < Data.YrCompanyWorth * 110 || Data.YrCompAllShares < 10) || Data.Company == false)
            {
                YrCompBuy10Shares.Enabled = false;
            }
            else
            {
                YrCompBuy10Shares.Enabled = true;
            }
            if (Data.PrivateMoney < 1000)
            {
                button5.Enabled = false;
            }
            else
            {
                button5.Enabled = true;
            }
            if (Data.CompanyMoney < Data.NumberOfUpgrades * 500)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
            #endregion
            Data.PrivateMoney = (Math.Ceiling(Data.PrivateMoney * 100)) / 100;
            Data.CompanyMoney = (Math.Ceiling(Data.CompanyMoney * 100)) / 100;
            if (Data.MenuOpen == true)
            {
                this.Enabled = false;
            }
            else
            {
                this.Enabled = true;
            }
            if (Data.Company == true)
            {
                button3.Visible = false;
                button3.Enabled = false;
                YrCompanyNameLabel.Text = Data.YrCompnyName;
                YrCompanyNameLabel.Visible = true;
                YrCompanyWorth.Visible = true;
                YrCompanyWorthRise.Visible = true;
                YrCompanyPercentageRise.Visible = true;
                YrCompSell10Shares.Visible = true;
                YrCompSellShares.Visible = true;
                YrCompSharesLabel.Visible = true;
                YrCompBuyShares.Visible = true;
                YrCompBuy10Shares.Visible = true;
                YrCompYrSharesPercent.Visible = true;
                CompanyMoney.Visible = true;
                CompanyIncome.Visible = true;
                trackBar1.Enabled = true;
                trackBar1.Visible = true;
                YrDividmentRate.Visible = true;
                button5.Visible = true;
                button4.Visible = true;
            }


        }
        private void timer_Tick2(object sender, EventArgs e)
        {
            if (Data.MenuOpen == false) {


                Random Rand = new Random();
                #region CompanyIMain
                Data.CompanyIPercentageOfRise += Rand.Next(-50, 50) / 10F;
                Data.CompanyIWorthRise = Data.CompanyIWorth * (Data.CompanyIPercentageOfRise /
                    100);
                Data.CompanyIWorthRise = (Math.Ceiling(Data.CompanyIWorthRise * 1000)) / 1000;
                #endregion
                #region CompanyIIMain
                Data.CompanyIIPercentageOfRise += Rand.Next(-50, 50) / 10F;
                Data.CompanyIIWorthRise = Data.CompanyIIWorth * (Data.CompanyIIPercentageOfRise /
                    100);
                Data.CompanyIIWorthRise = (Math.Ceiling(Data.CompanyIIWorthRise * 1000)) / 1000;
                #endregion
                #region CompanyIIIMain
                Data.CompanyIIIPercentageOfRise += Rand.Next(-50, 50) / 10F;
                Data.CompanyIIIWorthRise = Data.CompanyIIIWorth * (Data.CompanyIIIPercentageOfRise /
                    100);
                Data.CompanyIIIWorthRise = (Math.Ceiling(Data.CompanyIIIWorthRise * 1000)) / 1000;
                #endregion
                #region CompanyIVMain
                Data.CompanyIVPercentageOfRise += Rand.Next(-50, 50) / 10F;
                Data.CompanyIVWorthRise = Data.CompanyIVWorth * (Data.CompanyIVPercentageOfRise /
                    100);
                Data.CompanyIVWorthRise = (Math.Ceiling(Data.CompanyIVWorthRise * 1000)) / 1000;
                #endregion
                #region CompanyVMain
                Data.CompanyVPercentageOfRise += Rand.Next(-50, 50) / 10F;
                Data.CompanyVWorthRise = Data.CompanyVWorth * (Data.CompanyVPercentageOfRise /
                    100);
                Data.CompanyVWorthRise = (Math.Ceiling(Data.CompanyVWorthRise * 1000)) / 1000;
                #endregion
                #region CompanyVIMain
                Data.CompanyVIPercentageOfRise += Rand.Next(-50, 50) / 10F;
                Data.CompanyVIWorthRise = Data.CompanyVIWorth * (Data.CompanyVIPercentageOfRise /
                    100);
                Data.CompanyVIWorthRise = (Math.Ceiling(Data.CompanyVIWorthRise * 1000)) / 1000;
                #endregion
                #region YrCompanyMain
                Data.YrCompanyPercentageOfRise += Rand.Next(-50, 50) / 10F;
                Data.YrCompanyWorthRise = Data.YrCompanyWorth * (Data.YrCompanyPercentageOfRise /
                    100);
                Data.YrCompanyWorthRise = (Math.Ceiling(Data.YrCompanyWorthRise * 1000)) / 1000;
                #endregion





                #region Events CompanyI
                if (Data.CompanyIShares == Data.CompIAllShares + 1)
                {
                    MessageBox.Show("You got the majority of shares in Raulex, thus you are the new CEO!", "Majority!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Data.CompanyIWorth <= 0.2)
                {
                    if (Rand.Next(1, 3) == 1)
                    {
                        Data.CompIAllShares += Data.CompanyIShares;
                        Data.CompanyIShares = 0;
                        Data.CompanyIWorth = 1.00;
                        Data.CompanyIWorthRise = 0;
                        Data.CompanyIPercentageOfRise = 0;
                        MessageBox.Show("Raulex declared bankruptcy, your all shares are canceled.", "Bankruptcy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Data.CompanyIPercentageOfRise > 30)
                {
                    if (Rand.Next(1, 4) == 1)
                    {
                        Data.CompanyIPercentageOfRise -= 30;
                        Data.CompanyIPercentageOfRise = 0;
                        MessageBox.Show("The rise of Raulex worth stopped!", "Economy Cooling", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Rand.Next(1, 101) == 1)
                {
                    Data.CompanyIPercentageOfRise += Rand.Next(-30, -20);
                    MessageBox.Show("The rise of Raulex worth dropped dramticly!", "Economy Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Data.CompanyIPercentageOfRise <= -20 && Rand.Next(1, 11) == 1)
                {
                    Data.CompanyIPercentageOfRise += Rand.Next(20, 30);
                    MessageBox.Show("Raulex is recovering.", "Back on track", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Rand.Next(1, 501) == 1 && Data.CompanyIWorth > 20)
                {
                    Data.CompanyIWorth -= Data.CompanyIWorth / 2;
                    MessageBox.Show("Raulex CEO caught taking bribes!", "Scandal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }





                #endregion
                #region Events CompanyII
                if (Data.CompanyIIShares == Data.CompIIAllShares + 1)
                {
                    MessageBox.Show("You got the majority of shares in Wateg, thus you are the new CEO!", "Majority!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Data.CompanyIIWorth <= 0.2)
                {
                    if (Rand.Next(1, 3) == 1)
                    {
                        Data.CompIIAllShares += Data.CompanyIIShares;
                        Data.CompanyIIShares = 0;
                        Data.CompanyIIWorthRise = 0;
                        Data.CompanyIIWorth = 1.00;
                        Data.CompanyIIPercentageOfRise = 0;
                        MessageBox.Show("Wateg declared bankruptcy, your all shares are canceled.", "Bankruptcy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Data.CompanyIIPercentageOfRise > 30)
                {
                    if (Rand.Next(1, 4) == 1)
                    {
                        Data.CompanyIIPercentageOfRise -= 30;
                        Data.CompanyIIPercentageOfRise = 0;
                        MessageBox.Show("The rise of Wateg worth stopped!", "Economy Cooling", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Rand.Next(1, 101) == 1)
                {
                    Data.CompanyIIPercentageOfRise += Rand.Next(-30, -20);
                    MessageBox.Show("The rise of Wateg worth dropped dramticly!", "Economy Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Data.CompanyIIPercentageOfRise <= -20 && Rand.Next(1, 11) == 1)
                {
                    Data.CompanyIIPercentageOfRise += Rand.Next(20, 30);
                    MessageBox.Show("Wateg is recovering.", "Back on track", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Rand.Next(1, 501) == 1 && Data.CompanyIIWorth > 20)
                {
                    Data.CompanyIIWorth -= Data.CompanyIIWorth / 2;
                    MessageBox.Show("Wateg CEO caught taking bribes!", "Scandal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                #region Events CompanyIII
                if (Data.CompanyIIShares == Data.CompIIAllShares + 1)
                {
                    MessageBox.Show("You got the majority of shares in InfHost, thus you are the new CEO!", "Majority!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Data.CompanyIIIWorth <= 0.2)
                {
                    if (Rand.Next(1, 3) == 1)
                    {
                        Data.CompIIIAllShares += Data.CompanyIIIShares;
                        Data.CompanyIIIShares = 0;
                        Data.CompanyIIIWorthRise = 0;
                        Data.CompanyIIIWorth = 1.00;
                        Data.CompanyIIIPercentageOfRise = 0;
                        MessageBox.Show("InfHost declared bankruptcy, your all shares are canceled.", "Bankruptcy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Data.CompanyIIIPercentageOfRise > 30)
                {
                    if (Rand.Next(1, 4) == 1)
                    {
                        Data.CompanyIIIPercentageOfRise -= 30;
                        Data.CompanyIIIPercentageOfRise = 0;
                        MessageBox.Show("The rise of InfHost worth stopped!", "Economy Cooling", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Rand.Next(1, 101) == 1)
                {
                    Data.CompanyIIIPercentageOfRise += Rand.Next(-30, -20);
                    MessageBox.Show("The rise of InfHost worth dropped dramticly!", "Economy Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Data.CompanyIIIPercentageOfRise <= -20 && Rand.Next(1, 11) == 1)
                {
                    Data.CompanyIIIPercentageOfRise += Rand.Next(20, 30);
                    MessageBox.Show("InfHost is recovering.", "Back on track", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Rand.Next(1, 501) == 1 && Data.CompanyIIIWorth > 20)
                {
                    Data.CompanyIIIWorth -= Data.CompanyIIIWorth / 2;
                    MessageBox.Show("InfHost CEO caught taking bribes!", "Scandal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                #region Events CompanyIV
                if (Data.CompanyIVShares == Data.CompIVAllShares + 1)
                {
                    MessageBox.Show("You got the majority of shares in PBT, thus you are the new CEO!", "Majority!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Data.CompanyIVWorth <= 0.2)
                {
                    if (Rand.Next(1, 3) == 1)
                    {
                        Data.CompIVAllShares += Data.CompanyIVShares;
                        Data.CompanyIVShares = 0;
                        Data.CompanyIVWorthRise = 0;
                        Data.CompanyIVWorth = 1.00;
                        Data.CompanyIVPercentageOfRise = 0;
                        MessageBox.Show("PBT declared bankruptcy, your all shares are canceled.", "Bankruptcy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Data.CompanyIVPercentageOfRise > 30)
                {
                    if (Rand.Next(1, 4) == 1)
                    {
                        Data.CompanyIVPercentageOfRise -= 30;
                        Data.CompanyIVPercentageOfRise = 0;
                        MessageBox.Show("The rise of PBT worth stopped!", "Economy Cooling", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Rand.Next(1, 101) == 1)
                {
                    Data.CompanyIVPercentageOfRise += Rand.Next(-30, -20);
                    MessageBox.Show("The rise of PBT worth dropped dramticly!", "Economy Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Data.CompanyIVPercentageOfRise <= -20 && Rand.Next(1, 11) == 1)
                {
                    Data.CompanyIVPercentageOfRise += Rand.Next(20, 30);
                    MessageBox.Show("PBT is recovering.", "Back on track", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Rand.Next(1, 501) == 1 && Data.CompanyIVWorth > 20)
                {
                    Data.CompanyIVWorth -= Data.CompanyIVWorth / 2;
                    MessageBox.Show("PBT CEO caught taking bribes!", "Scandal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                #region Events CompanyV
                if (Data.CompanyVShares == Data.CompVAllShares + 1)
                {
                    MessageBox.Show("You got the majority of shares in StaleBread, thus you are the new CEO!", "Majority!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Data.CompanyVWorth <= 0.2)
                {
                    if (Rand.Next(1, 3) == 1)
                    {
                        Data.CompVAllShares += Data.CompanyVShares;
                        Data.CompanyVShares = 0;
                        Data.CompanyVWorthRise = 0;
                        Data.CompanyVWorth = 1.00;
                        Data.CompanyVPercentageOfRise = 0;
                        MessageBox.Show("StaleBread declared bankruptcy, your all shares are canceled.", "Bankruptcy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Data.CompanyVPercentageOfRise > 30)
                {
                    if (Rand.Next(1, 4) == 1)
                    {
                        Data.CompanyVPercentageOfRise = 0;
                        MessageBox.Show("The rise of StaleBread worth stopped!", "Economy Cooling", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Rand.Next(1, 101) == 1)
                {
                    Data.CompanyVPercentageOfRise += Rand.Next(-30, -20);
                    MessageBox.Show("The rise of StaleBread worth dropped dramticly!", "Economy Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Data.CompanyVPercentageOfRise <= -20 && Rand.Next(1, 11) == 1)
                {
                    Data.CompanyVPercentageOfRise += Rand.Next(20, 30);
                    MessageBox.Show("StaleBread is recovering.", "Back on track", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Rand.Next(1, 501) == 1 && Data.CompanyVWorth > 20)
                {
                    Data.CompanyVWorth -= Data.CompanyVWorth / 2;
                    MessageBox.Show("StaleBread CEO caught taking bribes!", "Scandal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                #region Events CompanyVI
                if (Data.CompanyVIShares == Data.CompVIAllShares + 1)
                {
                    MessageBox.Show("You got the majority of shares in Galaretex, thus you are the new CEO!", "Majority!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (Data.CompanyVIWorth <= 0.2)
                {
                    if (Rand.Next(1, 3) == 1)
                    {
                        Data.CompVIAllShares += Data.CompanyVIShares;
                        Data.CompanyVIShares = 0;
                        Data.CompanyVIWorthRise = 0;
                        Data.CompanyVIWorth = 1.00;
                        Data.CompanyVIPercentageOfRise = 0;
                        MessageBox.Show("Galaretex declared bankruptcy, your all shares are canceled.", "Bankruptcy", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Data.CompanyVIPercentageOfRise > 30)
                {
                    if (Rand.Next(1, 4) == 1)
                    {
                        Data.CompanyVIPercentageOfRise = 0;
                        MessageBox.Show("The rise of Galaretex worth stopped!", "Economy Cooling", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                if (Rand.Next(1, 101) == 1)
                {
                    Data.CompanyVIPercentageOfRise += Rand.Next(-30, -20);
                    MessageBox.Show("The rise of Galaretex worth dropped dramticly!", "Economy Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Data.CompanyVIPercentageOfRise <= -20 && Rand.Next(1, 11) == 1)
                {
                    Data.CompanyVIPercentageOfRise += Rand.Next(20, 30);
                    MessageBox.Show("Galaretex is recovering.", "Back on track", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (Rand.Next(1, 501) == 1 && Data.CompanyVIWorth > 20)
                {
                    Data.CompanyVIWorth -= Data.CompanyVIWorth / 2;
                    MessageBox.Show("Galaretex CEO caught taking bribes!", "Scandal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
                Data.CompanyIWorth += Data.CompanyIWorthRise;
                Data.CompanyIIWorth += Data.CompanyIIWorthRise;
                Data.CompanyIIIWorth += Data.CompanyIIIWorthRise;
                Data.CompanyIVWorth += Data.CompanyIVWorthRise;
                Data.CompanyVWorth += Data.CompanyVWorthRise;
                Data.CompanyVIWorth += Data.CompanyVIWorthRise;
                Data.YrCompanyWorth += Data.YrCompanyWorthRise;
                Data.CompanyMoney += Data.CompanyIncome;

                Data.PrivateMoney += Data.CompanyIWorth * (Math.Ceiling((Data.CompanyIShares / (Data.CompIAllShares + Data.CompanyIShares)) * 100)) * (Data.CompanyIDividmentRate / 100);
                Data.PrivateMoney += Data.CompanyIIWorth * (Math.Ceiling((Data.CompanyIIShares / (Data.CompIIAllShares + Data.CompanyIIShares)) * 100)) * (Data.CompanyIIDividmentRate / 100);
                Data.PrivateMoney += Data.CompanyIIIWorth * (Math.Ceiling((Data.CompanyIIIShares / (Data.CompIIIAllShares + Data.CompanyIIIShares)) * 100)) * (Data.CompanyIIIDividmentRate / 100);
                Data.PrivateMoney += Data.CompanyIVWorth * (Math.Ceiling((Data.CompanyIVShares / (Data.CompIVAllShares + Data.CompanyIVShares)) * 100)) * (Data.CompanyIVDividmentRate / 100);
                Data.PrivateMoney += Data.CompanyVWorth * (Math.Ceiling((Data.CompanyVShares / (Data.CompVAllShares + Data.CompanyVShares)) * 100))* (Data.CompanyVDividmentRate / 100);
                Data.PrivateMoney += Data.CompanyVIWorth * (Math.Ceiling((Data.CompanyVIShares / (Data.CompVIAllShares + Data.CompanyVIShares)) * 100)) * (Data.CompanyVIDividmentRate / 100);
                Data.PrivateMoney += Data.CompanyMoney * (Math.Ceiling((Data.YrCompanyShares / (Data.YrCompAllShares + Data.YrCompanyShares)))) * (Data.YrCompanyDividmentRate / 100);
                Data.CompanyMoney -= Data.CompanyMoney * (Data.YrCompanyDividmentRate / 100);
            }
        }
        public static class Data
        {
            public static double PrivateMoney = 50;
            public static double CompanyMoney;
            #region CompanyIData
            public static double CompanyIWorth = 1.00;
            public static double CompanyIWorthRise = 0.00;
            public static float CompanyIPercentageOfRise = 0F;
            public static double CompanyIShares;
            public static double CompIAllShares = 1000;
            public static double CompanyIDividmentRate;
            #endregion
            #region CompanyIIData
            public static double CompanyIIWorth = 1.00;
            public static double CompanyIIWorthRise = 0.00;
            public static float CompanyIIPercentageOfRise = 0F;
            public static double CompanyIIShares;
            public static double CompIIAllShares = 3000;
            public static double CompanyIIDividmentRate;
            #endregion
            #region CompanyIIIData
            public static double CompanyIIIWorth = 1.00;
            public static double CompanyIIIWorthRise = 0.00;
            public static float CompanyIIIPercentageOfRise = 0F;
            public static double CompanyIIIShares;
            public static double CompIIIAllShares = 500;
            public static double CompanyIIIDividmentRate;
            #endregion
            #region CompanyIVData
            public static double CompanyIVWorth = 1.00;
            public static double CompanyIVWorthRise = 0.00;
            public static float CompanyIVPercentageOfRise = 0F;
            public static double CompanyIVShares;
            public static double CompIVAllShares = 10000;
            public static double CompanyIVDividmentRate;
            #endregion
            #region CompanyVData
            public static double CompanyVWorth = 1.00;
            public static double CompanyVWorthRise = 0.00;
            public static float CompanyVPercentageOfRise = 0F;
            public static double CompanyVShares;
            public static double CompVAllShares = 10000;
            public static double CompanyVDividmentRate;
            #endregion
            #region CompanyVIData
            public static double CompanyVIWorth = 1.00;
            public static double CompanyVIWorthRise = 0.00;
            public static float CompanyVIPercentageOfRise = 0F;
            public static double CompanyVIShares;
            public static double CompVIAllShares = 5000;
            public static double CompanyVIDividmentRate;
            #endregion
            #region YrCompanyData
            public static double YrCompanyWorth = 1.00;
            public static double YrCompanyWorthRise = 0.00;
            public static float YrCompanyPercentageOfRise = 0F;
            public static double YrCompanyShares = 1000;
            public static double YrCompAllShares = 0;
            public static double YrCompanyDividmentRate;
            public static double CompanyIncome;
            public static int NumberOfUpgrades = 0;
            #endregion
            public static double A;
            public static double B;
            public static double C;
            public static string Path = @"C:\Busisnessman\Busisnessman.ini";
            public static bool MenuOpen = false;
            public static string YrCompnyName = null;
            public static bool Company = false;
            

        }
        #region CompanyIButtonsVoid
        private void CompISellShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIShares--;
            Data.CompIAllShares++;
            Data.PrivateMoney += Data.CompanyIWorth * 10;
        }

        private void CompIBuyShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIShares++;
            Data.CompIAllShares--;
            Data.PrivateMoney -= Data.CompanyIWorth * 10;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++) {
                Data.CompanyIShares++;
                Data.CompIAllShares--;
                Data.PrivateMoney -= Data.CompanyIWorth * 10;
            }
        }

        private void CompISell10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyIShares--;
                Data.CompIAllShares++;
                Data.PrivateMoney += Data.CompanyIWorth * 10;
            }
        }
        #endregion
        #region CompanyIIButtonVoid
        private void CompIISell10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyIIShares--;
                Data.CompIIAllShares++;
                Data.PrivateMoney += Data.CompanyIIWorth * 10;
            }
        }

        private void CompIISellShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIIShares--;
            Data.CompIIAllShares++;
            Data.PrivateMoney += Data.CompanyIIWorth * 10;
        }

        private void CompIIBuyShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIIShares++;
            Data.CompIIAllShares--;
            Data.PrivateMoney -= Data.CompanyIIWorth * 10;
        }

        private void CompIIBuy10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyIIShares++;
                Data.CompIIAllShares--;
                Data.PrivateMoney -= Data.CompanyIIWorth * 10;
            }
        }
        #endregion
        #region CompanyIIIButtonVoid

        private void CompIIISell10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyIIIShares--;
                Data.CompIIIAllShares++;
                Data.PrivateMoney += Data.CompanyIIIWorth * 10;
            }
        }

        private void CompIIISellShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIIIShares--;
            Data.CompIIIAllShares++;
            Data.PrivateMoney += Data.CompanyIIIWorth * 10;
        }

        private void CompIIIBuyShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIIIShares++;
            Data.CompIIIAllShares--;
            Data.PrivateMoney -= Data.CompanyIIIWorth * 10;
        }

        private void CompIIIBuy10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyIIIShares++;
                Data.CompIIIAllShares--;
                Data.PrivateMoney -= Data.CompanyIIIWorth * 10;
            }
        }
        #endregion
        #region CompanyIVButtonVoid
        private void CompIVSell10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyIVShares--;
                Data.CompIVAllShares++;
                Data.PrivateMoney += Data.CompanyIVWorth * 10;
            }
        }

        private void CompIVSellShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIVShares--;
            Data.CompIVAllShares++;
            Data.PrivateMoney += Data.CompanyIVWorth * 10;
        }

        private void CompIVBuyShares_Click(object sender, EventArgs e)
        {
            Data.CompanyIVShares++;
            Data.CompIVAllShares--;
            Data.PrivateMoney -= Data.CompanyIVWorth * 10;
        }

        private void CompIVBuy10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyIVShares++;
                Data.CompIVAllShares--;
                Data.PrivateMoney -= Data.CompanyIVWorth * 10;
            }
        }
        #endregion
        #region CompanyVButtonVoid
        private void CompVSell10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyVShares--;
                Data.CompVAllShares++;
                Data.PrivateMoney += Data.CompanyVWorth * 10;
            }
        }

        private void CompVSellShares_Click(object sender, EventArgs e)
        {
            Data.CompanyVShares--;
            Data.CompVAllShares++;
            Data.PrivateMoney += Data.CompanyVWorth * 10;
        }

        private void CompVBuyShares_Click(object sender, EventArgs e)
        {
            Data.CompanyVShares++;
            Data.CompVAllShares--;
            Data.PrivateMoney -= Data.CompanyVWorth * 10;
        }

        private void CompVBuy10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyVShares++;
                Data.CompVAllShares--;
                Data.PrivateMoney -= Data.CompanyVWorth * 10;
            }
        }
        #endregion
        #region CompanyVIButtonVoid
        private void CompVISell10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyVIShares--;
                Data.CompVIAllShares++;
                Data.PrivateMoney += Data.CompanyVIWorth * 10;
            }
        }

        private void CompVISellShares_Click(object sender, EventArgs e)
        {
            Data.CompanyVIShares--;
            Data.CompVIAllShares++;
            Data.PrivateMoney += Data.CompanyVIWorth * 10;
        }

        private void CompVIBuyShares_Click(object sender, EventArgs e)
        {
            Data.CompanyVIShares++;
            Data.CompVIAllShares--;
            Data.PrivateMoney -= Data.CompanyVIWorth * 10;
        }

        private void CompVIBuy10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.CompanyVIShares++;
                Data.CompVIAllShares--;
                Data.PrivateMoney -= Data.CompanyVIWorth * 10;
            }
        }
        #endregion
        #region YrCompanyButtonVoid
        private void YrCompSell10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.YrCompanyShares--;
                Data.YrCompAllShares++;
                Data.CompanyMoney += Data.YrCompanyWorth * 10;
            }
        }

        private void YrCompSellShares_Click(object sender, EventArgs e)
        {
            Data.YrCompanyShares--;
            Data.YrCompAllShares++;
            Data.CompanyMoney += Data.YrCompanyWorth * 10;
        }

        private void YrCompBuyShares_Click(object sender, EventArgs e)
        {
            Data.YrCompanyShares++;
            Data.YrCompAllShares--;
            Data.CompanyMoney -= Data.YrCompanyWorth * 10;
        }

        private void YrCompBuy10Shares_Click(object sender, EventArgs e)
        {
            for (int a = 1; a < 11; a++)
            {
                Data.YrCompanyShares++;
                Data.YrCompAllShares--;
                Data.CompanyMoney -= Data.YrCompanyWorth * 10;
            }
        }
        #endregion

        private void button1_Click_1(object sender, EventArgs e)
        {
            IniFile INF = new IniFile(Data.Path);
            File.WriteAllText(Data.Path , @"jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	
jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	ejgeitfneriymej89iofriesk03ewjru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	jru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	UJjru3idr93n48ska9p4e823j999u4md,prs3ioer34mut9d0k24[rslp3[054pitf4dtr34l0srk34idr034#%#F$%^$%D%#D$%^F$%dr4tf%^FY54t#$D%D$%dt34ES#RD+$%FYF$%R_FDT%^_FYD$%T_S$%Y_D$TR_EG_S$^YD%^TG_ERFVDFG_NTY_C$WE_DTY_FCT$RF_Q#S$DT_%^YEW_FD	WEGHW%^YT_F#$EWDSZ@_ET%$E_DYT$WG_KY_TGEWRT_DW%$TD_ERGFK_YHBFDD%fyhtrgerpod4etgerpodtk45iofyntdq3soiemj2IO	UJIHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54	IHWJTKOEWIJAKLTOPS,FAD,W0OPDSTGK5,RYPODT54");
            INF.Write("Version", "0.5.0");
            INF.Write("PrivateMoney", Data.PrivateMoney.ToString());
            INF.Write("CompanyMoney", Data.CompanyMoney.ToString());
            INF.Write("CompanyIWorth", Data.CompanyIWorth.ToString());
            INF.Write("CompanyIWorthRise", Data.CompanyIWorthRise.ToString());
            INF.Write("CompanyIPercentageOfRise", Data.CompanyIPercentageOfRise.ToString());
            INF.Write("CompanyIShares", Data.CompanyIShares.ToString());
            INF.Write("CompIAllShares", Data.CompIAllShares.ToString());
            INF.Write("CompanyIDividmentRate", Data.CompanyIDividmentRate.ToString());
            INF.Write("CompanyIIWorth", Data.CompanyIIWorth.ToString());
            INF.Write("CompanyIIWorthRise", Data.CompanyIIWorthRise.ToString());
            INF.Write("CompanyIIPercentageOfRise",Data.CompanyIIPercentageOfRise.ToString());
            INF.Write("CompanyIIShares", Data.CompanyIIShares.ToString());
            INF.Write("CompIIAllShares", Data.CompIIAllShares.ToString());
            INF.Write("CompanyIIDividmentRate", Data.CompanyIIDividmentRate.ToString());
            INF.Write("CompanyIIIWorth", Data.CompanyIIIWorth.ToString());
            INF.Write("CompanyIIIWorthRise", Data.CompanyIIIWorthRise.ToString());
            INF.Write("CompanyIIIPercentageOfRise", Data.CompanyIIIPercentageOfRise.ToString());
            INF.Write("CompanyIIIShares", Data.CompanyIIIShares.ToString());
            INF.Write("CompIIIAllShares",Data.CompIIIAllShares.ToString());
            INF.Write("CompanyIIIDividmentRate", Data.CompanyIIIDividmentRate.ToString());
            INF.Write("CompanyIVWorth", Data.CompanyIVWorth.ToString());
            INF.Write("CompanyIVWorthRise", Data.CompanyIVWorthRise.ToString());
            INF.Write("CompanyIVPercentageOfRise", Data.CompanyIVPercentageOfRise.ToString());
            INF.Write("CompanyIVShares", Data.CompanyIVShares.ToString());
            INF.Write("CompIVAllShares", Data.CompIVAllShares.ToString());
            INF.Write("CompanyIVDividmentRate", Data.CompanyIVDividmentRate.ToString());
            INF.Write("CompanyVWorth", Data.CompanyVWorth.ToString());
            INF.Write("CompanyVWorthRise", Data.CompanyVWorthRise.ToString());
            INF.Write("CompanyVPercentageOfRise", Data.CompanyVPercentageOfRise.ToString());
            INF.Write("CompanyVShares", Data.CompanyVShares.ToString());
            INF.Write("CompVAllShares", Data.CompVAllShares.ToString());
            INF.Write("CompanyVDividmentRate", Data.CompanyVDividmentRate.ToString());
            INF.Write("CompanyVIWorth", Data.CompanyVIWorth.ToString());
            INF.Write("CompanyVIWorthRise", Data.CompanyVIWorthRise.ToString());
            INF.Write("CompanyVIPercentageOfRise", Data.CompanyVIPercentageOfRise.ToString());
            INF.Write("CompanyVIShares", Data.CompanyVIShares.ToString());
            INF.Write("CompVIAllShares", Data.CompVIAllShares.ToString());
            INF.Write("CompanyVIDividmentRate", Data.CompanyVIDividmentRate.ToString());
            INF.Write("Company", Data.Company.ToString());
            if (Data.Company == true)
            {
                INF.Write("YrCompanyName", Data.YrCompnyName);
                INF.Write("YrCompanyWorth", Data.YrCompanyWorth.ToString());
                INF.Write("YrCompanyWorthRise", Data.YrCompanyWorthRise.ToString());
                INF.Write("YrCompanyPercentageOfRise", Data.YrCompanyPercentageOfRise.ToString());
                INF.Write("YrCompanyShares", Data.YrCompanyShares.ToString());
                INF.Write("YrCompAllShares", Data.YrCompAllShares.ToString());
                INF.Write("YrCompanyDividmentRate", Data.YrCompanyDividmentRate.ToString());
                INF.Write("CompanyIncome", Data.CompanyIncome.ToString());
                INF.Write("NumberOfUpgrades", Data.NumberOfUpgrades.ToString());
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.Delete(Data.Path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CompCreateMenu CCM = new CompCreateMenu();
            CCM.Show();
            Data.MenuOpen = true;           
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Data.YrCompanyDividmentRate = trackBar1.Value / 100;
            YrDividmentRate.Text = Data.YrCompanyDividmentRate.ToString() + "%";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Data.PrivateMoney -= 1000;
            Data.CompanyMoney += 1000;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Data.CompanyMoney -= 500 * Data.NumberOfUpgrades;
           // Data.NumberOfUpgrades++;
           // Data.YrCompanyPercentageOfRise += 1;
            Upgrademenu UM = new Upgrademenu();
            UM.Show();
            Data.MenuOpen = true;
        }
    }
    class IniFile   // revision 11
    {
        string Path = @"C:\Buisnessman.ini";
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}

    
