using System;
using System.IO.Ports;

namespace BTSerial2
{
	public class Car
    {
        public enum Actions
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

            UNKNOWN_COMMAND,

            NO_COMMAND_TICK,

            COMMANDS_SEND,

            COMMANDS_READ
        };

        public delegate void OnValueUpdateHandler(object sender, Actions action);
        public event OnValueUpdateHandler OnValueUpdate;

        private SerialPort _SP;
        private Message writer;
        private Message reader;

        private System.Windows.Forms.Timer _Timer;
        //private System.Timers.Timer _Timer;

        public string Name { get; private set; }

        private volatile byte _BatteryLevel;
        public byte BatteryLevel
        {
            get { return _BatteryLevel; }
            private set { _BatteryLevel = value; }
        }

        private volatile byte _MaxSpeed;
        public byte MaxSpeed
        {
            get { return _MaxSpeed; }
            private set { _MaxSpeed = value; }
        }

        private volatile int _LastNoCommandTick;
        public int LastNoCommandTick
        {
            get { return _LastNoCommandTick; }
            private set { _LastNoCommandTick = value; }
        }

        private volatile int _CorruptionsOccured;
        public int CorruptionsOccured
        {
            get { return _CorruptionsOccured; }
            private set { _CorruptionsOccured = value; }
        }

        private volatile int _CommandsSuccess;
        public int CommandsSuccess
        {
            get { return _CommandsSuccess; }
            private set { _CommandsSuccess = value; }
        }

        private volatile int _CommandsFail;
        public int CommandsFail
        {
            get { return _CommandsFail; }
            private set { _CommandsFail = value; }
        }

        private volatile int _UnknownCommands;
        public int UnknownCommands
        {
            get { return _UnknownCommands; }
            private set { _UnknownCommands = value; }
        }

        private volatile int _CommandsSend;
        public int CommandsSend
        {
            get { return _CommandsSend; }
            private set { _CommandsSend = value; }
        }

        private volatile int _CommandsRead;
        public int CommandsRead
        {
            get { return _CommandsRead; }
            private set { _CommandsRead = value; }
        }

        public Car (string name, SerialPort port)
		{
			Name = name;

            _SP = port;

            writer = new Message();
            reader = new Message();

            _Timer = new System.Windows.Forms.Timer();
            //_Timer = new System.Timers.Timer();

            _Timer.Interval = 50;
            _Timer.Tick += _Timer_Elapsed;
            //_Timer.Elapsed += _Timer_Elapsed1;
            _Timer.Enabled = true;
            _Timer.Start();

            LastNoCommandTick = 0;
            CorruptionsOccured = 0;
            MaxSpeed = 0;
            BatteryLevel = 0;
        }

        private void _Timer_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            _Timer_Elapsed(null, null);
        }

        private void _Timer_Elapsed(object sender, EventArgs e)
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
                            if (reader.DataLen == 1)
                            {
                                BatteryLevel = reader.Data[0];

                                if(OnValueUpdate != null)
                                {
                                    OnValueUpdate(this, (Actions)reader.Action);
                                }
                            }
                        }
                        break;

                        case Actions.GET_MAXIMUM_SPEED:
                        {
                            if (reader.DataLen == 1)
                            {
                                MaxSpeed = reader.Data[0];

                                if(OnValueUpdate != null)
                                {
                                    OnValueUpdate(this, (Actions)reader.Action);
                                }
                            }
                        }
                        break;

                        case Actions.NO_COMMAND_TICK:
                            LastNoCommandTick = Environment.TickCount;
                            if (OnValueUpdate != null)
                            {
                                OnValueUpdate(this, (Actions)reader.Action);
                            }
                            break;

                        case Actions.MESSAGECORRUPTION_OCCURED:
                            ++CorruptionsOccured;
                            if (OnValueUpdate != null)
                            {
                                OnValueUpdate(this, (Actions)reader.Action);
                            }
                            break;

                        case Actions.COMMAND_EXECUTION_FAILURE:
                            ++CommandsFail;
                            if (OnValueUpdate != null)
                            {
                                OnValueUpdate(this, (Actions)reader.Action);
                            }
                            break;
                        case Actions.COMMAND_EXECUTION_SUCCESS:
                            ++CommandsSuccess;
                            if (OnValueUpdate != null)
                            {
                                OnValueUpdate(this, (Actions)reader.Action);
                            }
                            break;
                        case Actions.UNKNOWN_COMMAND:
                            ++UnknownCommands;
                            if (OnValueUpdate != null)
                            {
                                OnValueUpdate(this, (Actions)reader.Action);
                            }
                            break;
                    }
                }
            }
            catch (Exception)
            {

            }

            if(CommandsSend != writer.AmountWritten)
            {
                CommandsSend = writer.AmountWritten;
                if (OnValueUpdate != null)
                {
                    OnValueUpdate(this, Actions.COMMANDS_SEND);
                }
            }
            if (CommandsRead != reader.AmountRead)
            {
                CommandsRead = reader.AmountRead;
                if (OnValueUpdate != null)
                {
                    OnValueUpdate(this, Actions.COMMANDS_READ);
                }
            }
        }

        public bool setLeftMotor (byte speed)
		{
            if (_SP == null || !_SP.IsOpen)
            {
                return false;
            }

            try
            {
                writer.Action = (byte)Actions.SET_MOTOR_L_SPEED;

                writer.Data[0] = speed;

                writer.DataLen = 1;
                writer.Write(_SP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

		public bool setRightMotor (byte speed)
		{
            if (_SP == null || !_SP.IsOpen)
            {
                return false;
            }

            try
            {
                writer.Action = (byte)Actions.SET_MOTOR_R_SPEED;

                writer.Data[0] = speed;

                writer.DataLen = 1;
                writer.Write(_SP);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

		public bool Stop()
		{
            if (_SP == null || !_SP.IsOpen)
            {
                return false;
            }

            try
            {
                writer.Action = (byte)Actions.MOTOR_STOP;
                writer.DataLen = 0;
                writer.Write(_SP);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool RequestValueUpdate(Actions action)
        {
            if (_SP == null || !_SP.IsOpen)
            {
                return false;
            }

            try
            {
                switch (action)
                {
                    case Actions.GET_BATTERY_LEVEL:
                    case Actions.GET_MAXIMUM_SPEED:

                        writer.Action = (byte)action;
                        writer.DataLen = 0;
                        writer.Write(_SP);
                        break;
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
	}
}

