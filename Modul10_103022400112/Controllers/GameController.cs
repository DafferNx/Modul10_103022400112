using Microsoft.AspNetCore.Mvc;
using System;

namespace Modul10_103022400112.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>
        {
            new Game(1, "Valorant", "Riot Games", 2020, "FPS", 8.5, new string[] { "PC" }, new string[] { "Multiplayer" }, true, 0),
            new Game(2, "GTA V", "Rockstar Games", 2013, "Open World", 9.5, new string[]{"PC","PS4","PS5","Xbox"}, new string[]{"Singleplayer","Multiplayer" }, true, 300000),
            new Game(3, "The Witcher 3","CD Projekt Red",2015, "RPG", 9.7, new string[]{"PC","PS4","PS5","Xbox","Switch"}, new string[]{"Singleplayer"}, false, 250000)
        };

        [HttpGet]
        public ActionResult<List<Game>> GetAllGames()
        {
            return Ok(games);
        }

        [HttpGet("{index}")]
        public ActionResult<Game> GetGameById([FromRoute]int index)
        {
            if(index < 0 || index >= games.Count)
            {
                return NotFound("Game tidak ada");
            }

            return Ok(games[index-1]);
        }

        [HttpPost]
        public ActionResult<Game> AddGame([FromBody]Game newGame)
        {
            games.Add(newGame);
            return CreatedAtAction(nameof(GetGameById), new {index = games.Count - 1}, newGame);
        }

        [HttpPut("{index}")]
        public ActionResult<Game> EditGame([FromRoute]int index,[FromBody] Game inputGame)
        {
            if (index < 0 || index >= games.Count)
            {
                return NotFound("Game tidak ada");
            }

            games[index-1] = inputGame;
            return Ok("Game " + games[index - 1].Nama +" berhasil diubah");
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteGame([FromRoute] int index)
        {
            if (index < 0 || index >= games.Count)
            {
                return NotFound("Game tidak ada");
            }

            games.RemoveAt(index - 1);
            return Ok("Game berhasil dihapus");
        }

    }
}
