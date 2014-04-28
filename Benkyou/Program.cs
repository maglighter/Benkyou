using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Benkyou
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var TS = new TestSystem.StudentLoginForm();
            Application.Run(TS);
            if (TS.result)
                 Application.Run(new Form1());
        }

        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            AssemblyName name = new AssemblyName(args.Name);
            string path = name.Name + ".dll";
            return Assembly.LoadFrom(path);
        }
    }
}
