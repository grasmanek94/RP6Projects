using System;
using System.IO.Ports;

namespace BTSerial2
{
	public class Car
    {
        enum Actions
        {
            GET_BATTERY_LEVEL = 1,

            SET_MOTOR_L_SPEED,
            SET_MOTOR_R_SPEED,

            MOTOR_STOP,

            GET_MAXIMUM_SPEED,

            RESET_MAX_SPEED,

            COMMAND_EXECUTION_SUCCESS,
            COMMAND_EXECUTION_FAILURE,

            MESSAGECORRUPTION_OCCURED,

            UNKNOWN_COMMAND
        };

        private SerialPort _SP;
        private Message writer;
        private Message reader;

        private System.Timers.Timer _Timer;

        private volatile float _BatteryLevel;
        private volatile short _MaxSpeed;

        public float BatteryLevel
        {
            get { return _BatteryLevel; }
            private set { _BatteryLevel = value; }
        }

		public string Name { get; private set; }

        public short MaxSpeed
        {
            get { return _MaxSpeed; }
            private set { _MaxSpeed = value; }
        }

        public Car (string name, SerialPort port)
		{
			Name = name;

            _SP = port;

            writer = new Message();
            reader = new Message();

            _Timer = new System.Timers.Timer();

            _Timer.Interval = 100;
            _Timer.Elapsed += _Timer_Elapsed;
            _Timer.Enabled = true;
            _Timer.Start();
        }

        private void _Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_SP == null || !_SP.IsOpen)
            {
                return;
            }

            try
            {
                if (reader.Read(_SP) > 0)
                {
                    switch ((Actions)reader.Action)
                    {
                        case Actions.GET_BATTERY_LEVEL:
                        {
                            if (reader.DataLen == 4)
                            {
                                byte[] data = new byte[4];

                                data[0] = reader.Data[0];
                                data[1] = reader.Data[1];
                                data[2] = reader.Data[2];
                                data[3] = reader.Data[3];

                                BatteryLevel = Convert.ToSingle(data);
                            }
                        }
                        break;

                        case Actions.GET_MAXIMUM_SPEED:
                        {
                            if (reader.DataLen == 2)
                            {
                                byte[] data = new byte[2];

                                data[0] = reader.Data[0];
                                data[1] = reader.Data[1];

                                MaxSpeed = Convert.ToInt16(data);
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void setLeftMotor (short speed)
		{
            if (_SP == null || !_SP.IsOpen)
            {
                return;
            }

            writer.Action = (byte)Actions.SET_MOTOR_L_SPEED;

            byte[] intBytes = BitConverter.GetBytes(speed);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);

            writer.Data[0] = intBytes[0];
            writer.Data[1] = intBytes[1];

            writer.DataLen = 2;

            writer.Write(_SP);
        }

		public void setRightMotor (short speed)
		{
            if (_SP == null || !_SP.IsOpen)
            {
                return;
            }

            writer.Action = (byte)Actions.SET_MOTOR_R_SPEED;

            byte[] intBytes = BitConverter.GetBytes(speed);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(intBytes);

            writer.Data[0] = intBytes[0];
            writer.Data[1] = intBytes[1];

            writer.DataLen = 2;

            writer.Write(_SP);
        }

		public void Stop()
		{
            if (_SP == null || !_SP.IsOpen)
            {
                return;
            }

            writer.Action = (byte)Actions.MOTOR_STOP;

            writer.DataLen = 0;

            writer.Write(_SP);
        }
	}
}

