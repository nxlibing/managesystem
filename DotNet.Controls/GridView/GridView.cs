using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Data;
using DotNet.Common;

namespace DotNet.Controls.GridView
{/// <summary>
    /// 继承自GridView
    /// </summary>
    [ToolboxData(@"<{0}:GridView runat=server></{0}:GridView>")]
    public class GridView : System.Web.UI.WebControls.GridView
    {
        #region Attribute
        private Paging.PagingStyleCollection _pagingStyle;
        /// <summary>
        /// 自定义分页样式
        /// </summary>
        [Description("自定义分页样式"), DefaultValue(""), Category("扩展")]
        public Paging.PagingStyleCollection PagingStyle
        {
            get { return _pagingStyle; }
            set { _pagingStyle = value; }
        }

        private string _cssClassMouseOver;
        /// <summary>
        /// 鼠标经过的样式 CSS 类名
        /// </summary>
        [Browsable(true)]
        [Description("鼠标经过的样式 CSS 类名")]
        [DefaultValue("")]
        [Category("扩展")]
        public virtual string CssClassMouseOver
        {
            get { return _cssClassMouseOver; }
            set { _cssClassMouseOver = value; }
        }

        private bool _showCheckbox;
        /// <summary>
        /// 是否显示checkbox
        /// </summary>
        [Browsable(true)]
        [Description("是否显示checkbox")]
        [DefaultValue(false)]
        [Category("扩展")]
        public virtual bool ShowCheckbox
        {
            get { return _showCheckbox; }
            set { _showCheckbox = value; }
        }

        public enum CheckcolumnAlign
        {
            Left, Right
        }



        private CheckcolumnAlign _checkColumnAlign;
        /// <summary>
        /// checkbox列的位置
        /// </summary>
        [Description("checkbox列的位置")]
        [Category("扩展")]
        [DefaultValue(CheckcolumnAlign.Left)]
        public virtual CheckcolumnAlign CheckColumnAlign
        {
            get
            {
                return _checkColumnAlign;
            }
            set
            {
                _checkColumnAlign = value;
            }
        }

        /// <summary>
        /// gridview的总列数
        /// </summary>
        private int ColumnCount
        {
            get
            {
                int count = 0;
                if (ShowCheckbox)
                {
                    count = this.Columns.Count + 2;
                }
                else
                {
                    count = this.Columns.Count;
                }
                foreach (var item in this.Columns)
                {
                    dynamic col = item as dynamic;
                    if (col.HeaderStyle.CssClass == "hidden")
                    {
                        count--;
                    }
                }
                return count;
            }
        }
        #endregion


        #region 鼠标划过行变色
        /// <summary>
        /// OnRowDataBound
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowDataBound(GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // _cssClassMouseOver不是空则执行
                if (!string.IsNullOrEmpty(this._cssClassMouseOver))
                {
                    // 在<tr>上onmouseover时<tr>的样式（css类名）
                    e.Row.Attributes.Add("onmouseover", "this.className = '" + this._cssClassMouseOver + "'");

                    // 样式的名称（css类名）
                    string cssClassMouseOut = "";

                    // 根据RowState的不同，onmouseout时<tr>的不同样式（css类名）
                    switch (e.Row.RowState)
                    {
                        case DataControlRowState.Alternate:
                            cssClassMouseOut = base.AlternatingRowStyle.CssClass;
                            break;
                        case DataControlRowState.Edit:
                            cssClassMouseOut = base.EditRowStyle.CssClass;
                            break;
                        case DataControlRowState.Normal:
                            cssClassMouseOut = base.RowStyle.CssClass;
                            break;
                        case DataControlRowState.Selected:
                            cssClassMouseOut = base.SelectedRowStyle.CssClass;
                            break;
                        default:
                            cssClassMouseOut = "";
                            break;
                    }

                    // 增加<tr>的dhtml事件onmouseout
                    e.Row.Attributes.Add("onmouseout", "this.className = '" + cssClassMouseOut + "'");
                }
            }

            base.OnRowDataBound(e);
        }
        #endregion

        #region 分页

        /// <summary>
        /// OnLoad
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // 查找ObjectDataSource
            ObjectDataSource ods = Parent.FindControl(this.DataSourceID) as ObjectDataSource;
            if (ods != null)
            {
                ods.Selected += new ObjectDataSourceStatusEventHandler(ods_Selected);
            }

            LiteralControl include = new LiteralControl(getHeaderInfo());
            List<string> list = new List<string>();
            foreach (var item in Page.Header.Controls)
            {
                LiteralControl ctr = item as LiteralControl;
                if (ctr != null)
                {
                    list.Add(ctr.Text);
                }
            }
            if (!list.Contains(include.Text))
            {
                Page.Header.Controls.AddAt(0, include);
            }
            base.OnLoad(e);
        }

        private int? _recordCount = null;
        /// <summary>
        /// 计算总记录数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ods_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {
            if (e.ReturnValue.GetType() == typeof(Int32))
            {
                _recordCount = (int)e.ReturnValue;
            }
        }

        private string getHeaderInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<link href=\"" + AppInfo.Domain + "Style/Css/gridview.css\" rel=\"stylesheet\" type=\"text/css\" />\n");
            sb.Append("<script type=\"text/javascript\" src=\"" + AppInfo.Domain + "Style/Js/gridview.js\"></script>\n");
            return sb.ToString();
        }

        private void CreatePaging(GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager && PagingStyle == Paging.PagingStyleCollection.Default)
            {
                LinkButton First = new LinkButton();
                LinkButton Prev = new LinkButton();
                LinkButton Next = new LinkButton();
                LinkButton Last = new LinkButton();

                TableCell cell = new TableCell();

                e.Row.Cells.Clear();

                cell.Controls.Add(new LiteralControl("<div id='DotNetpageinfo'><span>&nbsp;&nbsp;&nbsp;&nbsp;"));
                if (_recordCount.HasValue)
                {
                    cell.Controls.Add(new LiteralControl("共有&nbsp;"));
                    cell.Controls.Add(new LiteralControl(_recordCount.ToString()));
                    cell.Controls.Add(new LiteralControl("&nbsp;条数据"));
                    //  cell.Controls.Add(new LiteralControl(PageSize.ToString()));
                    cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                }
                cell.Controls.Add(new LiteralControl((PageIndex + 1).ToString()));
                cell.Controls.Add(new LiteralControl("&nbsp;/&nbsp;"));
                cell.Controls.Add(new LiteralControl(PageCount.ToString()));
                cell.Controls.Add(new LiteralControl("&nbsp;页&nbsp;&nbsp;&nbsp;"));

                if (!String.IsNullOrEmpty(PagerSettings.FirstPageImageUrl))
                {
                    First.Text = "<img src='" + ResolveUrl(PagerSettings.FirstPageImageUrl) + "' border='0'/>";
                }
                else
                {
                    First.Text = PagerSettings.FirstPageText;
                }
                First.CommandName = "Page";
                First.CommandArgument = "First";
                First.Font.Underline = false;

                if (!String.IsNullOrEmpty(PagerSettings.PreviousPageImageUrl))
                {
                    Prev.Text = "<img src='" + ResolveUrl(PagerSettings.PreviousPageImageUrl) + "' border='0'/>";
                }
                else
                {
                    Prev.Text = PagerSettings.PreviousPageText;
                }
                Prev.CommandName = "Page";
                Prev.CommandArgument = "Prev";
                Prev.Font.Underline = false;


                if (!String.IsNullOrEmpty(PagerSettings.NextPageImageUrl))
                {
                    Next.Text = "<img src='" + ResolveUrl(PagerSettings.NextPageImageUrl) + "' border='0'/>";
                }
                else
                {
                    Next.Text = PagerSettings.NextPageText;
                }
                Next.CommandName = "Page";
                Next.CommandArgument = "Next";
                Next.Font.Underline = false;

                if (!String.IsNullOrEmpty(PagerSettings.LastPageImageUrl))
                {
                    Last.Text = "<img src='" + ResolveUrl(PagerSettings.LastPageImageUrl) + "' border='0'/>";
                }
                else
                {
                    Last.Text = PagerSettings.LastPageText;
                }
                Last.CommandName = "Page";
                Last.CommandArgument = "Last";
                Last.Font.Underline = false;

                if (this.PageIndex <= 0)
                {
                    First.Visible = Prev.Visible = false;
                }
                else
                {
                    First.Visible = Prev.Visible = true;
                }

                cell.Controls.Add(new LiteralControl("</span></div><div id='DotNetpaging'>"));

                cell.Controls.Add(First);
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                cell.Controls.Add(Prev);
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));

                // 当前页左边显示的数字分页按钮的数量
                int rightCount = (int)(PagerSettings.PageButtonCount / 2);
                // 当前页右边显示的数字分页按钮的数量
                int leftCount = PagerSettings.PageButtonCount % 2 == 0 ? rightCount - 1 : rightCount;
                for (int i = 0; i < PageCount; i++)
                {
                    if (PageCount > PagerSettings.PageButtonCount)
                    {
                        if (i < PageIndex - leftCount && PageCount - 1 - i > PagerSettings.PageButtonCount - 1)
                        {
                            continue;
                        }
                        else if (i > PageIndex + rightCount && i > PagerSettings.PageButtonCount - 1)
                        {
                            continue;
                        }
                    }

                    if (i == PageIndex)
                    {
                        cell.Controls.Add(new LiteralControl("<span>" + (i + 1).ToString() + "</span>"));
                    }
                    else
                    {
                        LinkButton DotNet = new LinkButton();
                        DotNet.Text = (i + 1).ToString();
                        DotNet.CommandName = "Page";
                        DotNet.CssClass = "link";
                        DotNet.CommandArgument = (i + 1).ToString();

                        cell.Controls.Add(DotNet);
                    }

                    cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                }

                if (this.PageIndex >= PageCount - 1)
                {
                    Next.Visible = Last.Visible = false;
                }
                else
                {
                    Next.Visible = Last.Visible = true;
                }
                cell.Controls.Add(Next);
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                cell.Controls.Add(Last);
                cell.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));
                cell.Controls.Add(new LiteralControl("</div>"));

                e.Row.Cells.Add(cell);
                // e.Row.Cells.Add(new TableCell());
                // e.Row.Cells[0].ColumnSpan = 4;
                // e.Row.Cells[0].Text = e.Row.Cells[0].ColumnSpan.ToString();
            }
        }
        #endregion

        #region 创建CHECKBOX列
        private void CreateCheckBoxColumn(GridViewRowEventArgs e)
        {
            if (ShowCheckbox)
            {
                GridViewRow row = e.Row;
                if (row.RowType == DataControlRowType.Header)
                {
                    // TableHeaderCell
                    TableHeaderCell cell = new TableHeaderCell();
                    //  cell.Wrap = Wrap;
                    cell.Width = Unit.Pixel(35);
                    cell.Style.Add("padding", "0");
                    cell.Text = "选择";
                    cell.Style.Add("text-align", "center");
                    if (CheckColumnAlign == CheckcolumnAlign.Left)
                    {
                        row.Cells.AddAt(0, cell);
                    }
                    else
                    {
                        int index = row.Cells.Count;
                        row.Cells.AddAt(index, cell);
                    }
                }
                else if (row.RowType == DataControlRowType.DataRow)
                {
                    TableCell cell = new TableCell();
                    //   cell.Wrap = Wrap;
                    CheckBox cb = new CheckBox();
                    cell.Width = Unit.Pixel(35);
                    cb.ID = "chkId";
                    cb.CssClass = "checkall";
                    cb.Checked = false;
                    cell.Style.Add("padding", "0");
                    cell.Style.Add("text-align", "center");

                    cell.Controls.Add(cb);
                    if (CheckColumnAlign == CheckcolumnAlign.Left)
                    {
                        row.Cells.AddAt(0, cell);
                    }
                    else
                    {
                        int index = row.Cells.Count;
                        row.Cells.AddAt(index, cell);
                    }
                }
            }
        }
        #endregion

        #region 空记录显示表头及提示
        //当Gridview数据为空时显示的信息
        private static string EmptyText = "暂无记录";

        public void GridViewEmptyBind()
        {
            DataTable table = new DataTable();
            foreach (var column in this.Columns)
            {
                var field = column as BoundField;
                if (field != null)
                {
                    DataColumn dColumn = new DataColumn(field.DataField);
                    table.Columns.Add(dColumn);
                }
            }
            foreach (var item in this.DataKeyNames)
            {
                if (!table.Columns.Contains(item))
                {
                    DataColumn dColumn = new DataColumn(item);
                    table.Columns.Add(dColumn);
                }
            }
            DataRow row = table.NewRow();
            foreach (DataColumn col in table.Columns)
            {
                row[col.ColumnName] = DBNull.Value;
            }
            table.Rows.Add(row);
            this.DataSourceID = null;
            this.DataSource = table;
            this.DataBind();
            if (this.Rows.Count > 0)
            {
                this.Rows[0].Cells.Clear();
                this.Rows[0].Cells.Add(new TableCell());
                this.Rows[0].Cells[0].ColumnSpan = ColumnCount;
                this.Rows[0].Cells[0].Text = EmptyText;
                this.Rows[0].Cells[0].Style.Add("text-align", "center");
            }
        }
        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            if (this.Rows.Count == 0)
            {
                GridViewEmptyBind();
            }
            base.OnPreRender(e);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            if (this.AllowPaging)
            {
                base.BottomPagerRow.Cells[0].ColumnSpan = ColumnCount;
            }

            base.RenderContents(writer);

        }

        /// <summary>
        /// OnRowCreated
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);
            CreateCheckBoxColumn(e);
            CreatePaging(e);
        }
    }
}
