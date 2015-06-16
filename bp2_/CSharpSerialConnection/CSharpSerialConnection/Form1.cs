using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CSharpSerialConnection
{
	public partial class Form1 : Form
	{
		private SerialPort sPort;
		private static string windowsCom = "COM9";
		private static string unixCom = "/dev/ttyUSB0";

		public Form1 ()
		{
			InitializeComponent ();
			sPort = null;
		}

		private void RenesSerialDataReceived (object sender, SerialDataReceivedEventArgs e)
		{
			textBox1.Invoke (
				new EventHandler (
					delegate {
						MessageBox.Show ("Hello World");
						string s = sPort.ReadExisting ();
						richTextBox1.AppendText (s);
					}
				)
			);
		}

		private void button1_Click (object sender, EventArgs e)
		{
			MessageBox.Show (Environment.OSVersion.ToString ());
			if (sPort == null) {
				try {

					if (Environment.OSVersion.ToString ().IndexOf ("unix", StringComparison.CurrentCultureIgnoreCase) != -1) {
						sPort = new SerialPort ("/dev/ttyUSB0", 38400, Parity.None, 8, StopBits.One);
					} else {
						sPort = new SerialPort (windowsCom, 38400, Parity.None, 8, StopBits.One);
					}
					sPort.DataReceived += new SerialDataReceivedEventHandler (RenesSerialDataReceived);
					sPort.Open ();
				} catch (System.IO.IOException) {
					MessageBox.Show ("Creation failed");
				}
			}
		}

		private void button2_Click (object sender, EventArgs e)
		{
			if (sPort != null) {
				sPort.Write ("Hallo");
				sPort.Write ("\0");
			}
		}

		private void textBox1_KeyPress (object sender, KeyPressEventArgs e)
		{
			if (sPort != null) {
				char[] input = new char[1];
				input [0] = e.KeyChar;
				sPort.Write (input, 0, 1);
			}
		}
	}
}