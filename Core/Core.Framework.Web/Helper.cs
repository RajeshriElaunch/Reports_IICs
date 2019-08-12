using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Reflection;

namespace Core.Framework.Web
{
    public static class Helper
    {
        public static string BuildFooter(DataPager pager, int total)
        {
            string result = string.Empty;
            
            //int currentPage = (pager.StartRowIndex / pager.MaximumRows) + 1;
            result = string.Format("Mostrando {0} a {1} de {2} resultados",
                                            pager.StartRowIndex + 1, pager.MaximumRows, total);

            return result;
        }

        public static class _ListBox
        {
            public static void Set(ListBox lst, IEnumerable<ItemDTO> dataSource)
            {
                lst.Items.Clear();

                if (dataSource == null) return;

                foreach (ItemDTO o in dataSource)
                    lst.Items.Add(new ListItem(o.Text, o.Value));

                lst.DataBind();
                
                //lst.Enabled = true;
            }
        }

        public static class _DropDownList
        {
            public static int? GetIntValue(string value)
            {
                if (value == null || !Common.IsInteger(value)) return null;

                int iValue = Common.ToInteger(value);

                if (iValue == -1) return null;

                return iValue;
            }

            public static void Set(DropDownList ddl, IEnumerable<ItemDTO> dataSource, string Text)
            {
                ddl.Items.Clear();

                if (dataSource == null) return;

                foreach (ItemDTO o in dataSource)
                {
                    ListItem li = new ListItem(o.Text, o.Value);

                    if (!string.IsNullOrEmpty(o.Group))
                        li.Attributes.Add("optgroup", o.Group);

                    ddl.Items.Add(li);
                }

                //Busca algun default
                bool HasDefault = (dataSource.Where(x => x.IsDefault).Count() > 0);

                //if (!HasDefault)
                int items = ddl.Items.Count;

                ddl.DataBind();

                ddl.Enabled = true;

                ddl.Items.Insert(0, new ListItem(Text, "-1"));

                if (HasDefault)
                {
                    ddl.SelectedValue = dataSource.Where(x => x.IsDefault).First().Value;
                }
                else
                {
                    
                    //if (ddl.Items.Count > 3) return;

                    //if (items == 0)
                    //{
                    //    ddl.Items.Insert(0, new ListItem(Text, "-1"));
                    //    ddl.Enabled = false;
                    //}
                }
            }

            public static void Set(DropDownList ddl, IEnumerable<ItemDTO> dataSource, bool AddSelect, bool AddEmpty)
            {
                ddl.Items.Clear();

                if (dataSource == null) return;

                foreach (ItemDTO o in dataSource)
                {
                    ListItem li = new ListItem(o.Text, o.Value);

                    if (!string.IsNullOrEmpty(o.Group))
                        li.Attributes.Add("optgroup", o.Group);

                    if (!string.IsNullOrEmpty(o.CssClass))
                        li.Attributes.Add("class", o.CssClass);

                    if (!string.IsNullOrEmpty(o.Subtext))
                        li.Attributes.Add("data-subtext", o.Subtext);

                    ddl.Items.Add(li);
                }

                //Busca algun default
                bool HasDefault = (dataSource.Where(x => x.IsDefault).Count() > 0);

                if (AddSelect && !HasDefault)
                    ddl.Items.Insert(0, new ListItem("[ Seleccione ]", "-1"));

                if (AddEmpty)
                    ddl.Items.Insert(0, new ListItem());

                int items = ddl.Items.Count;

                ddl.DataBind();

                ddl.Enabled = true;

                if (HasDefault)
                {
                    ddl.SelectedValue = dataSource.Where(x => x.IsDefault).First().Value;
                }
                else
                {
                    if (ddl.Items.Count > 3) return;

                    if (ddl.Items.Count == 0)
                    {
                        ddl.Items.Add(new ListItem("[Vacio]", "-1"));
                        ddl.Enabled = false;
                    }
                    else if (items == 1)
                        ddl.SelectedIndex = ddl.Items.Count - 1;
                }
            }
            
            public static void Set(DropDownList ddl, IEnumerable<ItemDTO> dataSource, bool AddSelect, bool AddEmpty, bool AddAll)
            {
                Set(ddl, dataSource, AddSelect, AddEmpty);

                if (AddAll)
                {
                    int pos = 0;
                    if (AddEmpty) pos = 1;

                    ddl.Items.Insert(pos, new ListItem("[ Todos ]", "-1"));

                    if (AddEmpty) ddl.SelectedIndex = 0;
                }

            }

            /// <summary>
            /// Carga el dropdownlist y omite los id
            /// </summary>
            /// <param name="ddl"></param>
            /// <param name="dataSource"></param>
            /// <param name="toSkip"></param>
            /// <param name="AddSelect"></param>
            /// <param name="AddEmpty"></param>
            public static void SetSkiper(DropDownList ddl, IEnumerable<ItemDTO> dataSource, IEnumerable<int> toSkip, bool AddSelect, bool AddEmpty)
            {
                if (dataSource == null) return;

                if (toSkip != null)
                {
                    foreach (int skip in toSkip)
                    {
                        var aux = dataSource.Where(x => x.Value == skip.ToString()).SingleOrDefault();
                        if (aux != null)
                            dataSource = dataSource.Where(x => x.Value != aux.Value).ToList();
                    }
                }

                Set(ddl, dataSource, AddSelect, AddEmpty);
            }

            /// <summary>
            /// Carga el dropdownlist y omite los id
            /// </summary>
            /// <param name="ddl"></param>
            /// <param name="dataSource"></param>
            /// <param name="toSkip"></param>
            /// <param name="AddSelect"></param>
            /// <param name="AddEmpty"></param>
            public static void SetSkiper(DropDownList ddl, IEnumerable<ItemDTO> dataSource, IEnumerable<int> toSkip, string Text)
            {
                if (dataSource == null) return;

                if (toSkip != null)
                { 
                    foreach (int skip in toSkip)
                    {
                        var aux = dataSource.Where(x => x.Value == skip.ToString()).SingleOrDefault();
                        if (aux != null)
                            dataSource = dataSource.Where(x => x.Value != aux.Value).ToList();
                    }
                }

                Set(ddl, dataSource, Text);
            }

            /// <summary>
            /// Only one item
            /// </summary>
            /// <param name="ddl"></param>
            /// <param name="dataSource"></param>
            /// <param name="AddSelect"></param>
            /// <param name="AddEmpty"></param>
            public static void Set(DropDownList ddl, ItemDTO dataSource, bool AddSelect, bool AddEmpty)
            {
                ddl.Items.Clear();

                if (dataSource == null) return;

                ddl.Items.Add(new ListItem(dataSource.Text, dataSource.Value));

                if (AddSelect)
                    ddl.Items.Insert(0, new ListItem("[ Seleccione ]", "-1"));

                int items = ddl.Items.Count;

                if (AddEmpty)
                    ddl.Items.Insert(0, new ListItem());

                ddl.DataBind();
                ddl.Enabled = false;
            }
        }
    }
}