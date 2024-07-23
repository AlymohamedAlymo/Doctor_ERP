using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Diagnostics;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using static System.Runtime.CompilerServices.RuntimeHelpers;


namespace DoctorERP
{
    public partial class FrmPriceLog : KryptonForm
    {
        Guid guid;
        Guid parentguid;
        decimal oldprice;
        decimal newprice;

        public FrmPriceLog(Guid guid, Guid parentguid, decimal oldprice , decimal newprice)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            FillCmb();


            this.guid = guid;
            this.parentguid = parentguid;
            this.oldprice = oldprice;
            this.newprice = newprice;

            TxtNewPrice.Text = newprice.ToString(DataGUIAttribute.CurrencyFormat);
            TxtOldPrice.Text = oldprice.ToString(DataGUIAttribute.CurrencyFormat);
            Txtactno.Text = (tbPriceLog.GetMaxNumber("actno") + 1).ToString();
        }

        private void FrmTable_Load(object sender, EventArgs e)
        {
            InitBinding();

            if (!guid.Equals(Guid.Empty))
            {
                tbPriceLog log = tbPriceLog.FindBy("Guid", guid);

                Txtusername.Text = log.username;
                Txtactno.Text = log.actno.ToString();
                dtactdate.Value = log.actdate;
                dtchangedate.Value = log.changedate;
                TxtOldPrice.Text = log.oldprice.ToString(DataGUIAttribute.CurrencyFormat);
                TxtNewPrice.Text = log.newprice.ToString(DataGUIAttribute.CurrencyFormat);
            }
            else
            {
                Txtusername.Text = FrmMain.currentuser.name;
                Txtactno.Text = string.Empty;
                dtactdate.Value = DateTime.Now.Date;
                dtchangedate.Value = DateTime.Now.Date;
                TxtNewPrice.Text = newprice.ToString(DataGUIAttribute.CurrencyFormat);
                TxtOldPrice.Text = oldprice.ToString(DataGUIAttribute.CurrencyFormat);
                Txtactno.Text = (tbPriceLog.GetMaxNumber("actno") + 1).ToString();

            }
        }


        #region Binding
        private void InitBinding()
        {
            tbPriceLog.Fill();

            FillForm();

        }

        private void bs_PositionChanged(object sender, EventArgs e)
        {
            FillForm();
        }

        private void FillForm()
        {








        }

        private void NewFill()
        {
            DataGUIAttribute.AssignFormValues<tbPriceLog>(this, new tbPriceLog());
            DataGUIAttribute.ClearFormControls<tbPriceLog>(this, new tbPriceLog());


            FillCmb();
        }
        #endregion

        #region Buttons
        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewFill();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            tbPriceLog pricelog = new tbPriceLog();

            DataGUIAttribute.AssignObjectValues<tbPriceLog>(this, pricelog);
            int actno;
            int.TryParse(Txtactno.Text, out actno);
            if (actno <= 0)
            {
                if (Txtactno.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("رقم المحضر غير مدخل", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
               
            }

            if (MessageBox.Show("هل أنت متأكد من الحفظ ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;


            if (guid.Equals(Guid.Empty))
                pricelog.guid = Guid.NewGuid();
            else
                pricelog.guid = guid;

            pricelog.username = Txtusername.Text;
            pricelog.actdate = dtactdate.Value.Date;


            pricelog.actno = actno;
            pricelog.changedate = dtchangedate.Value.Date;
            pricelog.parentguid = parentguid;
            pricelog.oldprice = oldprice;
            pricelog.newprice = newprice;

            DBConnect.StartTransAction();


            pricelog.Delete();
            pricelog.Insert();

            if (DBConnect.CommitTransAction())
            {

                ShowConfirm();
                this.DialogResult = DialogResult.OK;

            }
        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        private void ShowConfirm()
        {
            FrmConfirm frmconfirm = new FrmConfirm();
            frmconfirm.ShowDialog();
        }

        void FillCmb()
        {
            //CmbType.Items.Clear();
            //CmbType.Items.AddRange(tbSMSSettings.GetUniqueList("Type").ToArray());
            //CmbType.Text = string.Empty;
        }

        private void LblHint_Click(object sender, EventArgs e)
        {

        }

        private void Txtactno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsPunctuation(e.KeyChar))
                e.Handled = true;
        }
    }
}
