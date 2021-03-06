using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            List<League> womensLeagues = _context.Leagues.Where(league => league.Name.Contains("Womens")).ToList();
            ViewBag.womensLeagues = womensLeagues;
            List<League> hockey = _context.Leagues.Where(league => league.Sport.Contains("Hockey")).ToList();
            ViewBag.hockey = hockey;
            List<League> notFootball = _context.Leagues.Where(league => !league.Sport.Contains("Football")).ToList();
            ViewBag.notFootball = notFootball;
            List<League> conferences = _context.Leagues.Where(league => league.Name.Contains("Conference")).ToList();
            ViewBag.conferences = conferences;
            List<League> isAtlantic = _context.Leagues.Where(league => league.Name.Contains("Atlantic")).ToList();
            ViewBag.isAtlantic = isAtlantic;
            List<Team> dallasTeams = _context.Teams.Where(team => team.Location == "Dallas").ToList();
            ViewBag.dallasTeams = dallasTeams;
            List<Team> raptor = _context.Teams.Where(team => team.TeamName == "Raptors").ToList();
            ViewBag.raptor = raptor;
            List<Team> city = _context.Teams.Where(team => team.Location.Contains("City")).ToList();
            ViewBag.city = city;
            List<Team> tTeams = _context.Teams.Where(team =>  team.TeamName.StartsWith("T")).ToList();
            ViewBag.tTeams = tTeams;
            List<Team> alphabeticalTeams = _context.Teams.OrderBy(team => team.Location).ToList();
            ViewBag.alphabeticalTeams = alphabeticalTeams;
            List<Team> revAlphaTeams = _context.Teams.OrderByDescending(team => team.TeamName).ToList();
            ViewBag.revAlphaTeams = revAlphaTeams;
            List<Player> coopPlayer = _context.Players.Where(player => player.LastName == "Cooper").ToList();
            ViewBag.coopPlayer = coopPlayer;
            List<Player> joshPlayer = _context.Players.Where(player => player.FirstName == "Joshua").ToList();
            ViewBag.joshPlayer = joshPlayer;

            List<Player> notJoshPlayer = _context.Players.Where(player => player.LastName == "Cooper" && player.FirstName != "Joshua").ToList();
            ViewBag.notJoshPlayer = notJoshPlayer;

            List<Player> alexOrWyatt = _context.Players.Where(player => player.FirstName == "Alexander" || player.FirstName == "Wyatt").ToList();
            ViewBag.alexOrWyatt = alexOrWyatt;
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}