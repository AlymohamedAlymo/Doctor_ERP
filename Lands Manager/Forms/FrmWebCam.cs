using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TouchlessLib;
using System.Drawing.Imaging;
using ComponentFactory.Krypton.Toolkit;

namespace DoctorERP
{
    public partial class FrmWebCam : KryptonForm
    {
        TouchlessMgr touchManager;
        Bitmap bitmap;
        Bitmap OverLay;

        public Bitmap lastPic;

        bool IsFixed;
        List<Camera> lstCamera = new List<Camera>();

        public FrmWebCam()
        {
            InitializeComponent();
            IsFixed = false;
            touchManager = new TouchlessLib.TouchlessMgr();
            foreach (Camera camera in touchManager.Cameras)
            {
                CmbWebcam.Items.Add(camera.ToString());
                lstCamera.Add(camera);
            }
            if(lstCamera.Count <=0)
            {
                MessageBox.Show("لا يمكن العثور على أي كاميرا متصلة بالحاسب", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }else
            {
                CmbWebcam.SelectedIndex = 0;
            }
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (CmbWebcam.SelectedIndex < 0)
            {
                MessageBox.Show("يرجى تحديد مصدر الكاميرا", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            touchManager.CurrentCamera = lstCamera[CmbWebcam.SelectedIndex];
            touchManager.CurrentCamera.OnImageCaptured += new EventHandler<CameraEventArgs>(CurrentCamera_OnImageCaptured);

            OverLay = new Bitmap(touchManager.CurrentCamera.CaptureWidth, touchManager.CurrentCamera.CaptureHeight, PixelFormat.Format24bppRgb);
            OverLay.MakeTransparent();
            BtnOk.Enabled = true;
            BtnFix.Enabled = true;
            BtnPreview.Enabled = false;

        }

        void CurrentCamera_OnImageCaptured(object sender, CameraEventArgs e)
        {
            bitmap = e.Image;
            PicView.Invalidate();
        }

        private void PicView_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                if (bitmap != null)
                {
                    e.Graphics.DrawImageUnscaledAndClipped(bitmap, PicView.ClientRectangle);
                    e.Graphics.DrawImageUnscaledAndClipped(OverLay, PicView.ClientRectangle);
                }
            }
        }

        private void BtnFix_Click(object sender, EventArgs e)
        {
            if (!IsFixed)
            {
                touchManager.CurrentCamera.Fps = 0;
                IsFixed = true;
                BtnFix.Text = "متابعة";
            }
            else
            {
                touchManager.CurrentCamera.Fps = 30;
                IsFixed = false;
                BtnFix.Text = "تثبيت";
            }
        }

        private void FrmWebCam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (touchManager != null)
                touchManager.Dispose();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            lastPic = bitmap;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
