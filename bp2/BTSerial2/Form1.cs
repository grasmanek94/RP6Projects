using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace BTSerial2
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;
        private Car _RP9;

        public Form1()
        {
            InitializeComponent();

            _serialPort = new SerialPort();

            _RP9 = new Car("RP9-RZE-53-UE", _serialPort);
            _RP9.OnValueUpdate += OnValueUpdate;

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

        private void OnValueUpdate(object sender, Car.Actions action)
        {
            switch (action)
            {
                case Car.Actions.GET_BATTERY_LEVEL:
                    fuellb.Text = _RP9.BatteryLevel.ToString();
                    break;
                case Car.Actions.GET_MAXIMUM_SPEED:
                    speedlb.Text = _RP9.MaxSpeed.ToString();
                    break;
                case Car.Actions.NO_COMMAND_TICK:
                    lastAlive.Text = _RP9.LastNoCommandTick.ToString();
                    break;
                case Car.Actions.MESSAGECORRUPTION_OCCURED:
                    crolbl.Text = _RP9.CorruptionsOccured.ToString();
                    break;
                case Car.Actions.COMMAND_EXECUTION_FAILURE:
                    cmdflbl.Text = _RP9.CommandsFail.ToString();
                    break;
                case Car.Actions.COMMAND_EXECUTION_SUCCESS:
                    cmdslbl.Text = _RP9.CommandsSuccess.ToString();
                    break;
                case Car.Actions.UNKNOWN_COMMAND:
                    cmdulbl.Text = _RP9.UnknownCommands.ToString();
                    break;                
            }

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

            _RP9.RequestValueUpdate(Car.Actions.GET_BATTERY_LEVEL);
            _RP9.RequestValueUpdate(Car.Actions.GET_MAXIMUM_SPEED);
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            motorLeft.Value = 0;
            motorRight.Value = 0;
            _RP9.Stop();
        }

        private void motorLeft_Scroll(object sender, EventArgs e)
        {
            _RP9.setLeftMotor((short)motorLeft.Value);
        }

        private void motorRight_Scroll(object sender, EventArgs e)
        {
            _RP9.setRightMotor((short)motorRight.Value);
        }
    }
}
