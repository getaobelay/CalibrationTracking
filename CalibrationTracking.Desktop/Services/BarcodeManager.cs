using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;
using System.Threading;
using System.Windows;
namespace CalibrationTracking.Desktop.Services
{
   
        public class BarcodeManager : IBarcodeManager
    {
        private SerialPort SingalSerialPort
        {
            get;
            set;
        }

        public Action<string> BarcodeAction
        {
            get;
            set;
        }

        private List<SerialPort>? ScanCodeSerialPort
        {
            get;
            set;
        }

        public BarcodeManager(Action<string> barcodeAction)
        {
            BarcodeAction = barcodeAction;
            string portName = GetPortName();
            ActivateSerialPort(portName);
        }

        private void ActivateSerialPort(string portName)
        {
            if (portName is null)
            {
                return;
            }

            try
            {
                try
                {
                    SingalSerialPort = new SerialPort(portName, 9600, Parity.None, 8, StopBits.One);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:" + ex.ToString());
                    return;
                }

                SingalSerialPort.DataReceived += DataRecive;

                OpenPort(SingalSerialPort);
            }
            catch (Exception)
            {
                ScanCodeSerialPort = null;
                throw;
            }
        }

        private void OpenPort(SerialPort serialPort)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                else
                {
                    serialPort.Open();
                }

                if (serialPort.IsOpen) { }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void DataRecive(object serialPort, SerialDataReceivedEventArgs _event)
        {
            Dispatch(delegate
            {
                BarcodeAction?.Invoke((serialPort as SerialPort).ReadExisting().Trim());
            });
        }

        public void Close(object sender, EventArgs e) => Close();

        private void Close() => Dispatch(CloseHandler);

        private void Dispatch(Action action)
        {
           System.Windows.Application.Current.Dispatcher?.Invoke(action);
        }

        private void CloseHandler()
        {
            Thread thread = new Thread((ThreadStart)delegate
            {
                int? num = ScanCodeSerialPort?.Count;
                if (num.HasValue && num.GetValueOrDefault() > 0)
                {
                    ScanCodeSerialPort?.ForEach(delegate (SerialPort port)
                    {
                        if ((port?.IsOpen).HasValue)
                        {
                            port.Close();
                        }
                    });
                }
                else if ((SingalSerialPort?.IsOpen).HasValue)
                {
                    SingalSerialPort?.Close();
                }
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private string GetPortName()
        {
            string portName = null;
            using (ManagementClass i_Entity = new ManagementClass("Win32_PnPEntity"))
            {
                foreach (ManagementObject i_Inst in i_Entity.GetInstances())
                {
                    Object o_Guid = i_Inst.GetPropertyValue("ClassGuid");
                    if (o_Guid == null || o_Guid.ToString().ToUpper() != "{4D36E978-E325-11CE-BFC1-08002BE10318}")
                        continue; // Skip all devices except device class "PORTS"

                    String s_Caption = i_Inst.GetPropertyValue("Caption").ToString();
                    String s_Manufact = i_Inst.GetPropertyValue("Manufacturer").ToString();
                    String s_DeviceID = i_Inst.GetPropertyValue("PnpDeviceID").ToString();
                    String s_RegPath = "HKEY_LOCAL_MACHINE\\System\\CurrentControlSet\\Enum\\" + s_DeviceID + "\\Device Parameters";
                    String s_PortName = Registry.GetValue(s_RegPath, "PortName", "").ToString();

                    if (s_DeviceID.Contains("SCANNER") || s_Manufact.Contains("Zebra"))
                    {
                        portName = s_PortName;
                        break;
                    }
                }
            }

            return portName;
        }
    }
}