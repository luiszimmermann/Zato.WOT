using System;
using System.Threading.Tasks;
using Zato.WOT.Blitz;
using Zato.WOT.Core;
using s = System;
using System.Linq;
using Zato.WOT.LiteDB;
using Zato.WOT.DataModel;

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
			var vs = new VehicleService("1c60ba94ce97011add8a22f7fca8b4a6");

			s.Console.WriteLine("Update Vehicles Database? ([N]/Y)");
			var upvh = s.Console.ReadLine();
			Task<Vehicles> tvh = null;
			if (upvh == "Y")
			{
				s.Console.WriteLine("Getting Vehicles from WOTBlitz API in background...");
				tvh = vs.GetAllTanks();
				tvh.Start();
			}

			while (true)
			{
				s.Console.WriteLine("Player Nickname [ZatoBR]?");
				var pn = s.Console.ReadLine();

				if (string.IsNullOrEmpty(pn))
					pn = "ZatoBR";

				var spinner = new Spinner(s.Console.CursorLeft, s.Console.CursorTop);
				spinner.Start();
				var (pdata, accountId) = await ps.GetPlayerInfo(pn);
				spinner.Stop();

				var p = pdata.Data[accountId];
				var format = "{0,8}: {1,-22}";

				s.Console.WriteLine(string.Format(format, "Nickname", p.Nickname));
				//s.Console.WriteLine(string.Format(format, " Frags", p.Statistics.All.Frags));
				//s.Console.WriteLine(string.Format(format, " Hits", p.Statistics.All.Hits));
				s.Console.WriteLine(string.Format(format, "Battles", p.Statistics.All.Battles));
				s.Console.WriteLine(string.Format(format, "Wins", p.Statistics.All.Wins));
				s.Console.WriteLine(string.Format(format, "Losses", p.Statistics.All.Losses));
				s.Console.WriteLine(string.Format(format, "Win %", p.Statistics.All.WinPercent));
				s.Console.WriteLine("");

				s.Console.WriteLine("Vehicles");
				s.Console.WriteLine("");

				spinner = new Spinner(s.Console.CursorLeft, s.Console.CursorTop);
				spinner.Start();
				var vhdata = await ps.GetAllPlayerVehicles(accountId);
				spinner.Stop();

				var vh = vhdata.data.Data[vhdata.accountId];

				var vhRepo = new VehiclesRepository();

				if (tvh != null)
				{
					var alltvh = await tvh;
					vhRepo.PersistOrUpdateVehicle(alltvh);
				}

				foreach (var item in vh.OrderByDescending(x => x.All.Battles).Take(10))
				{
					var tankdata = vhRepo.GetVehicleById(item.TankId);

					s.Console.WriteLine(string.Format(format, "Tank", tankdata.Tier + " " + tankdata.Nation + " - " + tankdata.Name));
					s.Console.WriteLine(string.Format(format, " Premium", tankdata.IsPremium));
					//s.Console.WriteLine(string.Format(format, "Frags", item.All.Frags));
					s.Console.WriteLine(string.Format(format, " Battles", item.All.Battles));
					s.Console.WriteLine(string.Format(format, " Win %", item.All.WinPercent));
					s.Console.WriteLine("");
				}
			}
		}
	}
}
