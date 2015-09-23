using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.IO.Ports;

namespace LaserPoint_Keyence
{
    public partial class Form1 : Form
    {
        //StreamWriter variable to write data into data file
        private StreamWriter streamWriter = null;
        //StreamWriter variable to write log into log file
        private StreamWriter streamLogWriter = null;
        //String variable to hold the file name of the data file
        private string filePath = string.Empty;
        //String variable to hold the file name chosen using FileDialog
        private string fileName = string.Empty;
        //String variable to hold the newly created file name
        private string fileNameNew = string.Empty;
        //Bolean variable to know whether file name has been choosen using file dialog
        bool fileStatus = false; 
        //Timer variable to perform Day Time Limit Feature
        private System.Threading.Timer myTimer = null;
        private string port;
        private int baudRate;
        private SerialPort serialPort;
        /// <summary>
        /// A default constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Method to create a StreamWriter object to write barcode data
        /// </summary>
        /// <param name="filePath">Location of the file</param>
        /// <returns></returns>
        private StreamWriter getWriter(string filePath)
        {
            if (streamWriter == null)
            {
                streamWriter = new StreamWriter(filePath, true);
            }
            if (streamWriter.BaseStream == null)
            {
                streamWriter = null;
                streamWriter = new StreamWriter(filePath, true);
            }
            return streamWriter;
        }
        /// <summary>
        /// Method to create a StreamWriter object to write log data
        /// </summary>
        /// <param name="filePath">Location of the file</param>
        /// <returns></returns>
        private StreamWriter getLogWriter(string filePath)
        {
            if (streamLogWriter == null)
            {
                streamLogWriter = new StreamWriter(filePath, true);
            }
            if (streamLogWriter.BaseStream == null)
            {
                streamLogWriter = null;
                streamLogWriter = new StreamWriter(filePath, true);
            }
            return streamLogWriter;
        }
        /// <summary>
        /// Method to write logs into log file
        /// </summary>
        /// <param name="status">Log Details</param>
        private void WriteLog(string status)
        {
            getLogWriter("log.log").WriteLine(status);
            getLogWriter("log.log").Flush();
        }
        /// <summary>
        /// Method to write data into data file
        /// </summary>
        /// <param name="data">Barcode data</param>
        /// <param name="date">Time Stamp</param>
        private void WriteData(string data, string date)
        {
            getWriter(filePath).WriteLine(string.Format("{0},{1}", data, date));
            getWriter(filePath).Flush();
        }
        /// <summary>
        /// Method to write text into text status text box
        /// </summary>
        /// <param name="status">Status</param>
        private void WriteText(string status)
        {
            textBox_status.Invoke(new updateTextStatusDelegate(updateTextStatus),status);
        }
        /// <summary>
        /// Method to close the data stream writer
        /// </summary>
        private void CloseData()
        {
            getWriter(filePath).Close();
        }
        /// <summary>
        /// Method to close the log stream writer
        /// </summary>
        private void CloseLog()
        {
            getLogWriter("log.log").Close();
        }
        /// <summary>
        /// Delegate to update status in text status textbox
        /// </summary>
        /// <param name="message">Status Message</param>
        private delegate void updateTextStatusDelegate(string message);
        /// <summary>
        /// Method to update status in text status textbox
        /// </summary>
        /// <param name="message">Status Message</param>
        private void updateTextStatus(string message)
        {
            textBox_status.AppendText(message + "\n");
        }
        /// <summary>
        /// Method to write text into text status text box
        /// </summary>
        /// <param name="status">Status</param>
        private void WriteFileName(string fileName)
        {
            textBox_status.Invoke(new updateFileNameDelegate(updateFileName), fileName);
        }
        /// <summary>
        /// Delegate to update status in text status textbox
        /// </summary>
        /// <param name="message">Status Message</param>
        private delegate void updateFileNameDelegate(string fileName);
        /// <summary>
        /// Method to update status in text status textbox
        /// </summary>
        /// <param name="message">Status Message</param>
        private void updateFileName(string fileName)
        {
            textBox_FileName.Text = fileName;
        }

        /// <summary>
        /// Method to write text into text status text box
        /// </summary>
        /// <param name="status">Status</param>
        private void WritePortsList(string portName)
        {
            comboBox_Ports.Invoke(new updateComboboxPortsDelegate(updateComboboxPorts), portName);
        }
        /// <summary>
        /// Delegate to update status in text status textbox
        /// </summary>
        /// <param name="message">Status Message</param>
        private delegate void updateComboboxPortsDelegate(string portName);
        /// <summary>
        /// Method to update status in text status textbox
        /// </summary>
        /// <param name="message">Status Message</param>
        private void updateComboboxPorts(string portName)
        {
            comboBox_Ports.Items.Add(portName);
            if (comboBox_Ports.Items.Count > 0)
            {
                comboBox_Ports.SelectedIndex = 0;
            }
        }
        private void LoadComboboxPorts()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();
                if (ports.Length < 1)
                {
                    WriteLog("No Ports Found...");
                    WriteText("No Ports Found...\n");
                    return;
                }
                foreach (string port in ports)
                {
                    WritePortsList(port);
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
                WriteText("Exception Occured. See the Log File...\n");
                return;
            }
        }
        /// <summary>
        /// Method executes when form loads
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event Args</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadComboboxPorts();
            textBox_BaudRate.GotFocus+= new System.EventHandler(OnFocusListeningPort);
            textBox_BaudRate.LostFocus += new System.EventHandler(OnLostListeningPort);
            textBox_BaudRate.Text = "9600";
            radioButton_Individual.Checked = true;
            button_connect.Enabled = false;
            button_close.Enabled = false;
            checkBox_Monitor.Enabled = false;
        }
        /// <summary>
        /// Method to execute when text box on focus event occurs
        /// </summary>
        /// <param name="Sender">Object</param>
        /// <param name="e">Event Args</param>
        private void OnFocusListeningPort(object Sender, EventArgs e)
        {
            textBox_BaudRate.Text = "";
        }
        /// <summary>
        /// Method to execute when text box lost focus event occurs
        /// </summary>
        /// <param name="Sender">Object</param>
        /// <param name="e">Event Args</param>
        private void OnLostListeningPort(object Sender, EventArgs e)
        {
            if (textBox_BaudRate.Text.Equals(""))
            {
                textBox_BaudRate.Text = "9600";
            }
        }
        /// <summary>
        /// Method to parse the timezone in the format Tz***
        /// </summary>
        /// <param name="timeZone">Time Zone</param>
        /// <returns></returns>
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
        /// <summary>
        /// Method executes when file choose button clicked
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event Args</param>
        private void button_FileChoose_Click(object sender, EventArgs e)
        {
            filePath = string.Empty;
            fileName = string.Empty;
            fileNameNew = string.Empty;
            textBox_FileName.Text = string.Empty;
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Enter File Name...";
            saveFileDialog1.Filter = "Comma Separated Values (*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                filePath = saveFileDialog1.FileName;
                fileName = Path.GetFileNameWithoutExtension(filePath);
                fileNameNew = fileName + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + ".csv";
                filePath = Path.Combine(Path.GetDirectoryName(filePath), fileNameNew);
                WriteData("Temperature","TimeStamp");
                WriteFileName(fileNameNew);
                WriteLog("Data will be written to " + Path.GetDirectoryName(filePath) + "   at " + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n");
                textBox_status.AppendText("Data will be written to " + Path.GetDirectoryName(filePath) + "\n");
                fileStatus = true;
                EnableButton();
            }
            else
            {
                fileStatus = false;
                EnableButton();
                return;
            }
        }
        /// <summary>
        /// Method to enable button
        /// </summary>
        private void EnableButton()
        {
            if (fileStatus)
            {
                button_connect.Enabled = true;
            }
            else
            {
                button_connect.Enabled = false;
            }
        }
        /// <summary>
        /// Method executes when radio button combined checked event occurs
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event Args</param>
        private void radioButton_Combined_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_Monitor.Checked = false;
            if (radioButton_Combined.Checked)
            {
                checkBox_Monitor.Enabled = true;
            }
            else
            {
                checkBox_Monitor.Enabled = false;
            }
        }
        /// <summary>
        /// Method executes when connect button is clicked
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event Args</param>
        private void button_connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox_Monitor.Checked)
                {
                    SetTimerValue();
                    WriteLog("Date Time Monitor Started..." + "   at " + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n");
                    WriteData("Temperature", "TimeStamp");
                    textBox_status.AppendText("Date Time Monitor Started...\n");
                }
                port = comboBox_Ports.SelectedItem.ToString().Trim();
                baudRate = Convert.ToInt32(textBox_BaudRate.Text.ToString().Trim());
                WriteText("Serial Port Initializing...\n");
                serialPort = new SerialPort(port);
                serialPort.BaudRate = baudRate;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.DataBits = 8;
                serialPort.Handshake = Handshake.None;
                serialPort.RtsEnable = true;
                serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                WriteText("Serial Port Initialized...\n");
                WriteText("Serial Port Opening...\n");
                serialPort.Open();
                if (!serialPort.IsOpen)
                {
                    WriteLog("Cannot Open Serial Port...");
                    WriteText("Cannot Open Serial Port...\n");
                    return;
                }
                WriteText("Serial Port Opened...\n");
                button_connect.Enabled = false;
                button_close.Enabled = true;
                if (!timer1.Enabled)
                {
                    //timer1.Start();
                    //WriteText("Reading Started...");
                }
            }
            catch (Exception ex)
            {
                if (myTimer != null)
                    myTimer.Change(Timeout.Infinite,Timeout.Infinite);
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                    WriteText("Serial Port Closed...");
                }
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    WriteText("Reading Stopped...");
                }
                button_connect.Enabled = true;
                button_close.Enabled = false;
                WriteLog(ex.ToString());
                WriteText("Exception Occured. See the Log File...\n");
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serial = (SerialPort)sender;
            string data = serial.ReadExisting();
            string date = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n";
            if (radioButton_Individual.Checked)
            {
                fileNameNew = fileName.Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + ".csv";
                filePath = Path.Combine(Path.GetDirectoryName(filePath), fileNameNew);
                WriteData("Temperature", "TimeStamp");
                WriteLog("Date will be written to " + filePath + "   at " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n");
            }
            if (radioButton_Combined.Checked)
            {
                filePath = Path.Combine(Path.GetDirectoryName(filePath), fileNameNew);
                WriteLog("Date will be written to " + filePath + "   at " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n");
            }
            WriteData(data, date);
            WriteText(data + " " + date + "\n");
        }
      
        /// <summary>
        /// Method executes when disconnect button is clicked
        /// </summary>
        /// <param name="sender">Object</param>
        /// <param name="e">Event Args</param>
        private void button_close_Click(object sender, EventArgs e)
        {
            try
            {
                if (myTimer != null)
                    myTimer.Change(Timeout.Infinite, Timeout.Infinite);
                if (serialPort != null && serialPort.IsOpen)
                {
                    serialPort.Close();
                    WriteText("Serial Port Closed...");
                }
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    WriteText("Reading Stopped...");
                }
                button_connect.Enabled = true;
                button_close.Enabled = false;
            }
            catch (Exception ex)
            {
                button_connect.Enabled = false;
                button_close.Enabled = true;
                WriteLog(ex.ToString());
                WriteText("Exception Occured. See the Log File...\n");
            }
        }
        /// <summary>
        /// Method to execute Day Time Limit feature needed
        /// </summary>
        private void SetTimerValue()
        {
            DateTime requiredTime = DateTime.Today.AddHours(00).AddMinutes(00);
            if (DateTime.Now > requiredTime)
            {
                requiredTime = requiredTime.AddDays(1);
            }
            myTimer = new System.Threading.Timer(new TimerCallback(TimerAction));
            myTimer.Change((int)(requiredTime - DateTime.Now).TotalMilliseconds, Timeout.Infinite);
        }
        private void TimerAction(object e)
        {
            fileNameNew = fileName + "_" + DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + ".csv";
            filePath = Path.Combine(Path.GetDirectoryName(filePath), fileNameNew);
            WriteFileName(fileNameNew);
            WriteData("Temperature","TimeStamp");
            WriteText("New File Name is "+filePath+"...\n");
            SetTimerValue();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                string data = string.Empty;
                string date = string.Empty;
                if (serialPort != null && serialPort.IsOpen)
                {
                    count = serialPort.BytesToRead;
                    if (count < 1)
                    {
                        WriteText("No Data to Read...\n");
                        if (myTimer != null)
                            myTimer.Change(Timeout.Infinite, Timeout.Infinite);
                        if (serialPort != null && serialPort.IsOpen)
                        {
                            serialPort.Close();
                            WriteText("Serial Port Closed...");
                        }
                        if (timer1.Enabled)
                        {
                            timer1.Stop();
                            WriteText("Reading Stopped...");
                        }
                        button_connect.Enabled = true;
                        button_close.Enabled = false;
                        return;
                    }
                    else
                    {
                        while (count > 0)
                        {
                            int byteData = serialPort.ReadByte();
                            data = data + Convert.ToChar(byteData);
                            count--;
                        }
                    }
                    date = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n";
                    if (radioButton_Individual.Checked)
                    {
                        fileNameNew = fileName.Trim() + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + ".csv";
                        filePath = Path.Combine(Path.GetDirectoryName(filePath), fileNameNew);
                        WriteData("Temperature", "TimeStamp");
                        WriteLog("Date will be written to " + filePath + "   at " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n");
                    }
                    if (radioButton_Combined.Checked)
                    {
                        filePath = Path.Combine(Path.GetDirectoryName(filePath), fileNameNew);
                        WriteLog("Date will be written to " + filePath + "   at " + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "Tz" + convertTimeZone(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).ToString()) + "\n");
                    }
                    WriteData(data, date);
                    WriteText(data + " " + date + "\n");
                }
                else
                {
                    if (timer1.Enabled)
                    {
                        timer1.Stop();
                        WriteText("Reading Stopped...");
                    }
                }
            }
            catch (Exception ex)
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    WriteText("Reading Stopped...");
                }
            }
        }

        
       
    }
}
