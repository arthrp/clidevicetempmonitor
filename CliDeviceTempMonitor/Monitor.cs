using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace CliDeviceTempMonitor
{
    class Monitor
    {
        private readonly Computer _comp;
        private readonly SensorVisitor _sensorVisitor = new ();

        public Monitor(Computer comp)
        {
            _comp = comp;
        }

        public void Run()
        {
            while (true)
            {
                var report = GetReport();
                Console.Clear();
                Console.Write(report);
                _comp.Accept(_sensorVisitor);

                Thread.Sleep(100);
            }
        }

        public string GetReport()
        {
            var sb = new StringBuilder();

            foreach (var hw in _comp.Hardware)
            {
                sb.AppendLine(hw.Name);

                foreach (var sensor in hw.Sensors)
                {
                    if (sensor.SensorType != SensorType.Temperature)
                        continue;

                    sb.AppendLine($"{sensor.Name} - {sensor.SensorType}: {sensor.Value}");
                }
            }

            return sb.ToString();
        }
    }
}
