using System;
using System.Windows.Forms;

namespace Wimmer
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Wimmer wimmer = new Wimmer(args.Length > 0 ? args[0] : null);
			Application.Run(wimmer);
		}
	}
}