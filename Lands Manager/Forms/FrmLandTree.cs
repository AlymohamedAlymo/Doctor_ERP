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

using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WinformsDirtyTracking;
using DevExpress.Utils.Design;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace DoctorERP
{
    public partial class FrmLandTree : KryptonForm
    {

        string ReportTitle = string.Empty;

        TreeNode ndAllDocs;
        public FrmLandTree(string ReportTitle)
        {
            InitializeComponent();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            this.Text = ReportTitle;
            this.ReportTitle = ReportTitle;

            FillDoc(string.Empty);


        }

        private void FillDoc(string keyword)
        {

            trDocs.Nodes.Clear();

            ndAllDocs = new TreeNode("كافة الأصناف", 0, 1);
            ndAllDocs.Tag = -2;
            trDocs.Nodes.Add(ndAllDocs);

            foreach (var BlockNumber in tbLand.GetUniqueList("BlockNumber"))
            {
                string blockname = string.Empty;
                if (BlockNumber.Equals(string.Empty))
                    blockname = "بدون رقم بلوك";
                else
                    blockname = "رقم البلوك " + BlockNumber;

                TreeNode trArc = ndAllDocs.Nodes.Add(Guid.Empty.ToString(), blockname, 0, 1);
                trArc.Tag = BlockNumber;

                tbLand.Fill("BlockNumber", (object)BlockNumber, keyword);
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
            if (e.Button == MouseButtons.Right)
            {
                int itemtag = int.Parse(e.Node.Tag.ToString());
                trDocs.SelectedNode = e.Node;
                if (itemtag >= 0)
                {
                    MenuOpenLandCard.Visible = false;
                    MenuAddLandCard.Visible = true;
                    MenuDeleteAllNonSolditems.Visible = true;
                    MenuDelete.Visible = false;
                    MenuMoveToBlock.Visible = false;
                }
                else if (itemtag < 0)
                {
                    MenuOpenLandCard.Visible = true;
                    MenuMoveToBlock.Visible = true;
                    MenuAddLandCard.Visible = false;
                    MenuDeleteAllNonSolditems.Visible = false;
                    MenuDelete.Visible = true;

                }

                if (itemtag != -2)
                {
                    MenuLand.Show(trDocs, e.Location);
                }

            }
        }

        private void trDocs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Guid guid;
                try
                {
                    guid = new Guid(trDocs.SelectedNode.Name);
                }
                catch
                {
                    guid = Guid.Empty;
                }

                if (!guid.Equals(Guid.Empty))
                {
                    tbLand arch = tbLand.FindBy("Guid", guid);
                    if (!arch.guid.Equals(Guid.Empty))
                    {
                        FrmLand frmarc = new FrmLand(arch.guid, false, string.Empty);
                        frmarc.ShowDialog();
                        return;
                    }
                }
            }
        }

        private void MenuOpenLandCard_Click(object sender, EventArgs e)
        {
            Guid guid;
            try
            {
                guid = new Guid(trDocs.SelectedNode.Name);
            }
            catch
            {
                guid = Guid.Empty;
            }

            FrmLand frmarc = new FrmLand(guid, false, string.Empty);
            if (frmarc.ShowDialog() == DialogResult.OK)
            {
                FillDoc(string.Empty);
            }
        }

        private void MenuAddLandCard_Click(object sender, EventArgs e)
        {
            string blockno = trDocs.SelectedNode.Tag.ToString();
            FrmLand frmarc = new FrmLand(Guid.Empty, true, blockno);
            if (frmarc.ShowDialog() == DialogResult.OK)
            {
                FillDoc(string.Empty);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            TxtSearch.Text = string.Empty;
            FillDoc(string.Empty);
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanDelete)
            {
                MessageBox.Show("ليس لديك صلاحية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Guid guid;
            try
            {
                guid = new Guid(trDocs.SelectedNode.Name);
            }
            catch
            {
                guid = Guid.Empty;
            }

            tbLand land = tbLand.FindBy("Guid", guid);
            if (tbBillBody.IsExist("LandGuid", land.guid))
            {
                MessageBox.Show("لا يمكن حذف الصنف لأنه مستخدم في العقود", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            if (tbSaleOrderBody.IsExist("LandGuid", land.guid))
            {
                MessageBox.Show("لا يمكن حذف الصنف لأنه مستخدم في أوامر البيع", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }


            else if (land.status == "محجوز")
            {
                MessageBox.Show("لا يمكن حذف الصنف لأنه محجوز، يجب إلغاء الحجز أولأ", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                tbAttachment attach = new tbAttachment();

                tbPriceLog pricelog = new tbPriceLog();

                if (MessageBox.Show("هل أنت متأكد من الحذف ؟", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                DBConnect.StartTransAction();


                attach.DeleteBy("ParentGuid", land.guid);
                land.Delete();
                pricelog.DeleteBy("ParentGuid", land.guid);

                if (DBConnect.CommitTransAction())
                {
                    FillDoc(string.Empty);
                }
            }

        }

        private void trDocs_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = trDocs.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = trDocs.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            //TreeNode draggedNode = e.Data.GetData(typeof(TreeNode));
            TreeNode draggedNode = trDocs.SelectedNode;

            // Sanity check
            if (draggedNode == null)
            {
                return;
            }

            int draggedNodetag = int.Parse(draggedNode.Tag.ToString());
            int targetNodetag = int.Parse(targetNode.Tag.ToString());

            if (draggedNodetag >= 0)
            {
                return;
            }

        

            if (targetNodetag < 0)
            {

                if (targetNode.Parent is null)
                {
                    return;
                }
                else
                {
                    targetNode = targetNode.Parent;
                }
            }

            if (draggedNode.ImageIndex == 3)
            {
                if (targetNode.Parent is null)
                {

                }
                else
                {
                    Guid g = new Guid(draggedNode.Name.ToString());
                    tbLand land = tbLand.FindBy("Guid", g);

                    if (MessageBox.Show(string.Format("الأرض رقم {0} مباعة، هل أنت متأكد من نقلها إلى بلوك آخر ؟", land.number.ToString()), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                }
            }


            // Did the user drop on a valid target node?
            if (targetNode == null)
            {
                // The user dropped the node on the treeview control instead
                // of another node so lets place the node at the bottom of the tree.
                draggedNode.Remove();
                trDocs.Nodes.Add(draggedNode);
                draggedNode.Expand();
            }
            else
            {
                TreeNode parentNode = targetNode;

                // Confirm that the node at the drop location is not 
                // the dragged node and that target node isn't null
                // (for example if you drag outside the control)
                if (!draggedNode.Equals(targetNode) && targetNode != null)
                {
                    bool canDrop = true;

                    // Crawl our way up from the node we dropped on to find out if
                    // if the target node is our parent. 
                    while (canDrop && (parentNode != null))
                    {
                        canDrop = !Object.ReferenceEquals(draggedNode, parentNode);
                        parentNode = parentNode.Parent;
                    }

                    // Is this a valid drop location?
                    if (canDrop)
                    {
                        // Yes. Move the node, expand it, and select it.
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                        targetNode.Expand();

                        Guid g = new Guid(draggedNode.Name.ToString());
                        tbLand land = tbLand.FindBy("Guid", g);
                        int newblock;
                        int.TryParse(draggedNode.Parent.Tag.ToString(), out newblock);
                        land.blocknumber = newblock;
                        DBConnect.StartTransAction();
                        land.Update();
                        DBConnect.CommitTransAction();
                    }
                }
            }

            // Optional: Select the dropped node and navigate (however you do it)
            trDocs.SelectedNode = draggedNode;
            // NavigateToContent(draggedNode.Tag);
        }

        private void trDocs_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void trDocs_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void trDocs_Click(object sender, EventArgs e)
        {
            TreeNode node = trDocs.SelectedNode;
        }

        private void trDocs_MouseDown(object sender, MouseEventArgs e)
        {
            if (trDocs.HitTest(e.Location).Node == null)
            {
                trDocs.SelectedNode = null;
            }
            else
            {
                trDocs.SelectedNode = trDocs.HitTest(e.Location).Node;
            }
        }

        private void MenuDeleteAllNonSolditems_Click(object sender, EventArgs e)
        {
            if (!FrmMain.currentuser.CanDelete)
            {
                MessageBox.Show("ليس لديك صلاحية", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            string bnumber = trDocs.SelectedNode.Tag.ToString();

            tbAttachment attach = new tbAttachment();

            tbPriceLog pricelog = new tbPriceLog();

            if (MessageBox.Show(string.Format("هل أنت متأكد من حذف كافة الأصناف الغير مباعة التابعة للبلوك رقم {0} ؟", bnumber), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            tbLand.FillByBlockNotState("blocknumber", bnumber, "مباع");

            DBConnect.StartTransAction();

            foreach (var item in tbLand.lstData)
            {
                attach.DeleteBy("ParentGuid", item.guid);
                item.Delete();
                pricelog.DeleteBy("ParentGuid", item.guid);

            }

            if (DBConnect.CommitTransAction())
            {
                FillDoc(string.Empty);
            }


        }

        private void MenuLand_Opening(object sender, CancelEventArgs e)
        {
            string CurrentBlock = trDocs.SelectedNode.Parent.Tag.ToString();

            MenuMoveToBlock.DropDownItems.Clear();
            List<string> lstBlocks = tbLand.GetUniqueList("BlockNumber");
            var sortlstBlocks = lstBlocks.OrderBy(q => q).ToList();
            for (int i = 0; i < sortlstBlocks.Count; i++)
            {
                ToolStripMenuItem ToolBlock = new ToolStripMenuItem();
                ToolBlock.Tag = sortlstBlocks[i];
                ToolBlock.Text = sortlstBlocks[i].ToString();
                ToolBlock.Click += ToolBlock_Click;

                if (CurrentBlock != ToolBlock.Tag.ToString())
                    MenuMoveToBlock.DropDownItems.Add(ToolBlock);
            }

        }

        private void ToolBlock_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ToolBlock = (ToolStripMenuItem)sender;

            TreeNode SelNode = trDocs.SelectedNode;

            Guid g = new Guid(SelNode.Name.ToString());
            tbLand land = tbLand.FindBy("Guid", g);

            if (land.status == "مباع")
                if (MessageBox.Show(string.Format("الأرض رقم {0} مباعة، هل أنت متأكد من نقلها إلى بلوك آخر ؟", land.number.ToString()), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;


            int newblock;
            int.TryParse(ToolBlock.Tag.ToString(), out newblock);
            land.blocknumber = newblock;
            DBConnect.StartTransAction();
            land.Update();
            if (DBConnect.CommitTransAction())
            { 
                foreach (TreeNode item in ndAllDocs.Nodes)
                {
                    int fblock;
                    int.TryParse(item.Tag.ToString(), out fblock);
                    if (fblock.Equals(newblock))
                    {
                        SelNode.Remove();
                        item.Nodes.Add(SelNode);
                      
                    }
                }
                
            }


        }

        private void BtnExpand_Click(object sender, EventArgs e)
        {
            trDocs.ExpandAll();
        }

        private void BtnCollapse_Click(object sender, EventArgs e)
        {
            trDocs.CollapseAll();

        }
    }
}
