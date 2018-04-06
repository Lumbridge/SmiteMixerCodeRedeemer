using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteMixerCodeGrabberGUI.Classes
{
    class ProcessInfo
    {
        private static Process _SmiteProcess { get; set; }

        static ProcessInfo()
        {
            _SmiteProcess = new Process();
        }

        public static bool DoesSmiteProcessExist()
        {
            return ProcessExists("Smite");
        }

        public static Process GetSmiteProcess()
        {
            return GetProcess("Smite");
        }

        public static IntPtr GetSmiteWindowHandle()
        {
            return GetSmiteProcess().MainWindowHandle;
        }

        public static string GetSmiteWindowTitle()
        {
            return GetSmiteProcess().MainWindowTitle;
        }

        public static List<Process> GetProcessList()
        {
            var processes = Process.GetProcesses().ToList();
            return processes;
        }

        public static Process GetProcess(string pName)
        {
            return GetProcessList().Where(x => x.ProcessName == pName).FirstOrDefault();
        }

        public static bool ProcessExists(Process hProcess)
        {
            if (GetProcessList().Select(x => x.Id).Contains(hProcess.Id))
                return true;
            return false;
        }

        public static bool ProcessExists(string pName)
        {
            if (GetProcessList().Select(x => x.ProcessName).Contains(pName))
                return true;
            return false;
        }
    }
}
