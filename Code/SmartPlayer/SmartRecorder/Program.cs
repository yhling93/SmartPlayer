using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartRecorder
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            //MessageBox.Show("before create PXCMSession Instance1");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


           // MessageBox.Show("before create PXCMSession Instance2");

            PXCMSession session = PXCMSession.CreateInstance();
            if (session != null)
            {
                Application.Run(new MainForm(session));
                session.Dispose();
            }
        }
    }
}
