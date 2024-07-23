using System;
using System.IO;
using FastReport;
using System.Drawing;
using System.Windows.Forms;
using FastReport.Utils;
using System.Data;
using System.Collections.Generic;

class Reports
{
    private static EnvironmentSettings FastReportSetting;

    public static void InitReport(Report fastreport, string ReportFile, bool locked)
    {
        FastReportSetting = new EnvironmentSettings();

        FastReportSetting.CustomSaveReport += new FastReport.Design.OpenSaveReportEventHandler(FastReportSetting_CustomSaveReport);
        FastReportSetting.CustomSaveDialog += FastReportSetting_CustomSaveDialog;
        FastReportSetting.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
        FastReportSetting.UseRibbonUI = false;

        FastReportSetting.DesignerSettings.Restrictions.DontCreateData = locked;
        FastReportSetting.DesignerSettings.Restrictions.DontCreateReport = locked;
        FastReportSetting.DesignerSettings.Restrictions.DontDeletePage = locked;
        FastReportSetting.DesignerSettings.Restrictions.DontCreatePage = locked;
        FastReportSetting.DesignerSettings.Restrictions.DontEditData = locked;
        FastReportSetting.DesignerSettings.Restrictions.DontShowRecentFiles = locked;
        FastReportSetting.DesignerSettings.Restrictions.DontLoadReport = locked;
        FastReportSetting.DesignerSettings.Restrictions.DontCreateReport = locked;

        ReportFile = Settings.GetAppPath() + "reports\\" + ReportFile;

        if (!File.Exists(ReportFile))
            fastreport.Save(ReportFile);

        fastreport.Load(ReportFile);

        foreach (Base reportobject in fastreport.Dictionary.AllObjects)
            if (reportobject is FastReport.Data.DataConnectionBase || reportobject is FastReport.Data.TableDataSource)
                reportobject.Restrictions = Restrictions.HideAllProperties;


        FastReportSetting.PreviewSettings.Buttons = PreviewButtons.Find | PreviewButtons.Navigator |
            PreviewButtons.Print | PreviewButtons.Watermark |
            PreviewButtons.Zoom | PreviewButtons.Save |
            PreviewButtons.PageSetup | PreviewButtons.Close;

        FastReport.Utils.Res.LoadLocale(Settings.GetAppPath() + "Arabic.frl");

        FastReportSetting.DesignerSettings.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        FastReportSetting.PreviewSettings.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
    }

    public static void DesignReport(Report report)
    {
        FastReport.Design.StandardDesigner.DesignerForm frmDesign = new FastReport.Design.StandardDesigner.DesignerForm();
        frmDesign.Designer.cmdAbout.CustomAction += cmdAbout_CustomAction;
        frmDesign.Designer.Report = report;
        frmDesign.Show();
    }

    #region FastReport Setting Events
    private static void FastReportSetting_CustomSaveReport(object sender, FastReport.Design.OpenSaveReportEventArgs e)
    {
        e.Report.Save(e.FileName);
    }

    static void FastReportSetting_CustomSaveDialog(object sender, FastReport.Design.OpenSaveDialogEventArgs e)
    {
        e.Cancel = true;
    }

    static void cmdAbout_CustomAction(object sender, EventArgs e)
    {

    }
    #endregion

    #region Generate Auto Report
    public static void GenerateReport(string ReportTitle, DataGridView datagridview, DataTable datatable)
    {
        Report report = new Report();
        report.RegisterData(datatable, "data");
        foreach (FastReport.Data.TableDataSource datasource in report.Dictionary.DataSources)
            datasource.Enabled = true;

        ReportPage page = new ReportPage();
        page.Width = 21.0f * Units.Centimeters;
        page.Height = 29.7f * Units.Centimeters;
        page.TopMargin = 0.0f;
        page.LeftMargin = 0.0f;
        page.RightMargin = 0.0f;
        page.BottomMargin = 0.0f;

        report.Pages.Add(page);
        page.CreateUniqueName();

        page.ReportTitle = new ReportTitleBand();
        page.ReportTitle.CreateUniqueName();
        page.ReportTitle.Height = 1.5f * Units.Centimeters;

        TextObject TxtTitle = new TextObject();
        TxtTitle.Text = ReportTitle;
        TxtTitle.Width = page.Width - Units.Centimeters;
        TxtTitle.Left = Units.Centimeters / 2;
        TxtTitle.Height = 1.0f * Units.Centimeters;
        TxtTitle.Top = 0.25f * Units.Centimeters;
        TxtTitle.VertAlign = VertAlign.Center;
        TxtTitle.HorzAlign = HorzAlign.Center;
        TxtTitle.Font = new Font(TxtTitle.Font.FontFamily, 14.0f, FontStyle.Bold);
        page.ReportTitle.Objects.Add(TxtTitle);
        TxtTitle.CreateUniqueName();

        page.PageHeader = new PageHeaderBand();
        page.PageHeader.CreateUniqueName();
        page.PageHeader.Height = 0.75f * Units.Centimeters;

        DataBand band = new DataBand();
        page.Bands.Add(band);
        band.CreateUniqueName();
        band.DataSource = report.GetDataSource("data");
        band.Height = 0.75f * Units.Centimeters;
        band.Width = page.Width;
        page.PageFooter = new PageFooterBand();
        page.PageFooter.CreateUniqueName();
        page.PageFooter.Height = 1.0f * Units.Centimeters;

        int visibilecolumnCount = 0;
        foreach (DataGridViewColumn col in datagridview.Columns)
            if (col.Visible)
                visibilecolumnCount++;

        int ObjectsCount = 0;
        List<DataGridViewColumn> lstColumns = new List<DataGridViewColumn>();

        foreach (DataGridViewColumn dcol in datagridview.Columns)
        {
            lstColumns.Add(dcol);
        }
        lstColumns.Reverse();

        foreach (DataGridViewColumn dcol in lstColumns)
        {
            if (datagridview.Columns[dcol.Index].Visible)
            {
                TextObject datatext = new TextObject();
                datatext.Top = 0.0f;
                datatext.Width = (page.Width - Units.Centimeters) / visibilecolumnCount;
                datatext.Height = 0.75f * Units.Centimeters;
                datatext.Left = (ObjectsCount * (page.Width - Units.Centimeters) / visibilecolumnCount) + (Units.Centimeters / 2);
                datatext.Border.Lines = BorderLines.All;
                datatext.VertAlign = VertAlign.Center;
                datatext.HorzAlign = HorzAlign.Center;
                datatext.Text = string.Format("[data.{0}]", datagridview.Columns[dcol.Index].DataPropertyName);
                band.Objects.Add(datatext);
                datatext.CreateUniqueName();

                TextObject headtext = new TextObject();
                headtext.Top = 0.0f;
                headtext.Width = (page.Width - Units.Centimeters) / visibilecolumnCount;
                headtext.Height = 0.75f * Units.Centimeters;
                headtext.Left = (ObjectsCount * (page.Width - Units.Centimeters) / visibilecolumnCount) + (Units.Centimeters / 2);
                headtext.Border.Lines = BorderLines.All;
                headtext.VertAlign = VertAlign.Center;
                headtext.HorzAlign = HorzAlign.Center;
                headtext.Text = datagridview.Columns[dcol.Index].HeaderText;
                headtext.Font = new Font(headtext.Font, FontStyle.Bold);
                headtext.FillColor = Color.WhiteSmoke;
                page.PageHeader.Objects.Add(headtext);
                headtext.CreateUniqueName();
                ObjectsCount++;
            }
        }
        report.Design();
    }
    #endregion



}
