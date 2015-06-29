using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace BTSerial2
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;
        private RP6_M32 _rp6;

        public Form1()
        {
            InitializeComponent();

            _serialPort = new SerialPort();

            _rp6 = new RP6_M32(_serialPort);

            RefreshComPorts();
        }

        private string buffer = "";

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
            }
            Application.Exit();
        }

        void Reconnect()
        {
            //connect
            if (_serialPort != null && _serialPort.IsOpen)
            {
                try
                {
                    _serialPort.Close();
                }
                catch (Exception)
                {

                }
            }

            try
            {
                if (_serialPort != null && !_serialPort.IsOpen && comboBox1.Text.Length > 0)
                {
                    _serialPort.BaudRate = int.Parse(textBox2.Text);
                    _serialPort.PortName = comboBox1.Text;
                    _serialPort.Open();
                    MessageBox.Show("OK: " + comboBox1.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " : " + comboBox1.Text);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Reconnect();
        }

        private void OnValueUpdate(object sender, RP6_M32.Actions action)
        {
            this.Refresh();
            Application.DoEvents();
        }

        private void RefreshComPorts()
        {
            comboBox1.Items.Clear();
            foreach (string COM_Port in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(COM_Port);
            }
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void tmrForm_Tick(object sender, EventArgs e)
        {
            if (_rp6.LastSeen > DateTime.Now.AddSeconds(10))
            {
                lblLastSeenVal.ForeColor = Color.Red;
            }
            else
            {
                lblLastSeenVal.ForeColor = Color.Black;
                lblLastSeenVal.Text = _rp6.LastSeen.ToLongTimeString();
            }
        }
    }
}
