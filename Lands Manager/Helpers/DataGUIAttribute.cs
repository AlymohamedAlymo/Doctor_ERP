using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

public class DataGUIAttribute : Attribute
{
    public enum AttributeName
    {
        GUIName,
        Formating,
        Visibility,
        Width,
        ControlName
    }

    public string GUIName { get; set; }
    public string Formatting { get; set; }
    public bool Visibility { get; set; }
    public int Width { get; set; }
    public string ControlName { get; set; }

    public static string QtyFormat;
    public static string CurrencyFormat;

    public static object GetAttributeValue(Type ObjectType, string Prop, AttributeName attribname)
    {
        try
        {
            var attributeData = ObjectType.GetProperty(Prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).GetCustomAttributesData();
            return attributeData[0].NamedArguments[(int)attribname].TypedValue.Value;
        }
        catch
        {
            MessageBox.Show("Property Name Not Found : " + Prop, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return null;
        }
    }

    #region Binding Controls
    public static void AssignFormValues<T>(Form form, T obj)
    {
        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        {
            string controlname = DataGUIAttribute.GetAttributeValue(typeof(T), prop.Name, DataGUIAttribute.AttributeName.ControlName).ToString();
            dynamic value = prop.GetValue(obj, null);
            string formatting = DataGUIAttribute.GetAttributeValue(typeof(T), prop.Name, DataGUIAttribute.AttributeName.Formating).ToString();

            if (formatting == "N2")
                formatting = CurrencyFormat;
            else if (formatting == "N0")
                formatting = QtyFormat;

            SetControl(form, controlname, value, formatting);
        }
    }

    private static void SetControl(Form form, string controlname, dynamic value, string formatting)
    {
        if (controlname.Equals(string.Empty))
            return;

        Control[] control = form.Controls.Find(controlname, true);
        if (control == null && control.Length < 0)
            return;

        try
        {
            Control ctl = control[0];

            if (ctl.GetType().Equals(typeof(DateTimePicker)))
            {
                try
                {
                    ((DateTimePicker)ctl).Value = value;
                }
                catch
                {
                    ((DateTimePicker)ctl).Value = DateTime.Now;
                }
            }
            else if (ctl.GetType().Equals(typeof(KryptonCheckBox)))
                ((KryptonCheckBox)ctl).Checked = value;
            else
                ctl.Text = string.Format("{0:" + formatting + "}", value, formatting);
        }
        catch
        {
            MessageBox.Show("Control Name Not Found : " + controlname, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }


    public static void AssignObjectValues<T>(Form form, T obj)
    {
        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        {
            string controlname = DataGUIAttribute.GetAttributeValue(typeof(T), prop.Name, DataGUIAttribute.AttributeName.ControlName).ToString();
            dynamic value = GetControlValue(form, controlname);

            if (!controlname.Equals(string.Empty))
            {
                try
                {
                    prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), null);
                }
                catch
                {
                    if (prop.PropertyType.Equals(typeof(DateTime)))
                        prop.SetValue(obj, DateTime.Now, null);
                    else
                        prop.SetValue(obj, Activator.CreateInstance(prop.PropertyType), null);
                }
            }
        }
    }


    public static IEnumerable<Control> GetAll(Control control, Type type)
    {
        var controls = control.Controls.Cast<Control>();

        return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                  .Concat(controls)
                                  .Where(c => c.GetType() == type);
    }

    private static dynamic GetControlValue(Form form, string controlname)
    {
        if (controlname.Equals(string.Empty))
            return null;

        Control[] control = form.Controls.Find(controlname, true);
        if (control == null && control.Length < 0)
            return null;
        try
        {
            Control ctl = control[0];

            if (ctl.GetType().Equals(typeof(DateTimePicker)))
                return ((DateTimePicker)ctl).Value;
            else if (ctl.GetType().Equals(typeof(KryptonCheckBox)))
                return ((KryptonCheckBox)ctl).Checked;
            else
                return ctl.Text;
        }
        catch
        {
            MessageBox.Show("Control Name Not Found : " + controlname, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return null;
        }
    }

    public static void ClearFormControls<T>(Form form, T obj)
    {
        foreach (PropertyInfo prop in obj.GetType().GetProperties())
        {
            string controlname = DataGUIAttribute.GetAttributeValue(typeof(T), prop.Name, DataGUIAttribute.AttributeName.ControlName).ToString();
            ClearControls(form, controlname);
        }
    }

    private static void ClearControls(Form form, string controlname)
    {
        if (controlname.Equals(string.Empty))
            return;

        Control[] control = form.Controls.Find(controlname, true);
        if (control == null && control.Length < 0)
            return;

        Control ctl = control[0];

        if (ctl.GetType().Equals(typeof(DateTimePicker)))
            ((DateTimePicker)ctl).Value = DateTime.Now;
        else if (ctl.GetType().Equals(typeof(KryptonCheckBox)))
            ((KryptonCheckBox)ctl).Checked = false;
        else
            ctl.Text = string.Empty;
    }

    public static void FillGrid(DataGridView datagrid, Type type)
    {
        foreach (DataGridViewColumn dgvcol in datagrid.Columns)
        {
            string columnname = dgvcol.Name;
            dgvcol.DataPropertyName = columnname;
            dgvcol.Visible = (bool)DataGUIAttribute.GetAttributeValue(type, columnname, DataGUIAttribute.AttributeName.Visibility);

            string formatting = DataGUIAttribute.GetAttributeValue(type, columnname, DataGUIAttribute.AttributeName.Formating).ToString();
            if (formatting == "N2")
                formatting = CurrencyFormat;
            else if (formatting == "N0")
                formatting = QtyFormat;

            dgvcol.DefaultCellStyle.Format = formatting;
            dgvcol.HeaderText = DataGUIAttribute.GetAttributeValue(type, columnname, DataGUIAttribute.AttributeName.GUIName).ToString();
        }
    }
    #endregion
}
