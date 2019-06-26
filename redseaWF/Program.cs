﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace redseaWF
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			Mutex mutex = new System.Threading.Mutex(false, "redseaWFUniqueMutexName");
			try {
				if (mutex.WaitOne(0, false)) {
					// Run the application
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					Application.Run(new Form1());
				} else {
					MessageBox.Show("An instance of the application is already running.");
				}
			} finally {
				if (mutex != null) {
					mutex.Close();
					mutex = null;
				}
			}
		}
	}
}