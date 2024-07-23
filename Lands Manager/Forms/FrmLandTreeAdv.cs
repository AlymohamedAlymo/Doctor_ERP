using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using DgvFilterPopup;
using System.Xml.Serialization;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SmartArabXLSX.Presentation;
using SmartArabXLSX.Drawing.Diagrams;
using DevExpress.XtraTreeList;

namespace DoctorERP
{
    public partial class FrmLandTreeAdv : KryptonForm
    {

        string ReportTitle = string.Empty;

        TreeNode ndAllDocs;
        public FrmLandTreeAdv(string ReportTitle)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.Text = ReportTitle;
            this.ReportTitle = ReportTitle;

            //  FillDoc(string.Empty);


            tbLand.Fill();
           
            trDocs.KeyFieldName = "blocknumber";
          trDocs.ParentFieldName = "blocknumber";
            trDocs.DataSource = tbLand.dtData;


        }

        private void FillDoc(string keyword)
        {

            trDocs.Nodes.Clear();

            ndAllDocs = new TreeNode("كافة الأصناف", 0, 1);
            ndAllDocs.Tag = 0;
            trDocs.Nodes.Add(ndAllDocs);

            foreach (var BlockNumber in tbLand.GetUniqueList("BlockNumber"))
            {
                TreeNode trArc = ndAllDocs.Nodes.Add(Guid.Empty.ToString(), "رقم البلوك " + BlockNumber, 0, 1);
                trArc.Tag = BlockNumber;

                tbLand.Fill("BlockNumber", (object)BlockNumber , keyword);
                int imgidx = 0;
                foreach (var item in tbLand.lstData)
                {
                   
                    if (item.status == "متاح")
                    {
                        imgidx = 2;
                    }
                    else if (item.status == "مباع")
                    {
                        imgidx = 3;
                    }
                    else if (item.status == "محجوز")
                    {
                        imgidx = 4;
                    }
                    TreeNode trItem = trArc.Nodes.Add(item.guid.ToString(), item.code.ToString(), imgidx, imgidx);
                    trItem.Tag = -1;
                }
            }


            if (keyword.Trim().Length > 0)
                trDocs.ExpandAll();
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {

        }

        private void trDocs_DoubleClick(object sender, EventArgs e)
        {


        }

        #region search Field
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SearchGrid(TxtSearch.Text);
            else if (e.KeyData == Keys.Delete)
            {
                TxtSearch.Text = string.Empty;
                SearchGrid(string.Empty);
            }
        }

        void SearchGrid(string SearchValue)
        {

            if (SearchValue.Trim().Length <= 0)
            {
                FillDoc(string.Empty);
                trDocs.ExpandAll();
                return;
            }

            FillDoc(SearchValue);

        }

        private void BtnClearSearch_Click(object sender, EventArgs e)
        {
            TxtSearch.Text = string.Empty;
            SearchGrid(string.Empty);
        }
        #endregion

        private void trDocs_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            //if (e.Button == MouseButtons.Right)
            //{
            //    int itemtag = int.Parse(e.Node.Tag.ToString());
            //    trDocs.SelectedNode = e.Node;
            //    if (itemtag > 0)
            //    {
            //        MenuOpenLandCard.Visible = false;
            //        MenuAddLandCard.Visible = true;
            //    }
            //    else if (itemtag < 0)
            //    {
            //        MenuOpenLandCard.Visible = true;

            //        MenuAddLandCard.Visible = false;


            //    }

            //    if (itemtag != 0)
            //    {

            //        MenuLand.Show(trDocs, e.Location);
            //    }

            //}
        }

        private void trDocs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    Guid guid;
            //    try
            //    {
            //        guid = new Guid(trDocs.SelectedNode.Name);
            //    }
            //    catch
            //    {
            //        guid = Guid.Empty;
            //    }

            //    if (!guid.Equals(Guid.Empty))
            //    {
            //        tbLand arch = tbLand.FindBy("Guid", guid);
            //        if (!arch.guid.Equals(Guid.Empty))
            //        {
            //            FrmLand frmarc = new FrmLand(arch.guid, false, string.Empty);
            //            frmarc.ShowDialog();
            //            return;
            //        }
            //    }
            //}
        }

        private void MenuOpenLandCard_Click(object sender, EventArgs e)
        {
            //Guid guid;
            //try
            //{
            //    guid = new Guid(trDocs.SelectedNode.Name);
            //}
            //catch
            //{
            //    guid = Guid.Empty;
            //}

            //FrmLand frmarc = new FrmLand(guid, false, string.Empty);
            //if (frmarc.ShowDialog() == DialogResult.OK)
            //{
            //    FillDoc(string.Empty);
            //}
        }

        private void MenuAddLandCard_Click(object sender, EventArgs e)
        {
            //string blockno =  trDocs.SelectedNode.Tag.ToString();
            //FrmLand frmarc = new FrmLand(Guid.Empty, true, blockno);
            //if (frmarc.ShowDialog() == DialogResult.OK)
            //{
            //    FillDoc(string.Empty);
            //}
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            TxtSearch.Text = string.Empty;
            FillDoc(string.Empty);
        }
    }
}
