﻿using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace PressureControl
{
	public class RP6_M32
    {
        public DateTime LastSeen { private set; get;}
        public bool IsConnected { private set; get; }
        public int Pressure { private set; get; }
        public PumpStatus Pump { private set; get; }
	    public enum PumpStatus
	    {
	        ON,
	        OFF
	    };
        public enum Actions
        {
            //TODO Add to protocol document 
            HEARTBEAT = 1,
            HEARTBEAT_ACK,
            HANDSHAKE_START,
            HANDSHAKE_ACK,
            GET_PRESSURE,
            SET_PRESSURE,
            SET_PUMP_ON,
            SET_PUMP_OFF,
        };

        public delegate void OnValueUpdateHandler(object sender, Actions action);

        private SerialPort _serialPort;
        private Message _writer;
        private Message _reader;

	    private int _pressure;

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
                        if (IsConnected)
                        {
                            _writer.Action = (byte) Actions.HEARTBEAT_ACK;
                            _writer.DataLen = 0;
                            _writer.Write(_serialPort);
                        }
                        break;
                    case Actions.HANDSHAKE_START:
                        _writer.Action = (byte) Actions.HANDSHAKE_ACK;
                        _writer.DataLen = 0;
                        _writer.Write(_serialPort);
                        IsConnected = true;
                        break;
                    case Actions.SET_PRESSURE:
                        Pressure = (_reader.Data[0] ^ _reader.Data[1] << 8);
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

	    public int UpdatePressure()
	    {
	        return (_pressure/1000);
	    }

	    public void SetPump(PumpStatus status)
	    {
            _writer.Action = (byte)Actions.SET_PUMP_ON;
            _writer.DataLen = 0;
            _writer.Write(_serialPort);
        }
	}
}

