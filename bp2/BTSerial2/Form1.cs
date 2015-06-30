using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace PressureControl
{
    public partial class MainForm : Form
    {
        private SerialPort _serialPort;
        private RP6_M32 _rp6;

        public MainForm()
        {
            InitializeComponent();
            _serialPort = new SerialPort();
            _rp6 = new RP6_M32(_serialPort);
            RefreshComPorts();
        }

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
            foreach (string comPort in SerialPort.GetPortNames())
            {
                comboBox1.Items.Add(comPort);
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
            trbBar.Value = ((_rp6.Pressure > 6000) ? 6 : (_rp6.Pressure/1000));
            label4.Text = _rp6.Pressure.ToString();
            lblPumpStatus.Text = _rp6.Pump.ToString();
            lblValveStatus.Text = _rp6.Valve.ToString();
            lblOverride.Text = _rp6.Override.ToString();

            if (_rp6.LastSeen < DateTime.Now.AddSeconds(-10))
            {
                lblLastSeenVal.ForeColor = Color.Red;
            }
            else
            {
                lblLastSeenVal.ForeColor = Color.Black;
                lblLastSeenVal.Text = _rp6.LastSeen.ToLongTimeString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetPump(RP6_M32.PumpStatus.ON);
        }

        private void btnPumpOff_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetPump(RP6_M32.PumpStatus.OFF);
        }

        private void btnValveOpen_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetValve(RP6_M32.ValveStatus.OPEN);
        }

        private void btnValveClose_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetValve(RP6_M32.ValveStatus.CLOSED);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetOverride(checkBox1.Checked);
        }

        private void btnBar0_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetBar(0);
        }

        private void btnBar2_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetBar(2);
        }

        private void btnBar4_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetBar(4);
        }

        private void btnBar6_Click(object sender, EventArgs e)
        {
            if (_rp6 == null || !_rp6.IsConnected) return;
            _rp6.SetBar(6);
        }
    }
}
