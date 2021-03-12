using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftACBrowser
{
    public partial class GiftCoouponBrowser : Form
    {

        public string PhoneNum
        {
            get
            {
                return txtPhone.Text;
            }
        }

        public string InputCode
        {
            get
            {
                return txtInputCode.Text;
            }
        }
        

        public GiftCoouponBrowser()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
