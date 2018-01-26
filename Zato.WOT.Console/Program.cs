using System;
using System.Threading.Tasks;
using Zato.WOT.Blitz;
using Zato.WOT.Core;
using s = System;

namespace Zato.WOT.Console
{
	class Program
	{
		static async Task Main(string[] args)
		{
			s.Console.Title = "Zato WOT Console";
			s.Console.WriteLine(" ____     _       ");
			s.Console.WriteLine("|_  /__ _| |_ ___ ");
			s.Console.WriteLine(" / // _` |  _/ _ \\");
			s.Console.WriteLine("/___\\__,_|\\__\\___/");
			s.Console.WriteLine("__________________");
			s.Console.WriteLine("");

			var ps = new PlayerService("1c60ba94ce97011add8a22f7fca8b4a6");
			//s.Console.BackgroundColor = ConsoleColor.Blue;

			var spinner = new Spinner(s.Console.CursorLeft, s.Console.CursorTop);
			spinner.Start();

			var player = await ps.GetPlayerInfo("ZatoBR");

			spinner.Stop();

			//s.Console.BackgroundColor = ConsoleColor.Black;

			var p = player.data.Data[player.accountId];

			var format = "{0,8}  {1,-22}";

			s.Console.WriteLine(string.Format(format, "Nickname", p.Nickname));
			s.Console.WriteLine(string.Format(format, "Frags", p.Statistics.All.Frags));
			s.Console.WriteLine(string.Format(format, "Hits", p.Statistics.All.Hits));
			s.Console.WriteLine(string.Format(format, "Battles", p.Statistics.All.Battles));
			s.Console.WriteLine(string.Format(format, "Losses", p.Statistics.All.Losses));
			s.Console.WriteLine(string.Format(format, "Wins", p.Statistics.All.Wins));
			s.Console.WriteLine(string.Format(format, "Win %", (((double)p.Statistics.All.Wins / (double)p.Statistics.All.Battles) * (double)100).ToString("#.##")));

		}
	}
}
