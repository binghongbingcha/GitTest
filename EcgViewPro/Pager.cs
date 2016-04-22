using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace EcgViewPro
{
    public delegate int EventPagingHandler(EventPagingArg e);

    public partial class Pager : UserControl
    {
        public Pager()
        {
            InitializeComponent();
        }

        public event EventPagingHandler EventPaging;

        //每页显示数据
        private int _pageSize = 100;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
                GetPageCount();
            }
        }

        //总记录
        private int _totalRows;
        public int TotalRows
        {
            get
            {
                return _totalRows;
            }
            set
            {
                _totalRows = value;
                GetPageCount();
            }
        }

        //总页数
        private int _pageCount;
        public int PageCount
        {
            get
            {
                return _pageCount;
            }
            set
            {
                _pageCount = value;
            }
        }

        //当前页数
        private int _pageIndex = 1;
        public int PageIndex
        {
            get
            {
                return _pageIndex;
            }
            set
            {
                _pageIndex = value;
            }
        }

        public BindingNavigator ToolBar
        {
            get
            {
                return bindingNavigator;
            }
        }

        //给总页数赋值
        private void GetPageCount()
        {
            if (TotalRows > 0)
            {
                PageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(TotalRows) / Convert.ToDouble(PageSize)));
            }
            else
            {
                PageCount = 0;
            }
        }

        //绑定
        public void Bind()
        {
            
            //委托被触发
            if (EventPaging != null)
            {
                TotalRows = EventPaging(new EventPagingArg(PageIndex));
            }
            //当前页大于总页数
            if (PageIndex > PageCount)
            {
                PageIndex = PageCount;
            }
            //总共只有一页
            if (PageCount == 1 || PageCount == 0)
            {
                PageIndex = 1;
            }
            //文本框中的值（当前页）
            TxtPosition.Text = PageIndex.ToString();
            TxtPosition.Enabled = true;
            //标签值（总页数）
            if (_pageCount == 0)
            {
                LbltorCount.Text = @"/ " + (PageCount + 1) + "";
                LbltorCount.Enabled = true;
            }
            else
            {
                LbltorCount.Text = @"/ " + PageCount + "";
                LbltorCount.Enabled = true;
            }

            count.Text = @"总记录：" + TotalRows + @"条";

            //当前页为第一页
            if (PageIndex == 1)
            {
                btnPrevious.Enabled = false;
                btnFirst.Enabled = false;
            }
            else
            {
                btnPrevious.Enabled = true;
                btnFirst.Enabled = true;
            }

            //当前页为最后一页
            if (PageIndex == PageCount)
            {
                btnLast.Enabled = false;
                btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            //没有数据
            if (TotalRows == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPrevious.Enabled = false;
                GO.Enabled = false;
            }
            else
            {
                GO.Enabled = true;
            }

        }

        //首页
        private void btnFirst_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            Bind();
        }
        //尾页
        private void btnLast_Click(object sender, EventArgs e)
        {
            PageIndex = PageCount;
            Bind();
        }
        //上一页
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            PageIndex -= 1;
            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }
            Bind();
        }
        //下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            PageIndex += 1;
            if (PageIndex > PageCount)
            {
                PageIndex = PageCount;
            }
            Bind();
        }

        //跳转
        private void GO_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPosition.Text.Trim()))
            {
                if (int.TryParse(TxtPosition.Text.Trim(), out _pageIndex))
                {
                    if (Convert.ToInt32(TxtPosition.Text.Trim()) < 1)
                    {
                        PageIndex = 1;
                    }
                    else if (Convert.ToInt32(TxtPosition.Text.Trim()) > PageCount)
                    {
                        PageIndex = PageCount;
                    }
                    Bind();
                }
                else
                {
                    XtraMessageBox.Show(@"请输入数字！", @"提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    TxtPosition.Text = string.Empty;
                }
            }
        }

        private void bindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void LbltorCount_Click(object sender, EventArgs e)
        {

        }
    }


    //自定义事件数据基类
    public class EventPagingArg : EventArgs
    {
        private int _intPageIndex;
        public EventPagingArg(int pageIndex)
        {
            _intPageIndex = pageIndex;
        }
    }

}
