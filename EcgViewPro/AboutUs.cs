using System;
using System.Windows.Forms;
using System.IO;

namespace EcgViewPro
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://www.ainia.com.cn"); 
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + @"\AboutUs.txt"))
            {
               lblVersion.Text=File.ReadAllText(Application.StartupPath + @"\AboutUs.txt").Trim();
            }
        }

    

    }
}
