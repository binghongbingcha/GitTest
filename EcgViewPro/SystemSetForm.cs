using System.Windows.Forms;

namespace EcgViewPro
{
    public partial class SystemSetForm : Form
    {
        public SystemSetForm()
        {
            InitializeComponent();
        }

        private void xtraTabControlSystem_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            switch (xtraTabControlSystem.SelectedTabPageIndex)
            { 
                case 0://医院信息
                    xtraTabPageHospital.Controls.Clear();
                    var hf = new HosptialForm {TopLevel = false, FormBorderStyle = FormBorderStyle.None};
                    xtraTabPageHospital.Controls.Add(hf);
                    hf.Dock = DockStyle.Fill;
                    hf.Show();
                    break;
                case 1://修改密码
                    xtraTabPagePasswordSet.Controls.Clear();
                    var sform = new SystemForm {TopLevel = false, FormBorderStyle = FormBorderStyle.None};
                    xtraTabPagePasswordSet.Controls.Add(sform);
                    sform.Dock = DockStyle.Fill;
                    sform.Show();
                    break;
                case 2://节律导联
                    xtraTabPageLeadSet.Controls.Clear();
                    var lsf = new LeadSetForm {TopLevel =false,FormBorderStyle=FormBorderStyle.None};
                    xtraTabPageLeadSet.Controls.Add(lsf);
                    lsf.Dock = DockStyle.Fill;
                    lsf.Show();
                    break;
                case 3://显示颜色
                    xtraTabPageColorSet.Controls.Clear();
                    var dcf = new DisplayColorForm{TopLevel =false,FormBorderStyle=FormBorderStyle.None};
                    xtraTabPageColorSet.Controls.Add(dcf);
                    dcf.Dock = DockStyle.Fill;
                    dcf.Show();
                    break;
                case 4://远程服务
                    xtraTabPageRemoteService.Controls.Clear();
                    var rsf = new RemoteServiceForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
                    xtraTabPageRemoteService.Controls.Add(rsf);
                    rsf.Dock = DockStyle.Fill;
                    rsf.Show();
                    break;
                case 5://关于我们
                     xtraTabPageAboutUs.Controls.Clear();
                    var au = new AboutUs{ TopLevel = false, FormBorderStyle = FormBorderStyle.None };
                    xtraTabPageAboutUs.Controls.Add(au);
                    au.Dock = DockStyle.Fill;
                    au.Show();
                    break;
            }

        }

        private void SystemSetForm_Load(object sender, System.EventArgs e)
        {
            xtraTabPageHospital.Controls.Clear();
            var hf = new HosptialForm { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
            xtraTabPageHospital.Controls.Add(hf);
            hf.Dock = DockStyle.Fill;
            hf.Show();
        }
    }
}
