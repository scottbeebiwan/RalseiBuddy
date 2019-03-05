using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.IO;

namespace RalseiBuddy
{
    class VBScript
    {
        private StreamWriter stdin;
        private StreamReader stdout;
        private Process cscript;
        public VBScript()
        {
            using (Stream stm = Assembly.GetExecutingAssembly().GetManifestResourceStream("RalseiBuddy.VBSREPL.vbs"))
            {
                using (StreamReader stmr = new StreamReader(stm))
                {
                    File.WriteAllText("vbt.vbs", stmr.ReadToEnd());
                }
            }
            ProcessStartInfo pSI = new ProcessStartInfo();
            pSI.UseShellExecute = false;
            pSI.RedirectStandardInput = true;
            pSI.RedirectStandardOutput = true;
            pSI.CreateNoWindow = true;
            pSI.FileName = "cscript.exe";
            pSI.Arguments = "/nologo vbt.vbs";
            cscript = Process.Start(pSI);
            stdin = cscript.StandardInput;
            stdout = cscript.StandardOutput;
            stdout.ReadLine();
        }
        internal void Execute(string code)
        {
            stdin.WriteLine(code);
            string tmp = stdout.ReadLine();
            if (tmp != "K")
            {
                stdout.ReadLine();
                throw new Exception(tmp);
            }
        }
        internal void Close()
        {
            cscript.Close();
            File.Delete("vbt.vbs");
        }
    }
}
