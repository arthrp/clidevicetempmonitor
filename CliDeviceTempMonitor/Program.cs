using LibreHardwareMonitor.Hardware;
using System;

namespace CliDeviceTempMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var comp = new Computer();
            comp.Open();

            comp.IsGpuEnabled = true;
            comp.IsCpuEnabled = true;

            var mon = new Monitor(comp);
            mon.Run();

        }
    }
}
