using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

    public partial class FrmConfirm : KryptonForm
    {
        public FrmConfirm()
        {
            InitializeComponent();
        }

      
        private void TmrClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }

