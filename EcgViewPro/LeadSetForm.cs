using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProj;

namespace EcgViewPro
{
    public partial class LeadSetForm : Form
    {
        public LeadSetForm()
        {
            InitializeComponent();
        }

        private void cBoxSingleLead_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigHelper.SingleLead = cBoxSingleLead.SelectedIndex;

            var dic = new Dictionary<string, string>
                {
                    {"SingleLead", ConfigHelper.SingleLead.ToString()}
                };
            ConfigHelper.SaveConfig(dic);
        }

        private void LeadSetForm_Load(object sender, EventArgs e)
        {
            cBoxSingleLead.SelectedIndex = ConfigHelper.SingleLead;
        }
    }
}
