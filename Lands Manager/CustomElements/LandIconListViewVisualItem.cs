using DoctorERP.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace DoctorERP
{
    public class LandIconListViewVisualItem : IconListViewVisualItem
    {
        protected override Type ThemeEffectiveType
        {
            get
            {
                return typeof(IconListViewVisualItem);
            }
        }

        private LightVisualElement LandID = new LightVisualElement();
        private LightVisualElement TotalInfo = new LightVisualElement();
        private StackLayoutElement VerticalContainer = new StackLayoutElement();
        private StackLayoutElement LandHeaderContainer = new StackLayoutElement();

        protected override void CreateChildElements()
        {
            base.CreateChildElements();

                VerticalContainer.Orientation = System.Windows.Forms.Orientation.Vertical;
                VerticalContainer.NotifyParentOnMouseInput = true;
                VerticalContainer.ShouldHandleMouseInput = false;
                VerticalContainer.StretchHorizontally = true;
                VerticalContainer.StretchVertically = true;

                LandHeaderContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
                LandHeaderContainer.NotifyParentOnMouseInput = true;
                LandHeaderContainer.ShouldHandleMouseInput = false;
                LandHeaderContainer.Children.Add(LandID);
                LandHeaderContainer.StretchHorizontally = true;

                LandID.NotifyParentOnMouseInput = true;
                LandID.ShouldHandleMouseInput = false;
                LandID.StretchHorizontally = true;
            //LandID.CustomFont = Utils.MainFont;
            LandID.CustomFontSize = 12;
            LandID.CustomFontStyle = FontStyle.Bold;
            LandID.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);
            LandID.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;


                TotalInfo.StretchVertically = true;

                TotalInfo.NotifyParentOnMouseInput = true;
                TotalInfo.ShouldHandleMouseInput = false;
                TotalInfo.StretchHorizontally = false;
                TotalInfo.Alignment = ContentAlignment.MiddleLeft;
                TotalInfo.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            //TotalInfo.CustomFont = Utils.MainFont;
            TotalInfo.CustomFontSize = 10;
            TotalInfo.CustomFontStyle = FontStyle.Bold;

                VerticalContainer.Children.Add(LandHeaderContainer);
                VerticalContainer.Children.Add(TotalInfo);

                this.Children.Add(this.VerticalContainer);


        }

        protected override void SynchronizeProperties()
        {

            base.SynchronizeProperties();
            this.DrawText = false;
            this.BackColor = Color.White;
            this.DrawFill = true;
            this.DrawBorder = false;
            this.RightToLeft = true;
            //LandID.Margin = new System.Windows.Forms.Padding(5, 15, 0, 0);
            TotalInfo.ForeColor = Color.White;
            // TotalInfo.Layout.LeftPart.Margin = new System.Windows.Forms.Padding(0, 15, 0, 0);

            IconListViewElement item = this.Parent.Parent as IconListViewElement;
            var itemWidth = item.ItemSize.Width;
            item.Margin = new System.Windows.Forms.Padding(5, 0, 0, 15);
            tbLand Land = this.Data.DataBoundItem as tbLand;
            RadOffice2007ScreenTipElement screenTip = new RadOffice2007ScreenTipElement();



            //if (itemWidth == 120)
            //{
            //    if (Land != null)
            //    {
            //        FrmMain form = ElementTree.Control.FindForm() as FrmMain;
            //        LandID.Text = "أرض رقم:  " + Land.Row.ItemArray[1].ToString();
            //        TotalInfo.Text = double.Parse(Land.Row.ItemArray[5].ToString()).ToString("0.00");
            //        TotalInfo.Image = Properties.Resources.dollar3;
            //        screenTip.RightToLeft = true;
            //        screenTip.CaptionLabel.Text = "المساحة : " + double.Parse(Land.Row.ItemArray[3].ToString()).ToString("0.00");
            //        screenTip.MainTextLabel.Text = "القيمة : " + double.Parse(Land.Row.ItemArray[4].ToString()).ToString("0.00");
            //        screenTip.FooterTextLabel.Text = "الإجمالي : " + double.Parse(Land.Row.ItemArray[5].ToString()).ToString("0.00");
            //        screenTip.MainTextLabel.Font = new Font("Traditional Arabic", 20, FontStyle.Bold);

            //    }
            //}
            //else if (itemWidth == 50)
            //{

                if (Land != null)
                {

                //    FrmMain form = ElementTree.Control.FindForm() as FrmMain;
                this.RightToLeft = true;
                LandID.Text = Land.number.ToString();
                    screenTip.RightToLeft = true;
                    screenTip.CaptionLabel.Text = "أرض رقم:  " + Land.number.ToString(); ;
                    screenTip.MainTextLabel.Text = "السعر : " + Land.total.ToString("0.00");
                    screenTip.FooterTextLabel.Text = "الحالة : " + Land.status.ToString();
                    screenTip.MainTextLabel.Font = new Font("Traditional Arabic", 20, FontStyle.Bold);

                }
            //}

            if (Land.status.ToString().Contains("مباع"))
            {
                this.BackColor = Color.FromArgb(254, 0, 0);

                LandID.ForeColor = Color.Black;

            }
            else if (Land.status.ToString().Contains("متاح"))
            {
                this.BackColor = Color.FromArgb(0, 255, 1);

                LandID.ForeColor = Color.Black;

            }
            else if (Land.status.ToString().Contains("محجوز"))
            {
                this.BackColor = Color.FromArgb(255, 255, 0);

                LandID.ForeColor = Color.Black;

            }
            else
            {

                this.BackColor = Color.Green;

                LandID.ForeColor = Color.Black;
            }


                screenTip.FooterVisible = true;
                this.ScreenTip = screenTip;
            }



        }
    }
