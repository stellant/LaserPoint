using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.IO.Ports;

namespace LaserPoint_Keyence_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Temperature" in code, svc and config file together.
    public class Temperature : ITemperature
    {
        private XmlElement _result = null;
        private SerialPort _serialPort = null;
        private int count = 0;
        private string data = string.Empty;
        public XmlElement GetTemperature(string port, string baudRate)
        {
            try
            {
                _serialPort = new SerialPort(port,Convert.ToInt32(baudRate));
                _serialPort.Open();
                if (!_serialPort.IsOpen)
                {
                    throw new Exception("Cannot Open Serial Port...");
                }
                count = _serialPort.BytesToRead;
                if (count < 1)
                {
                    throw new Exception("No Data to Read...");
                }
                else
                {
                    while (count > 0)
                    {
                        int byteData = _serialPort.ReadByte();
                        data = data + Convert.ToChar(byteData);
                    }
                }
                _result = GetXML(data.ToString());
            }
            catch (Exception ex)
            {
                _result = GetExceptionXML(ex.ToString());
            }
            return _result;
        }
        private XmlElement GetXML(string s)
        {
            XmlDocument document = new XmlDocument();
            XmlNode root = document.CreateElement("LaserPoint");
            document.AppendChild(root);
            XmlNode dataNode = document.CreateElement("Temperature");
            dataNode.InnerText = s;
            root.AppendChild(dataNode);
            XmlNode dateNode = document.CreateElement("TemperatureDateTime");
            dateNode.InnerText = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString());
            root.AppendChild(dateNode);
            return document.DocumentElement;
        }
        private XmlElement GetExceptionXML(string ex)
        {
            XmlDocument document = new XmlDocument();
            XmlNode root = document.CreateElement("LaserPoint");
            document.AppendChild(root);
            XmlNode dataNode = document.CreateElement("ExceptionData");
            dataNode.InnerText = ex;
            root.AppendChild(dataNode);
            XmlNode dateNode = document.CreateElement("ExceptionDateTime");
            dateNode.InnerText = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString());
            root.AppendChild(dateNode);
            return document.DocumentElement;
        }
        private string convertTimeZone(string timeZone)
        {
            string timeZoneParsed = string.Empty;
            if (!timeZone.Trim().Equals(string.Empty))
            {
                string[] timeZones = timeZone.Split(':');
                timeZoneParsed += Convert.ToInt64(timeZones[0]);
                if (Convert.ToInt64(timeZones[1]) > 0)
                {
                    timeZoneParsed += Convert.ToInt64(timeZones[1]);
                }
            }
            return timeZoneParsed.Trim();
        }
    }
}
