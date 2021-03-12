using ACBrowser;
using GNet.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

using System.Runtime.InteropServices;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GiftACBrowser
{
    public partial class MacroBrowser : Form
    {
        MacroData macroData;
        HMExtension hm;
        CLExtension cl;
        BLExtension bl;


        public MacroBrowser()
        {
            InitializeComponent();


            //this.web.ScriptErrorsSuppressed = true;

        }





        private string ExceptionPrint(Exception ex)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{ex.GetType()}, {ex.Message}");
            if (ex.InnerException != null)
                sb.AppendLine($"InnerException:{ex.InnerException.Message}");

            sb.AppendLine(ex.StackTrace);
            //sb.AppendLine(GetLocationFromExceptionOrStackTrace(ex));

            return sb.ToString();
        }

        private string GetLocationFromExceptionOrStackTrace(Exception entryException)
        {
            var st = new StackTrace(entryException);
                

            var sf = st.GetFrames();

            if (sf == null) return "No StackTrace";

            foreach (var frame in sf)
            {
                var method = frame.GetMethod();
                return $"{method.DeclaringType.Name}->{method.Name}";
            }
            return "Unable to determine location from StackTrace";
        }



        const int WM_KEYDOWN = 0x0100, WM_KEYUP = 0x0101, WM_CHAR = 0x0102, WM_SYSKEYDOWN = 0x0104, WM_SYSKEYUP = 0x0105;

        private void MacroBrowser_Load(object sender, EventArgs e)
        {

        }
        private void hmgiftCode_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Hello world");
            //hm = new HMExtension(web);
            //hm.ExcuteGiftMacro();
        }

        private void toolNavHM_Click(object sender, EventArgs e)
        {
            hm.GoToLogin();
            
        }

        private void toolNavCL_Click(object sender, EventArgs e)
        {
            cl.GotoLogin();
        }

        private void toolNavBL_Click(object sender, EventArgs e)
        {

            bl.GoToLogin();

        }

        

        Keys lastKeyPressed = Keys.None;

//         protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
//         {
//             if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
//             {
//                 lastKeyPressed = keyData;
//                 switch (keyData)
//                 {
//                     case Keys.F1:
//                         this.transparentPanel1.Enabled = true;
//                         this.transparentPanel1.BringToFront();
//                         Refresh();
//                         break;
//                     case Keys.F2:
//                         this.transparentPanel1.Enabled = false;
//                         this.web.BringToFront();
//                         Refresh();
//                         break;
//                 }
//                 
//             }
// 
//             return base.ProcessCmdKey(ref msg, keyData);
//         }

    }
}
