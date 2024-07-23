using FastReport.DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorERP.User_Controls
{
    public partial class UCLandsCars : UserControl
    {
        public UCLandsCars()
        {
            InitializeComponent();
        }

        #region Binding
        private void InitBinding()
        {
            tbLand.Fill();
            BindingSource bs = new BindingSource(tbLand.lstData, string.Empty);
            GridViewLands.DataSource = bs;
            //radBindingNavigator1.BindingSource = bs;
            //bs.PositionChanged += new EventHandler(bs_PositionChanged);
            //FillForm();
            //bs.MoveLast();

            //if (!guid.Equals(Guid.Empty))
            //{
            //    bs.Position = tbLand.lstData.FindIndex(delegate (tbLand land) { return land.guid == guid; });
            //}
        }
        #endregion

        private void UCLandsCars_Load(object sender, EventArgs e)
        {
            InitBinding();
        }

    }
}
