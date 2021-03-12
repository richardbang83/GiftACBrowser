using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{
    public partial class HMCodeControl : UserControl
    {

        CodeExtension codeExt;

        public HMCodeControl()
        {
            InitializeComponent();
        }

        HMExtension extHM = null;
        CLExtension extCL = null;
        BLExtension extBL = null;

        public void initialize(WebBrowser web)
        {
            extHM = new HMExtension(web);
            extBL = new BLExtension(web);
            extCL = new CLExtension(web);
        }

        GiftCodeType codeType;
        internal void SetCodeExtension(GiftCodeType codeType_)
        {
            this.codeType = codeType_;
            switch(codeType)
            {
                case GiftCodeType.HappyMoneyCash:
                    codeExt = extHM;
                    break;

                case GiftCodeType.BookNLife:
                    codeExt = extBL;
                    break;

                case GiftCodeType.Cultureland:
                    codeExt = extCL;
                    break;
            }

            UpdateTabPage();
        }

        internal void GoToLogin()
        {
            codeExt.GotoLogin();
        }

        internal void SetPage(int codeType)
        {
            UpdateTabPage();
        }

        /// <summary>
        /// CodeType 에 맞는 TabPage를 설정함.
        /// </summary>
        private void UpdateTabPage()
        {
            switch (codeType)
            {
                // HappyMoney
                case GiftCodeType.HappyMoneyCash:
                    {
                        if (tabCtrl.Controls.Contains(tabHMGift) == false)
                            tabCtrl.Controls.Add(tabHMGift);
                        break;
                    }
                default:
                    {
                        if (tabCtrl.Controls.Contains(tabHMGift))
                            tabCtrl.Controls.Remove(tabHMGift);
                        break;
                    }

            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            switch(selectedTab)
            {
                case TabType.Cash:
                    {
                        codeExt.ExecuteCharge(txtCodeInput.Text);
                        break;
                    }

                case TabType.HMGift:
                    {
                        var couponType = this.groupBox1.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked).Tag.ToString();

                        if (couponType.Equals("giftcon"))
                        {
                            extHM.ExecuteCharge(couponType, txtCouponNum.Text, txtPhone.Text);
                            //codeExt.ExecuteCharge(couponType, txtCouponNum.Text, txtPhone.Text);
                        }
                        else
                            codeExt.ExecuteCharge(couponType, txtCouponNum.Text);
                        break;
                    }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCodeInput.Text = "";
            codeExt.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var codeList = codeExt.GetCodeStringList(txtCodeInput.Text);

            HashSet<string> hs = new HashSet<string>();

            int overlapCnt = 0;
            foreach(var codeSet in codeList)
            {
                if (hs.Add(codeSet) == false)
                    overlapCnt++;
            }

            if (overlapCnt > 0)
                AppendMessage($"{overlapCnt} 개의 중복코드를 찾았습니다.");

            AppendMessage($"{hs.Count} 개의 고유코드를 찾았습니다.");

        }

        private void AppendMessage(string v)
        {
            txtMessage.AppendText(v);
        }

        private void selGiftcon_CheckedChanged(object sender, EventArgs e)
        {
            if(selGiftcon.Checked)
            {
                labelPhone.Enabled = true;
                txtPhone.Enabled = true;
            }
            else
            {
                labelPhone.Enabled = false;
                txtPhone.Enabled = false;
            }
        }


        /// <summary>
        /// HM Coupon 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectHMCoupon_Click(object sender, EventArgs e)
        {
            var selectedBtn = (RadioButton)sender;

            var codenum = this.groupBox1.Controls.OfType<RadioButton>()
                           .FirstOrDefault(n => n.Checked).Tag;

            extHM.SelectCouponType(codenum.ToString());
        }

        enum TabType
        {
            Cash,
            HMGift,
        }
        TabType selectedTab;

        private void tabCtrl_Selected(object sender, TabControlEventArgs e)
        {
            var tapctrl = (TabControl)sender;
            var tabname = tapctrl.SelectedTab.Name;

            if(tabname.Equals("tabHMGift"))
            {
                selectedTab = TabType.HMGift;
                
            }

            if (tabname.Equals("tabCash"))
            {
                selectedTab = TabType.Cash;
            }
        }
    }
}
