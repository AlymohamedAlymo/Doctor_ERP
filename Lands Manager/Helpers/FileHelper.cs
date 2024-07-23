using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

class FileHelper
{
    public static string RemoveInvalidChars(string filename)
    {
        return string.Concat(filename.Split(Path.GetInvalidFileNameChars()));
    }

    public static bool IsEnglish(string inputstring)
    {
        Regex regex = new Regex(@"[A-Za-z0-9 .,-=+(){}\[\]\\]");
        MatchCollection matches = regex.Matches(inputstring);

        if (matches.Count.Equals(inputstring.Length))
            return true;
        else
            return false;
    }

    public static byte[] FileToByteArray(string FileName)
    {
        byte[] fbytes = File.ReadAllBytes(FileName);
        return fbytes;
    }

    public static void ByteArraytoFile(byte[] fbytes, string filename)
    {
        File.WriteAllBytes(filename, fbytes);
    }

    public static Image ByteArrayToImage(byte[] byteArrayIn)
    {
        try
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        catch
        {
            return null;
        }
    }

    public static byte[] ImageToByteArray(Image image)
    {
        if (image == null)
            return new byte[0];

        MemoryStream memorystream = new MemoryStream();
        image.Save(memorystream, System.Drawing.Imaging.ImageFormat.Jpeg);

        return memorystream.ToArray();
    }



    public static byte[] MemStreamtoByetArray(Stream inputMemoryStream)
    {
        inputMemoryStream.Position = 0;
        using (MemoryStream ms = new MemoryStream())
        {
            inputMemoryStream.CopyTo(ms);
            return ms.ToArray();
        }

    }

    public static bool SaveFile(string filename, byte[] filedata)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.RestoreDirectory = true;
        sfd.Filter = "All Files (*.*)|*.*";
        sfd.FileName = filename;

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            if (Path.GetExtension(sfd.FileName).Equals(string.Empty))
            {
                MessageBox.Show("يجب تعيين إمتداد للملف", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            File.WriteAllBytes(sfd.FileName, filedata);
            return true;
        }
        return false;
    }

    public static void RunFile(string filename, byte[] filedata)
    {
        try
        {
            string strTempPath = Settings.GetAppPath();
            strTempPath += "temp";
            Directory.CreateDirectory(strTempPath);
            strTempPath += "\\";

            if (File.Exists(strTempPath + filename))
                File.Delete(strTempPath + filename);

            File.WriteAllBytes(strTempPath + filename, filedata);
            Process.Start(strTempPath + filename);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    public static string OpenAndGetFileName()
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.RestoreDirectory = true;
        ofd.Filter = "All Files (*.*)|*.*";
        if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            return ofd.FileName;
        }
        return string.Empty;
    }

    public static string GetFileNameWithOutPath(string filename)
    {
        return Path.GetFileName(filename);
    }

    public static Image resizeImage(Image imgToResize, Size size)
    {
        int sourceWidth = imgToResize.Width;
        int sourceHeight = imgToResize.Height;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = (size.Width / (float)sourceWidth);
        nPercentH = (size.Height / (float)sourceHeight);

        if (nPercentH < nPercentW)
            nPercent = nPercentH;
        else
            nPercent = nPercentW;

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap b = new Bitmap(destWidth, destHeight);
        Graphics graphic = Graphics.FromImage(b);
        graphic.InterpolationMode = InterpolationMode.HighQualityBilinear;

        graphic.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
        graphic.Dispose();

        return b;
    }

    public static Process kbProc = new Process();
    public static void RunKeyBoard()
    {
        try
        {
            Process.Start(AppSetting.GetAppPath() + "osk1.exe" , "run");
        }
        catch
        {

        }
    }

    

    public static void OnOffVirtualKeyBoard()
    {
        try
        {
            Process.Start(AppSetting.GetAppPath() + "osk1.exe", "check");
        }
        catch
        {

        }
    }

    public static void KillKeyBoard()
    {
        try
        {
            Process.Start(AppSetting.GetAppPath() + "osk1.exe", "kill");
        }
        catch
        {

        }
    }
}

