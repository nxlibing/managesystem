using DotNet.Business.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNet.Web.Admin.UserControls
{
    public partial class ModuleList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 因为是动态创建所以每次页面请求都要执行
        /// </summary>
        /// <param name="list"></param>
        public void ControlInit(IList<Base_Module> list)
        {
            CreateModule(list);
        }

        #region ControlsInit
        private void CreateModule(IList<Base_Module> list)
        {
            var a = from p in list where string.IsNullOrEmpty(p.Pguid) select p;
            IList<Base_Module> rootlist = a.ToList<Base_Module>();
            foreach (var item in rootlist)
            {
                TableRow row = new TableRow();

                TableCell cell = new TableCell();
              //  cell.Style.Add("padding-top", "10px");

                CheckBox chb = new CheckBox();
                chb.Text = item.Title;
                chb.Font.Bold = true;
                chb.InputAttributes.Add("onclick", "javascript:checkThisBox(this)");
                chb.InputAttributes.Add("fguid", item.Fguid);
                chb.InputAttributes.Add("pguid", "0");
                cell.Controls.Add(chb);
                row.Cells.Add(cell);
                TableList.Rows.Add(row);
                CteateRecursionModule(item.Fguid, list);
            }
        }

        private void CteateRecursionModule(string fguid, IList<Base_Module> list)
        {
            IList<Base_Module> sublist = GetSubList(fguid, list);
            TableRow row = new TableRow();
            foreach (var item in sublist)
            {
                int nodenolen = item.Moduleno.Length;
                int len = nodenolen * 5;

                TableCell cell = new TableCell();
                cell.Style.Add("padding-left", len + "px");
                CheckBox chb = new CheckBox();
                chb.InputAttributes.Add("onclick", "javascript:checkThisBox(this)");
                chb.InputAttributes.Add("fguid", item.Fguid);
                chb.InputAttributes.Add("pguid", fguid);
                chb.Text = item.Title;

                cell.Controls.Add(chb);

                IList<Base_Module> sublist2 = GetSubList(item.Fguid, list);
                if (sublist2.Count > 0)
                {
                    TableRow r = new TableRow();
                    r.Cells.Add(cell);
                    TableList.Rows.Add(r);
                }
                else
                {
                    row.Cells.Add(cell);
                    TableList.Rows.Add(row);
                }
                CteateRecursionModule(item.Fguid, list);
            }
        }

        private IList<Base_Module> GetSubList(string fguid, IList<Base_Module> list)
        {
            var a = from p in list where p.Pguid == fguid select p;
            IList<Base_Module> sublist = a.ToList<Base_Module>();
            return sublist;
        }
        #endregion

        public List<string> CheckedValues
        {
            get
            {
                List<string> list = new List<string>();
                foreach (TableRow row in TableList.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        CheckBox chb = cell.Controls[0] as CheckBox;
                        if (null != chb && chb.Checked)
                        {
                            list.Add(chb.InputAttributes["fguid"]);
                        }
                    }
                }
                return list;
            }
            set
            {
                foreach (TableRow row in TableList.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        CheckBox chb = cell.Controls[0] as CheckBox;
                        if (null != chb)
                        {
                            string fguid = chb.InputAttributes["fguid"];
                            if (value.Contains(fguid))
                            {
                                chb.Checked = true;
                            }
                            else
                            {
                                chb.Checked = false;
                            }
                        }
                    }
                }
            }
        }
    }
}