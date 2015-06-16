using System;
using System.IO.Ports;

namespace BTSerial2
{
	public class Car
	{
		public int BatteryLevel { public get; private set; }

		public string Name { public get; private set; }

		public int MaxSpeed { public get; private set; }


		public Car (int batteryLevel, string name, int maxSpeed)
		{
			BatteryLevel = batteryLevel;
			Name = name;
			MaxSpeed = maxSpeed;
		}

		public void setLeftMotor (int speed, SerialPort port)
		{
			
		}

		public void setRightMotor (int speed, SerialPort port)
		{

		}

		public void setStop (SerialPort port)
		{
			 	
		}
	}
}

