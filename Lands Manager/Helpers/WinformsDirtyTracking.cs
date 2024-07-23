using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinformsDirtyTracking
{
    public class DirtyTracker
    {
        #region DirtyTracker
        private Form _frmTracked;
        private ControlDirtyTrackerCollection _controlsTracked;

        // property denoting whether the tracked form is clean or dirty;
        // used if the full list of dirty controls isn't necessary
        public bool IsDirty
        {
            get
            {
                List<Control> dirtyControls = _controlsTracked.GetListOfDirtyControls();

                return (dirtyControls.Count > 0);
            }
        }


        // public method for accessing the list of currently
        // "dirty" controls
        public List<Control> GetListOfDirtyControls()
        {
            return _controlsTracked.GetListOfDirtyControls();
        }


        // establish the form as "clean" with whatever current
        // control values exist
        public void MarkAsClean()
        {
            _controlsTracked.MarkAllControlsAsClean();
        }


        // initialize in the constructor by assigning controls to track
        public DirtyTracker(Form frm, params string[] ExcludeControls)
        {
            _frmTracked = frm;
            _controlsTracked = new ControlDirtyTrackerCollection(frm, ExcludeControls);
        }
        #endregion

        #region Controls 
        public class ControlDirtyTracker
        {
            private Control _control;
            private string _cleanValue;

            // read only properties
            public Control Control { get { return _control; } }
            public string CleanValue { get { return _cleanValue; } }

            // constructor establishes the control and uses its current value as "clean"
            public ControlDirtyTracker(Control ctl)
            {
                // if the control type is not one that is supported, throw an exception
                if (ControlDirtyTracker.IsControlTypeSupported(ctl))
                    _control = ctl;
                else
                    throw new NotSupportedException(
                        string.Format("The control type for '{0}' is not supported by the ControlDirtyTracker class."
                          , ctl.Name)
                        );

            }


            // method to establish the the current control value as "clean"
            public void EstablishValueAsClean()
            {
                _cleanValue = GetControlCurrentValue();
            }


            // determine if the current control value is considered "dirty"; 
            // i.e. if the current control value is different than the one
            // remembered as "clean"
            public bool DetermineIfDirty()
            {
                // compare the remembered "clean value" to the current value;
                // if they are the same, the control is still clean;
                // if they are different, the control is considered dirty.
                return (string.Compare(_cleanValue, GetControlCurrentValue(), false) != 0);
            }



            //////////////////////////////////////////////////////////////////////////////////////
            // developers may modify the following two methods to extend support for other types
            //////////////////////////////////////////////////////////////////////////////////////

            // static class utility method; return whether or not the control type 
            // of the given control is supported by this class;
            // developers may modify this to extend support for other types
            public static bool IsControlTypeSupported(Control ctl, params string[] ExcludeControls)
            {
                foreach (string strControlName in ExcludeControls)
                {
                    if (ctl.Name.ToLower().Equals(strControlName.ToLower()))
                        return false;
                }
                // list of types supported
                if (ctl is TextBox) return true;
                if (ctl is CheckBox) return true;
                if (ctl is ComboBox) return true;
                if (ctl is ListBox) return true;
                if (ctl is DateTimePicker) return true;
                if (ctl is NumericUpDown) return true;
                if (ctl is DataGridView) return true;

                // ... add additional types as desired ...                       

                // not a supported type
                return false;
            }


            // private method to determine the current value (as a string) of the control;
            // if the control is not supported, return a NotSupported exception
            // developers may modify this to extend support for other types
            private string GetControlCurrentValue()
            {
                if (_control is TextBox)
                    return (_control as TextBox).Text;

                if (_control is CheckBox)
                    return (_control as CheckBox).Checked.ToString();

                if (_control is ComboBox)
                    return (_control as ComboBox).Text;

                if (_control is ListBox)
                {
                    // for a listbox, create a list of the selected indexes
                    StringBuilder val = new StringBuilder();
                    ListBox lb = (_control as ListBox);
                    ListBox.SelectedIndexCollection coll = lb.SelectedIndices;
                    for (int i = 0; i < coll.Count; i++)
                        val.AppendFormat("{0};", coll[i]);

                    return val.ToString();
                }

                if (_control is DateTimePicker)
                    return (_control as DateTimePicker).Value.ToString();

                if (_control is NumericUpDown)
                    return (_control as NumericUpDown).Value.ToString();

                if (_control is DataGridView)
                    return DataGridViewCellsToString(_control as DataGridView);

                // ... add additional types as desired ...

                return "";
            }

            string DataGridViewCellsToString(DataGridView dgv)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewColumn dgvcol in dgv.Columns)
                {
                    foreach (DataGridViewRow dgvrow in dgv.Rows)
                    {
                        try
                        {
                            sb.Append(dgv[dgvcol.Index, dgvrow.Index].Value.ToString());
                        }
                        catch
                        {

                        }
                    }
                }
                return sb.ToString();
            }
        }
        #endregion

        #region ControlDirtyTrackerCollection 
        public class ControlDirtyTrackerCollection : List<ControlDirtyTracker>
        {

            // constructors
            public ControlDirtyTrackerCollection() : base() { }
            public ControlDirtyTrackerCollection(Form frm) : base()
            {
                // initialize to the controls on the passed in form
                AddControlsFromForm(frm);
            }

            public ControlDirtyTrackerCollection(Form frm, params string[] ExcludeControls) : base()
            {
                // initialize to the controls on the passed in form
                AddControlsFromForm(frm, ExcludeControls);
            }


            // utility method to add the controls from a Form to this collection
            public void AddControlsFromForm(Form frm, params string[] ExcludeControls)
            {
                AddControlsFromCollection(frm.Controls, ExcludeControls);
            }

            // recursive routine to inspect each control and add to the collection accordingly
            public void AddControlsFromCollection(Control.ControlCollection coll, params string[] ExcludeControls)
            {
                foreach (Control c in coll)
                {
                    // if the control is supported for dirty tracking, add it
                    if (ControlDirtyTracker.IsControlTypeSupported(c, ExcludeControls))
                        this.Add(new ControlDirtyTracker(c));

                    // recurively apply to inner collections
                    if (c.HasChildren)
                        AddControlsFromCollection(c.Controls);
                }
            }

            // loop through all controls and return a list of those that are dirty
            public List<Control> GetListOfDirtyControls()
            {
                List<Control> list = new List<Control>();

                foreach (ControlDirtyTracker c in this)
                {
                    if (c.DetermineIfDirty())
                        list.Add(c.Control);
                }

                return list;
            }


            // mark all the tracked controls as clean
            public void MarkAllControlsAsClean()
            {
                foreach (ControlDirtyTracker c in this)
                    c.EstablishValueAsClean();
            }

        }
        #endregion
    }
}
