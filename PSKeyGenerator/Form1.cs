using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace PSKeyGenerator
{
    public partial class Form1 : Form
    {
        private string _key =
            "<RSAKeyValue>" +
                "<Modulus>" +
                    "kjndJ2lmTurT63Jp+bqKQPWY1AJS9eFJrc3NAtBZ74v0AhR5VzuO8tsIW8LxQ0Emu/Ntz6r7g7NLpzsQQpzdP2fDft0gCiSGzeks2Ig8nr/N1cInhM95rc2v1hWuzX55miFn38xXaFCVO9lrj6iuyXGqxt+VIBFD6y2tKgbBhBc=" +
                "</Modulus>" +
                "<Exponent>" +
                    "AQAB" +
                "</Exponent>" +
                "<P>" +
                    "zS91anWYwueHdG86vCy/ngPWOM7arti6YJDvZwUHyRDK5QpSlq2PRMwLi8oOZwbaMRRYpUthyXwknvK7/yxqsw==" +
                "</P>" +
                "<Q>" +
                    "tnBxbk1agFdK4jlc5N8y5PrAEpOVSU6rHKKDWIg6J+8JYhF41/CkoOvanfnnWStzrFoIaQSjQBDvjUqoYsADDQ==" +
                "</Q>" +
                "<DP>" +
                    "nZTBPE2sUKO4J/f0x+gmEZkowOA8muPf36Hv+tKmNAktidHvs8D/svpyM52uifl9QQw7OFc4dqFdDqWlNEhMeQ==" +
                "</DP>" +
                "<DQ>" +
                    "kfJqC9994uXyVf+lvMKBqISgWzwNVVPFt2aaxJxWSdQEIZvwnG86hDGp9m8REFiedOahi8HWB06FFPcAtd79kQ==" +
                "</DQ>" +
                "<InverseQ>" +
                    "VKC7QCTW/kwWkAV/jdSWx9Dy0xSmupFTwnYkGvhO3Yvt5YucQ/NdiOEglRtAVaRmGC/x2j3B6KQySdcA/F4p+Q==" +
                "</InverseQ>" +
                "<D>" +
                    "W/IIjrSmwS7FrIHYA1B5iJklzQHdGoDbrG8A3ykVtBvDhd9L4T8xBqIVomV1AT4hVgOeY/t2hXyjMHdiJRCvyS//9aGgyzdC5PxfLtRwdY0TICvVhuJR+eiqHmhVVYPTM0atmgzI3R3pKOz3rT5Tr/0o8TjihDmYjZ94ocWgu5k=" +
                "</D>" +
            "</RSAKeyValue>";
        public Form1()
        {
            var path = Application.StartupPath;
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = path;
            PathInput.Text = path;
        }

        private string MotherSerial()
        {
            //var mbInfo = String.Empty;
            //var scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            //scope.Connect();
            //var wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());

            //foreach (var propData in wmiClass.Properties)
            //{
            //    if (propData.Name != "SerialNumber") continue;
            //    mbInfo = Convert.ToString(propData.Value);
            //    break;
            //}

            //return mbInfo;
            string cpuInfo = string.Empty;
            string temp = string.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == string.Empty)
                {
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
            }
            return cpuInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                PathInput.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var path = PathInput.Text.TrimEnd('/', '\\') + "\\key.xml";
            var serial = MotherSerial();
            if (serial.Trim(' ') == "")
            {
                MessageBox.Show("не удалось получить идентификатор процессора, ключ не создан");
                Close();
            }
            var data = Encoding.UTF8.GetBytes(serial);
            var rsaCP = new RSACryptoServiceProvider();
            rsaCP.FromXmlString(_key);
            var ezp = rsaCP.SignData(data, CryptoConfig.MapNameToOID("SHA1"));
            new XmlSerializer(typeof(byte[])).Serialize(new StreamWriter(path), ezp);
            Close();
        }
    }
}
