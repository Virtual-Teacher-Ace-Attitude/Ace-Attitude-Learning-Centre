using AceAttitude.Services.Games;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    public class GamesController : Controller
    {
        private readonly WordSearchGenerator wordSearchGenerator;
        private readonly MemoryGameGenerator memoryGameGenerator;
        public GamesController(WordSearchGenerator wordSearchGenerator, MemoryGameGenerator memoryGameGenerator) 
        {
            this.memoryGameGenerator = memoryGameGenerator;
            this.wordSearchGenerator = wordSearchGenerator;
        }    
        public IActionResult Index() 
        {
            return View();
        }
        public IActionResult CreateWordSearch(string words, string title)
        {
            List<string> wordList = words.Split(',').ToList();
            wordSearchGenerator.addWordList(title,wordList);
            return RedirectToAction("SolveWordSearch", "Games", new { title });
        }

        public IActionResult GetMemoryGames() 
        {
            return View();
        }

        public IActionResult CreateMemoryGame() 
        {
            return View();
        }

        public IActionResult GetWordSearches() 
        {
            List<string> wordSets = wordSearchGenerator.getWordSets();
            return View(wordSets);
        }

        public IActionResult SolveWordSearch([FromRoute] string title) 
        {

            char[,] wordSearch = wordSearchGenerator.GenerateWordSearch(wordSearchGenerator.getWordList(title));

            return View(wordSearch);
        }

        public IActionResult SolveMemoryGame([FromRoute] string title)
        {
            return View();
        }
    }
}
  