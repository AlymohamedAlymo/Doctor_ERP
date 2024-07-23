using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

[Serializable()]
public class DataGridColumns
{
    public int ColumnIndex { get; set; }
    public int DisplayIndex { get; set; }
    public bool Visible { get; set; }
    public int Width { get; set; }
    public string ColumnHeader { get; set; }

    public List<DataGridColumns> lstCols { get; set; }


    static DataGridViewColumn FindDatagridColumn(string header, DataGridView datagridview)
    {
        foreach (DataGridViewColumn datagridcolumn in datagridview.Columns)
        {
            if (header.Equals(datagridcolumn.HeaderText))
                return datagridcolumn;
        }
        return null;
    }

    public static string GenerateXMLSettings(DataGridColumns datacolumns)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataGridColumns));

        StringWriter textWriter = new StringWriter();

        xmlSerializer.Serialize(textWriter, datacolumns);
        return Compress(textWriter.ToString());
    }

    public static DataGridColumns ReadDataColumnSettings(string SettingString)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataGridColumns));

        TextReader reader = new StringReader(Decompress(SettingString));

        return (DataGridColumns)xmlSerializer.Deserialize(reader);
    }

    static string Compress(string text)
    {
        if (string.IsNullOrEmpty(text))
            return string.Empty;

        byte[] buffer = Encoding.UTF8.GetBytes(text);
        MemoryStream ms = new MemoryStream();
        using (GZipStream zip = new GZipStream(ms, CompressionMode.Compress, true))
        {
            zip.Write(buffer, 0, buffer.Length);
        }
        ms.Position = 0;
        MemoryStream outStream = new MemoryStream();
        byte[] compressed = new byte[ms.Length];
        ms.Read(compressed, 0, compressed.Length);
        byte[] gzBuffer = new byte[compressed.Length + 4];
        System.Buffer.BlockCopy(compressed, 0, gzBuffer, 4, compressed.Length);

        System.Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gzBuffer, 0, 4);
        return Convert.ToBase64String(gzBuffer);
    }

    static string Decompress(string compressedText)
    {
        if (string.IsNullOrEmpty(compressedText))
            return string.Empty;

        byte[] gzBuffer = Convert.FromBase64String(compressedText);

        using (MemoryStream ms = new MemoryStream())
        {
            int msgLength = BitConverter.ToInt32(gzBuffer, 0);
            ms.Write(gzBuffer, 4, gzBuffer.Length - 4);
            byte[] buffer = new byte[msgLength];
            ms.Position = 0;
            using (GZipStream zip = new GZipStream(ms, CompressionMode.Decompress))
            {
                zip.Read(buffer, 0, buffer.Length);
            }
            return Encoding.UTF8.GetString(buffer);
        }
    }

    #region Custom View
    public static void SetCustomView(DataGridView datagridview , string reportTitle)
    {
        tbReportCustomView rptView = tbReportCustomView.FindBy("name", reportTitle);

        if (!rptView.guid.Equals(Guid.Empty))
        {
            DataGridColumns result = DataGridColumns.ReadDataColumnSettings(rptView.ColumnView);

            for (int i = 0; i < datagridview.Columns.Count; i++)
            {
                try
                {
                    DataGridViewColumn datagridcolumn = DataGridColumns.FindDatagridColumn(result.lstCols[i].ColumnHeader, datagridview);
                    if (datagridcolumn != null)
                    {
                        datagridcolumn.DisplayIndex = result.lstCols[i].DisplayIndex;
                        datagridcolumn.Visible = result.lstCols[i].Visible;
                    }
                }
                catch
                {

                }

            }
            if (!rptView.AutoFillColumn)
            {
                datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                datagridview.AutoResizeColumns();
            }

            else
            {
                datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                datagridview.AutoResizeColumns();
            }
        }
        else
        {
            datagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }

  
    #endregion

}
