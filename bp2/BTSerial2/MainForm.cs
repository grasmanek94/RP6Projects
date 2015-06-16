using System;

namespace BTSerial2
{
	public partial class MainForm : Gtk.Window
	{
		public MainForm () :
			base (Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

