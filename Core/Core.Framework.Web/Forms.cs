using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;

namespace Core.Framework.Web
{
    public static class Forms
    {
        /// <summary>
        /// Fill form from object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void LoadEntityOnPage<T>(T entity, Dictionary<string, Ext> ControlsExtension, System.Web.UI.ControlCollection controls)
        {
            if (ControlsExtension == null) return;

            foreach (KeyValuePair<string, Ext> c in ControlsExtension)
            {
                System.Web.UI.Control ctrl = FindControl(controls, c.Key);
                Ext ext = c.Value;
                PropertyInfo prop = entity.GetType().GetProperty(ext.PropertyName, BindingFlags.Public | BindingFlags.Instance);

                if (prop.GetValue(entity, null) == null)
                    continue;


                if (ctrl is TextBox)
                    if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                        ((TextBox)ctrl).Text = Common.ToString(prop.GetValue(entity, null));
                    else
                        ((TextBox)ctrl).Text = Common.ToString(prop.GetValue(entity, null));
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).SelectedValue = prop.GetValue(entity, null).ToString();
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = bool.Parse(prop.GetValue(entity, null).ToString());
                else if (ctrl is Label)
                    ((Label)ctrl).Text = Common.ToString(prop.GetValue(entity, null));
                else if (ctrl is System.Web.UI.HtmlControls.HtmlInputCheckBox)
                    ((System.Web.UI.HtmlControls.HtmlInputCheckBox)ctrl).Checked = bool.Parse(prop.GetValue(entity, null).ToString());
            }
        }

        /// <summary>
        /// Fill the entity from the form
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        public static void FillEntityObject<T>(T entity, Dictionary<string, Ext> ControlsExtension, System.Web.UI.ControlCollection controls)
        {
            foreach (KeyValuePair<string, Ext> c in ControlsExtension)
            {
                System.Web.UI.Control ctrl = FindControl(controls, c.Key);
                Ext ext = c.Value;
                PropertyInfo prop = entity.GetType().GetProperty(ext.PropertyName, BindingFlags.Public | BindingFlags.Instance);

                if (prop == null)
                    throw new Exception("La propiedad seteada no existe: " + ext.PropertyName);

                if (ctrl is TextBox)
                {
                    if (prop.PropertyType == typeof(decimal))
                        prop.SetValue(entity, Common.ToDecimal(((TextBox)ctrl).Text), null);
                    else if  (prop.PropertyType == typeof(decimal?))
                    {
                        if (((TextBox)ctrl).Text.Trim() == "")
                            prop.SetValue(entity, null, null);
                        else
                            prop.SetValue(entity, Common.ToDecimal(((TextBox)ctrl).Text), null);
                    }
                    else if (prop.PropertyType == typeof(DateTime?))
                    {
                        if (Common.IsDateTime(((TextBox)ctrl).Text))
                            prop.SetValue(entity, Common.ToDateTime(((TextBox)ctrl).Text), null);
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                        prop.SetValue(entity, Common.ToDateTime(((TextBox)ctrl).Text), null);
                    else if (prop.PropertyType == typeof(Int16) || prop.PropertyType == typeof(Single) || prop.PropertyType == typeof(Int16?) || prop.PropertyType == typeof(Single?))
                        prop.SetValue(entity, Common.ToInteger16(((TextBox)ctrl).Text, 0), null);
                    else if (prop.PropertyType == typeof(int))
                        prop.SetValue(entity, Common.ToInteger(((TextBox)ctrl).Text, 0), null);
                    else if (prop.PropertyType == typeof(Int32))
                        prop.SetValue(entity, Int32.Parse(((TextBox)ctrl).Text), null);
                    else if (prop.PropertyType == typeof(int?))
                    {
                        if ( Common.IsInteger(((TextBox)ctrl).Text))
                            prop.SetValue(entity, Common.ToInteger(((TextBox)ctrl).Text), null);
                        else
                            prop.SetValue(entity, null, null);
                    }
                    else
                        prop.SetValue(entity, ((TextBox)ctrl).Text, null);
                }
                else if (ctrl is DropDownList)
                {
                    if (prop.PropertyType == typeof(System.Guid))
                        prop.SetValue(entity, System.Guid.Parse(((DropDownList)ctrl).SelectedValue), null);
                    else if (prop.PropertyType == typeof(int))
                        prop.SetValue(entity, Helper._DropDownList.GetIntValue(((DropDownList)ctrl).SelectedValue), null);
                    else if (prop.PropertyType == typeof(int?))
                    {
                        if (((DropDownList)ctrl).SelectedValue != "-1")
                            prop.SetValue(entity, Helper._DropDownList.GetIntValue(((DropDownList)ctrl).SelectedValue), null);
                    }
                    else
                        prop.SetValue(entity, ((DropDownList)ctrl).SelectedValue, null);
                        
                }
                else if (ctrl is CheckBox)
                {
                    prop.SetValue(entity, ((CheckBox)ctrl).Checked, null);
                }
                else if (ctrl is Label)
                {

                    string value = ((Label)ctrl).Text;

                    if (prop.PropertyType == typeof(decimal))
                        prop.SetValue(entity, Common.ToDecimal(value), null);
                    else if (prop.PropertyType == typeof(decimal?))
                    {
                        if (value.Trim() == "")
                            prop.SetValue(entity, null, null);
                        else
                            prop.SetValue(entity, Common.ToDecimal(value), null);
                    }
                    else if (prop.PropertyType == typeof(DateTime?))
                    {
                        if (Common.IsDateTime(value))
                            prop.SetValue(entity, Common.ToDateTime(value), null);
                    }
                    else if (prop.PropertyType == typeof(DateTime))
                        prop.SetValue(entity, Common.ToDateTime(value), null);
                    else if (prop.PropertyType == typeof(Int16) || prop.PropertyType == typeof(Single) || prop.PropertyType == typeof(Int16?) || prop.PropertyType == typeof(Single?))
                        prop.SetValue(entity, Common.ToInteger16(value, 0), null);
                    else if (prop.PropertyType == typeof(int))
                        prop.SetValue(entity, Common.ToInteger(value, 0), null);
                    else if (prop.PropertyType == typeof(Int32))
                        prop.SetValue(entity, Int32.Parse(value), null);
                    else if (prop.PropertyType == typeof(int?))
                    {
                        if (Common.IsInteger(value))
                            prop.SetValue(entity, Common.ToInteger(value), null);
                        else
                            prop.SetValue(entity, null, null);
                    }
                    else
                        prop.SetValue(entity, value, null);
                }
                else if (ctrl is System.Web.UI.HtmlControls.HtmlInputCheckBox)
                {
                    prop.SetValue(entity, ((System.Web.UI.HtmlControls.HtmlInputCheckBox)ctrl).Checked, null);
                }
                else if(ctrl is System.Web.UI.WebControls.FileUpload )
                {
                    FileUpload fu = (System.Web.UI.WebControls.FileUpload)ctrl;
                    if (fu.HasFile && fu.PostedFile.ContentLength > 0)
                    {
                        Stream str = fu.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(str);
                        Byte[] size = br.ReadBytes((int)str.Length);

                        //string fileName = fu.FileName;
                        //byte[] fileByte = fu.FileBytes;
                        //System.Data.Linq.Binary binaryObj = new System.Data.Linq.Binary(fileByte);          
                        prop.SetValue(entity, size, null);
                    }
                }

            }
        }

        /// <summary>
        /// Find control by Id from control collection
        /// </summary>
        /// <param name="col"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static System.Web.UI.Control FindControl(System.Web.UI.ControlCollection col, string Id)
        {
            foreach (System.Web.UI.Control c in col)
            {
                if (c.Controls.Count > 0)
                {
                    System.Web.UI.Control res = FindControl(c.Controls, Id);
                    if (res != null)
                        return res;
                }
                else if (c.ID == Id)
                    return c;
            }

            return null;
        }

        /// <summary>
        /// Validate form
        /// </summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public static bool Validate(Dictionary<string, Ext> ControlsExtension, System.Web.UI.ControlCollection controls, out string Message)
        {
            Message = string.Empty;

            if (ControlsExtension == null)
            {
                return true;
            } 

            string mandatory = string.Empty;
            string length = string.Empty;

            foreach (KeyValuePair<string, Ext> c in ControlsExtension)
            {
                System.Web.UI.Control ctrl = FindControl(controls, c.Key);
                Ext ext = c.Value;

                GenericControl gen = new GenericControl(ctrl);

                string value = string.Empty;
                value = gen.Text;

                if ((ext.IsMandatory && value == string.Empty) || (ext.IsMandatory && ctrl is DropDownList && value == "-1"))
                {
                    if (mandatory == string.Empty)
                        mandatory = "Debe completar los siguientes campos:\r\n";

                    mandatory += "- " + FormatProperty(ext.PropertyName) + "\r\n";
                    gen.CssClass += " input-error";
                }
                else if (ext.MaxLength > 0 && value.Length > 0 && ext.MaxLength < value.Length)
                {
                    if (length == string.Empty)
                        length = "Estos campos son muy largos:\r\n";

                    length += "- " + FormatProperty(ext.PropertyName) + "\r\n";
                    gen.CssClass += " has-error";
                }
            }

            Message += mandatory + length;

            return (Message == string.Empty);
        }

        private static string FormatProperty(string Input)
        {
            if (Input.StartsWith("ID"))
                return Input.Substring(2);
            else if (Input.EndsWith("Id"))
                return Input.Substring(0, Input.Length - 2);

            return Input;
        }

        /// <summary>
        /// Clear from
        /// </summary>
        public static void Clear(System.Web.UI.ControlCollection col)
        {
            foreach (System.Web.UI.Control c in col)
            {
                if (c.Controls.Count > 0)
                {
                    Clear(c.Controls);
                }
                else
                {
                    if (c is TextBox)
                        ((TextBox)c).Text = string.Empty;
                    else if (c is DropDownList)
                        ((DropDownList)c).SelectedIndex = -1;
                    else if (c is ListBox)
                        ((ListBox)c).ClearSelection();
                    //else if (c is UserControls.MessageControl)
                    //    ((UserControls.MessageControl)c).Visible = false;
                }
            }
        }

        /// <summary>
        /// Object to mapping entity/control and validations
        /// </summary>
        public class Ext
        {
            public string PropertyName { get; set; }
            public bool IsMandatory { get; set; }
            public int MaxLength { get; set; }

            public Ext() { }
            public Ext(string PropertyName)
            {
                this.PropertyName = PropertyName;
            }
        }

        public class GenericControl
        {
            private Control _control;

            public string Text
            {
                get
                {

                    string text = null;

                    if (_control is TextBox)
                        text = ((TextBox)_control).Text;
                    else if (_control is DropDownList)
                        text = ((DropDownList)_control).SelectedValue;

                    return text;

                }
                set
                {
                    if (_control is TextBox)
                        ((TextBox)_control).Text = value;
                    else if (_control is DropDownList)
                        ((DropDownList)_control).SelectedValue = value;
                }
            }
            //public string Value { get; set; }
            public string CssClass
            {
                get
                {
                    if (_control is WebControl)
                        return ((WebControl)_control).CssClass;
                    else
                        return null;
                }

                set
                {
                    if (_control is WebControl)
                        ((WebControl)_control).CssClass = value;
                }
            }

            public GenericControl(Control ctrl)
            {
                _control = ctrl;
            }
        }
    }
}
