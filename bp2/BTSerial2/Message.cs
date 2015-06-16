using System.IO.Ports;

namespace BTSerial2
{
	public class Message
	{
		public byte[] Begin;
		public byte[] End;

		public byte Action { get; set; }

		public byte DataLen { get; set; }

		public bool PossiblyCorrupt { get; set; }

		public byte[] Data { get; set; }

		public byte[] Corruptioncheck;
		public byte[] Header;

		public Message ()
		{
			Begin = new byte[2];
			End = new byte[2];
			Data = new byte[59];
			Corruptioncheck = new byte[2];
			Header = new byte[2];

			Begin [0] = (byte)'{';
			Begin [1] = (byte)'{';
			End [0] = (byte)'}';
			End [1] = (byte)'}';

			Action = 0;
			DataLen = 0;
			PossiblyCorrupt = false;
		}

		public Message (byte action)
			: this ()
		{
			Action = action;
		}

		public override string ToString()
		{
			return "Message - " + ((int)Action).ToString () + " - " + ((int)DataLen).ToString () + " - " + PossiblyCorrupt.ToString ();
		}

        public byte Read(SerialPort port)
        {
            if (port.BytesToRead > 5 &&
                port.ReadByte() == this.Begin[0] &&
                port.ReadByte() == this.Begin[1])
            {
                //Read action & Data lenght
                this.Action = (byte)port.ReadByte();
                this.DataLen = (byte)port.ReadByte();
                if (this.DataLen > 58)
                {
                    this.DataLen = 58;
                }
                port.Read(this.Data, 0, this.DataLen);
                this.Data[this.DataLen] = 0;

                //Corruption check
                port.Read(this.Corruptioncheck, 0, 2);

                this.PossiblyCorrupt = this.Corruptioncheck[0] != this.End[0] || this.Corruptioncheck[1] != this.End[1];

                return (byte)(this.DataLen + 6);
            }
            return 0;
        }

        /// <summary>
        /// Write a message to Arduino
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public byte Write(SerialPort port)
        {
            this.Header[0] = this.Action;
            this.Header[1] = this.DataLen;

            port.Write(this.Begin, 0, 2);
            port.Write(this.Header, 0, 2);
            port.Write(this.Data, 0, this.DataLen);
            port.Write(this.End, 0, 2);

            return (byte)(this.DataLen + 6);
        }
    }
}
