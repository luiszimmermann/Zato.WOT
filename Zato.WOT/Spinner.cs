using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using s = System;

namespace Zato.WOT.Console
{
	public class Spinner : IDisposable
	{
		private const string Sequence = @"/-\|";
		private int counter = 0;
		private readonly int left;
		private readonly int top;
		private readonly int delay;
		private bool active;
		private readonly Thread thread;

		public Spinner(int left, int top, int delay = 100)
		{
			this.left = left;
			this.top = top;
			this.delay = delay;
			thread = new Thread(Spin);
		}

		public void Start()
		{
			active = true;
			if (!thread.IsAlive)
				thread.Start();
		}

		public void Stop()
		{
			active = false;
			//Draw(' ');
			s.Console.SetCursorPosition(left, top);
			s.Console.ResetColor();
			s.Console.Write("");
		}

		private void Spin()
		{
			while (active)
			{
				Turn();
				Thread.Sleep(delay);
			}
		}

		private void Draw(char c)
		{
			s.Console.SetCursorPosition(left, top);
			s.Console.ForegroundColor = ConsoleColor.Green;
			s.Console.Write(c);
		}

		private void Turn()
		{
			Draw(Sequence[++counter % Sequence.Length]);
		}

		public void Dispose()
		{
			Stop();
		}
	}
}
