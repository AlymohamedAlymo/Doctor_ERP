using ComponentFactory.Krypton.Toolkit;
using Dynamsoft.Core;
using Dynamsoft.TWAIN;
using Dynamsoft.TWAIN.Interface;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace DoctorERP
{
    public partial class FrmScanImage2 : KryptonForm, IAcquireCallback
    {
        public ImageScan imgSc = new ImageScan();


        TwainManager m_TwainManager = new TwainManager("12344");
        ImageCore m_ImageCore = new ImageCore();


        #region Call
        public void OnPostAllTransfers()
        {
        }

        public bool OnPostTransfer(Bitmap bit)
        {
            m_ImageCore.IO.LoadImage(bit);
            TextBox.CheckForIllegalCrossThreadCalls = false;

            return true;
        }

        public void OnPreAllTransfers()
        {
        }

        public bool OnPreTransfer()
        {
            return true;
        }

        public void OnSourceUIClose()
        {
        }

        public void OnTransferCancelled()
        {
        }

        public void OnTransferError()
        {
        }
        #endregion

        public FrmScanImage2()
        {
            InitializeComponent();
            imgSc = new ImageScan();

            m_ImageCore = new ImageCore();
            this.dsViewer1.Bind(m_ImageCore);

            dsViewer1.IfFitWindow = true;
            dsViewer1.MouseShape = false;
            dsViewer1.SetViewMode(-1, -1);

            try
            {
                if (m_TwainManager.SourceCount > 0)
                {
                    comboBox1.Items.Clear();
                    for (int i = 0; i < m_TwainManager.SourceCount; ++i)
                    {
                        comboBox1.Items.Add(m_TwainManager.SourceNameItems((short)i));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            imgSc.filename = TxtFileName.Text;
           
            byte[] fbytes = { 0x0 };

            if (checkImageCount() <= 0)
            {
                MessageBox.Show("لم يتم سحب أي صورة من السكانر", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (checkImageCount() == 1)
            {
                Bitmap bm = m_ImageCore.ImageBuffer.GetBitmap(m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer);
                fbytes = FileHelper.ImageToByteArray((System.Drawing.Image)bm);
                imgSc.ftype = 1;
            }
            else if (checkImageCount() > 1)
            {
                MemoryStream ms = new MemoryStream();
                Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, ms);
                
                doc.Open();

                for (int i = 0; i < m_ImageCore.ImageBuffer.HowManyImagesInBuffer; i++)
                {
                    byte[] imgbye = FileHelper.ImageToByteArray(m_ImageCore.ImageBuffer.GetBitmap((short)i));

                    var image = iTextSharp.text.Image.GetInstance(imgbye);
                    image.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);

                    doc.NewPage();
                    doc.Add(image);
                }
               

                doc.Close();
                pdfWriter.Close();
                System.Threading.Thread.Sleep(3500);

                fbytes = ms.ToArray();

                System.Threading.Thread.Sleep(3500);

                imgSc.ftype = 2;

            }

            if (imgSc.filename.Length <= 0)
            {
                MessageBox.Show("لم يتم إدخال اسم الملف", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
          
            imgSc.fbytes = fbytes;
            System.Threading.Thread.Sleep(3500);
            BtnOk.Text = "يرجى الإنتظار";
            this.Cursor = Cursors.Arrow;
            this.DialogResult = DialogResult.OK;

        }


        private void BtnScanner_Click(object sender, EventArgs e)
        {

            try
            {
                short sSourceIndex = 0;
                sSourceIndex = (short)comboBox1.SelectedIndex;
                short sTwainSourceCount = m_TwainManager.SourceCount;


                if (sSourceIndex < sTwainSourceCount)
                {
                    m_TwainManager.SelectSourceByIndex(sSourceIndex);
                    m_TwainManager.OpenSource();
                    m_TwainManager.IfShowUI = false;
                    m_TwainManager.IfFeederEnabled = ChkMultiPages.Checked;
                    m_TwainManager.IfDuplexEnabled = false;
                    m_TwainManager.IfDisableSourceAfterAcquire = true;

                    if (ChkColor.Checked)
                    {
                        m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_RGB;
                        m_TwainManager.BitDepth = 24;
                    }
                    else
                    {
                        m_TwainManager.PixelType = Dynamsoft.TWAIN.Enums.TWICapPixelType.TWPT_GRAY;
                        m_TwainManager.BitDepth = 8;
                    }

                    m_TwainManager.Resolution = 100;
                    m_TwainManager.AcquireImage(this as IAcquireCallback);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Scan error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dsViewer1.Visible = true;
                checkImageCount();
            }

        }

        private int checkImageCount()
        {
            int currentIndex = m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer + 1;
            int imageCount = m_ImageCore.ImageBuffer.HowManyImagesInBuffer;

            LblPos.Text = string.Format("{0}/{1}", currentIndex, imageCount);
            if (imageCount == 1)
            {
                TxtFileName.Text = "image-scan01.jpg";
            }
            else if (imageCount > 1)
            {
                TxtFileName.Text = "pdf-multiscan01.pdf";
            }
            return imageCount;
        }

        private void FrmScanImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                m_TwainManager.Dispose();
            }
            catch
            {

            }

        }

        private void FrmScanImage_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void FrmScanImage2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ChkMultiPages_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 &&
              m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer < m_ImageCore.ImageBuffer.HowManyImagesInBuffer - 1)
                ++m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            checkImageCount();
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            if (m_ImageCore.ImageBuffer.HowManyImagesInBuffer > 0 && m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer > 0)
                --m_ImageCore.ImageBuffer.CurrentImageIndexInBuffer;
            checkImageCount();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StreamWriter stw = new StreamWriter("d:\\a.pdf");
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream("d:\\Test11.pdf", FileMode.Create));

            doc.Open();

            for (int i = 0; i < m_ImageCore.ImageBuffer.HowManyImagesInBuffer; i++)
            {
                byte[] imgbye = FileHelper.ImageToByteArray(m_ImageCore.ImageBuffer.GetBitmap((short)i));

                var image = iTextSharp.text.Image.GetInstance(imgbye);
                image.ScaleToFit(doc.PageSize.Width, doc.PageSize.Height);

                doc.NewPage();
                doc.Add(image);
            }

            doc.Close();
            pdfWriter.Close();
             
        }
    }
}
