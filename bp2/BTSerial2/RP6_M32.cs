using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace BTSerial2
{
	public class RP6_M32
    {
        public DateTime LastSeen { private set; get;}
        public enum Actions
        {
            HEARTBEAT = 1,
            HANDSHAKE_START,
            HANDSHAKE_ACK
        };

        public delegate void OnValueUpdateHandler(object sender, Actions action);

        private SerialPort _serialPort;
        private Message _writer;
        private Message _reader;

        private System.Windows.Forms.Timer _Timer;

        public RP6_M32 (SerialPort port)
		{
            _serialPort = port;
            LastSeen = DateTime.Now;

            _writer = new Message();
            _reader = new Message();

            _Timer = new Timer {Interval = 50};
            _Timer.Tick += _Timer_Elapsed;
            _Timer.Enabled = true;
            _Timer.Start();
        }

        private void _Timer_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Timer_Elapsed(null, null);
        }

        private void _Timer_Elapsed(object sender, EventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                return;
            }

            try
            {
                if (_reader.Read(_serialPort) <= 0) return;

                

                switch ((Actions)_reader.Action)
                {
                    case Actions.HEARTBEAT:
                        // Keep track of when the last communication occured
                        LastSeen = DateTime.Now;
                        break;

                    case Actions.HANDSHAKE_START:
                        _writer.Action = (byte) Actions.HANDSHAKE_ACK;
                        _writer.DataLen = 0;
                        _writer.Write(_serialPort);
                        break;
                }
            }
            catch (Exception)
            {

            }

        }

        public bool RequestValueUpdate(Actions action)
        {
            return false;
        }
	}
}

