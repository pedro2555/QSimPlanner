using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QSP.RouteFinding.Tracks.Pacots;
using QSP.RouteFinding;
using QSP;
using QSP.RouteFinding.Containers;
using static UnitTest.Common.Utilities;
using QSP.Core;

namespace UnitTest
{

    [TestClass()]
	public class PacotsHandlerTest
	{

		[TestMethod()]
		public void LoadPacotsWpts()
		{
			PrepareTest();

			PacotsHandler pacotsManager = new PacotsHandler();
			pacotsManager.GetAllTracks();
			pacotsManager.AddToWptList();

		}

		[TestMethod()]
		public void LoadAndFindWpts()
		{
			LoadPacotsWpts();

			const string orig = "RCTP";
			const string dest = "KSFO";

			string origRwy = RouteFindingCore.AirportList.RwyIdentList(orig).First();
			string destRwy = RouteFindingCore.AirportList.RwyIdentList(dest).Last();

			var genRoute = RouteFinder.FindRoute(orig, origRwy, new SidHandler(QspCore.AppSettings.NavDBLocation, orig).GetSidList(origRwy), dest, destRwy, new StarHandler(QspCore.AppSettings.NavDBLocation, dest).GetStarList(destRwy));

			string rte = genRoute.ToString(Route.RouteDisplayOption.AirportToAirport);
			Debug.WriteLine("Generated route: " + rte);
			Debug.WriteLine("Distance = {0} nm\n", genRoute.TotalDis);


		}

	}
}
