using SmartArab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Text;
using System.Windows.Forms;


class ExcelXLSX
{
    public static void ExportToExcel(DataGridView datagridview)
    {
        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Title = "تصدير البيانات إلى ملف إكسل";
        sfd.Filter = "Excel 2007~2010 file (*.xlsx)|*.xlsx";
        sfd.RestoreDirectory = true;
        sfd.OverwritePrompt = true;

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            XLSXData.ExportDataGridViewToXLSX(datagridview, sfd.FileName);

            if (MessageBox.Show(string.Format("تم تصدير البيانات بنجاح إلى الملف\n{0}\nهل تريد فتح الملف ؟", sfd.FileName), Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.No)
                return;

            try
            {
                Process.Start(sfd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static DataTable ImportFromExcel()
    {
        OpenFileDialog ofd = new OpenFileDialog();
        ofd.Title = "تصدير البيانات إلى ملف إكسل";
        ofd.Filter = "Excel 2007~2010 file (*.xlsx)|*.xlsx";
        ofd.RestoreDirectory = true;

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                return XLSXData.ImportDataTableFromXLSX(ofd.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        return new DataTable();
    }
}

