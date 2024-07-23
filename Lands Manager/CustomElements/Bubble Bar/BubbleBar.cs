using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls;

namespace DoctorERP
{
    public class BubbleBar : RadControl
    {
        BubbleBarElement element;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public BubbleBarElement Element
        {
            get
            {
                return this.element;
            }
        }

        [RadEditItemsAction]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadItemOwnerCollection Items
        {
            get
            {
                return this.element.Items;
            }
        }

        protected override void CreateChildItems(RadElement parent)
        {
            this.element = new BubbleBarElement();
            this.element.AutoSizeMode = RadAutoSizeMode.WrapAroundChildren;
            parent.Children.Add(this.element);
        }
    }
}
