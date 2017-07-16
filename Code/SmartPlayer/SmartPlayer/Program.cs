using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartPlayer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MessageBox.Show("before create PXCMSession Instance0");

            Application.EnableVisualStyles();

            //MessageBox.Show("before create PXCMSession Instance1");

            Application.SetCompatibleTextRenderingDefault(false);

           // MessageBox.Show("before create PXCMSession Instance");

            PXCMSession session = PXCMSession.CreateInstance();

            //MessageBox.Show("before Application.Run");

            Application.Run(new MainForm(null));
            //if (session != null)
            //{
            //    //MessageBox.Show("PXCMSession is not null");
            //    Application.Run(new MainForm(session));
            //    session.Dispose();
            //}

            //if(session == null)
            //{
            //    MessageBox.Show("PXCMSession is null");
            //}
        }
    }
}
