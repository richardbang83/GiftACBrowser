using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiftMacroBrowser
{
    public partial class InputTextBrowser : Form
    {

        public MacroData InputData { get; private set; }

        public InputTextBrowser()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            InputData = new MacroData();
            InputData.CodeType = GetCheckedCodeType();
            InputData.TextData = txtCode.Text;

            this.DialogResult = DialogResult.OK;
        }

        private GiftCodeType GetCheckedCodeType()
        {
            // Checked CodeType Parsing
            var checkedButton = groupBox1.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            int buttonid = int.Parse((string)checkedButton.Tag);

            return (GiftCodeType)buttonid;
        }

    }
}
