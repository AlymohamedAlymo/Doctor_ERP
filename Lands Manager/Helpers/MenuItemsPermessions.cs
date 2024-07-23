


using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

public  class MenuStripItems
{
    List<RadMenuItem> Items = null;

    //Extract all menu strip items
    public List<RadMenuItem> GetAllMenuStripItems(RadItemOwnerCollection mnuStrip)
    {
        Items = new List<RadMenuItem>();

        foreach (var toolSripItem in mnuStrip)
        {
            if (toolSripItem is RadMenuItem)
            {
                GetAllSubMenuStripItems((RadMenuItem)toolSripItem);

            }

        }
        return Items;
    }

    //This method is called recursively inside to loop through all menu items
    public void GetAllSubMenuStripItems(RadMenuItem mnuItem)
    {
        Items.Add(mnuItem);

        // if sub menu contain child dropdown items
        if (mnuItem.Items.Count != 0)
        {
            foreach (var MenuItem in mnuItem.Items)
            {
                if (MenuItem is RadMenuItem)
                {
                    //call the method recursively to extract further.
                    GetAllSubMenuStripItems((RadMenuItem)MenuItem);
                }
            }
        }
    }
}

