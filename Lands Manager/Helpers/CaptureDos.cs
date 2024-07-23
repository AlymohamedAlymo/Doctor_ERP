using System;
using System.Diagnostics;
using System.Windows.Forms;

    public class RunCMD
    {
        
        public static string ReturnCMDOutPut(string DosCommand, string args)
        {
            string output = string.Empty;

            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.Arguments = args;
            p.StartInfo.FileName = @DosCommand;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return output.ToString();
        }
    }

