using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EcgViewPro
{
    public partial class TestWebBrowser : Form
    {
        public TestWebBrowser()
        {
            InitializeComponent();
        }

        private void TestWebBrowser_Load(object sender, EventArgs e)
        {

        }
        public static void CreateJSElement(WebBrowser browser, string script)
        {
            //var tag = browser.Document.CreateElement("script");

            //var scriptElement = tag.DomElement as IHTMLScriptElement;

            //scriptElement.type = "text/javascript";//设定为Javascript
            //scriptElement.text = script;//设置内容

            //browser.Document.Body.AppendChild(tag);
        }

    }
}
