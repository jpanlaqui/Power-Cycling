using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using TotalPhase;

namespace PowerCycling
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //added to embed reference dll
            AppDomain.CurrentDomain.AssemblyResolve  += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            //end to embed reference dll

            Application.Run(new frmPowerCycling());
        }

        //added to embed reference dll
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("EmbedAssembly.aardvark.dll"))
            {
                byte[] assemblyData = new byte[stream.Length];
                stream.Read(assemblyData, 0, assemblyData.Length);
                return Assembly.Load(assemblyData);
            }
        }
        //end to embed reference dll
    }

}

