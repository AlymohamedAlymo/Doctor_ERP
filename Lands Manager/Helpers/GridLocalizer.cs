using DevExpress.XtraGrid.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyGridLocalizer : GridLocalizer
{
    public override string GetLocalizedString(GridStringId id)
    {
        switch (id)
        {
            case GridStringId.FindControlFindButton:
                return "بحث";
            case GridStringId.FindControlClearButton:
                return "مسح";
            case GridStringId.FilterPanelCustomizeButton:
                return "تحرير";
            default:
                return base.GetLocalizedString(id);
        }
    }
}
