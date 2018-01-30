using System;
using System.Threading.Tasks;
using Zato.WOT.Blitz;
using Zato.WOT.Core;
using s = System;
using System.Linq;
using Zato.WOT.LiteDB;
using Zato.WOT.DataModel;
using MoreLinq;

namespace Zato.WOT.Console
{
	class Program
	{
		static async Task Main(string[] args)
		{
			try
			{
				s.Console.Title = "Zato WOT Console";
				s.Console.WriteLine("______________________");
				s.Console.WriteLine("|  ____     _        |");
				s.Console.WriteLine("| |_  /__ _| |_ ___  |");
				s.Console.WriteLine("|  / // _` |  _/ _ \\ |");
				s.Console.WriteLine("| /___\\__,_|\\__\\___/ |");
				s.Console.WriteLine("|____________________|");
				s.Console.WriteLine("");

				var ps = new PlayerService("1c60ba94ce97011add8a22f7fca8b4a6");
				var vs = new VehicleService("1c60ba94ce97011add8a22f7fca8b4a6");

				s.Console.WriteLine("Update Vehicles Internal Database? ([n]/y)");
				var upvh = s.Console.ReadLine();
				Task<Vehicles> tvh = null;
				if (upvh.ToUpper() == "Y")
				{
					s.Console.WriteLine("Getting Vehicles from WOTBlitz API in background...");
					tvh = vs.GetAllTanks();
					//tvh.Start();
				}

				while (true)
				{
					s.Console.WriteLine("Player Nickname ([ZatoBR])?");
					var pn = s.Console.ReadLine();

					if (string.IsNullOrEmpty(pn))
						pn = "ZatoBR";

					var spinner = new Spinner(s.Console.CursorLeft, s.Console.CursorTop);
					spinner.Start();
					var (pdata, accountId) = await ps.GetPlayerInfo(pn);
					spinner.Stop();

					var p = pdata.Data[accountId];
					var format = "{0,8}: {1,-25}";
					var format2column = "{0,8}: {1,-25}  |  {0,8}: {2,-25}";

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

					foreach (var item in vh.OrderByDescending(x => x.All.Battles).Take(10).Batch(2).Select(x => x.ToArray()))
					{
						var tankData0 = vhRepo.GetVehicleById(item[0].TankId);
						var tankData1 = vhRepo.GetVehicleById(item[1].TankId);

						s.Console.WriteLine(string.Format(format2column, "Tank", tankData0.DisplayName, tankData1.DisplayName));
						s.Console.WriteLine(string.Format(format2column, "Premium", tankData0.IsPremium, tankData1.IsPremium));
						//s.Console.WriteLine(string.Format(format, "Frags", item.All.Frags));
						s.Console.WriteLine(string.Format(format2column, "Battles", item[0].All.Battles, item[1].All.Battles));
						s.Console.WriteLine(string.Format(format2column, "Win %", item[0].All.WinPercent, item[1].All.WinPercent));
						s.Console.WriteLine("");
					}

				}
			}
			catch (Exception ex)
			{
				s.Console.WriteLine(ex);
			}
		}
	}
}
