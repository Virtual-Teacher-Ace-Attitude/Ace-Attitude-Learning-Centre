using AceAttitude.Services.Games;
using AceAttitude.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AceAttitude.Web.Controllers.MVCControllers
{
    [Route("games")]
    public class GamesController : Controller
    {
        private readonly WordSearchGenerator wordSearchGenerator;
        private readonly MemoryGameGenerator memoryGameGenerator;
        public GamesController(WordSearchGenerator wordSearchGenerator, MemoryGameGenerator memoryGameGenerator)
        {
            this.memoryGameGenerator = memoryGameGenerator;
            this.wordSearchGenerator = wordSearchGenerator;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("wordSearches/create")]
        public IActionResult CreateWordSearch()
        {
            WordSearchViewModel viewModel = new WordSearchViewModel();
            return View(viewModel);
        }

        [HttpPost("wordSearches/create")]
        public IActionResult CreateWordSearch(WordSearchViewModel viewModel)
        {
            List<string> wordList = viewModel.Words.Split(',').Select(w => w.Trim()).ToList();
            wordSearchGenerator.addWordList(viewModel.Title, wordList);
            return RedirectToAction("SolveWordSearch", "Games", new { title = viewModel.Title });
        }

        [HttpGet("memory")]
        public IActionResult GetMemoryGames()
        {
            return View();
        }

        [HttpGet("memory/create")]
        public IActionResult CreateMemoryGame()
        {
            MemoryGameViewModel viewModel = new MemoryGameViewModel();
            return View(viewModel);
        }

        [HttpPost("memory/create")]
        public IActionResult CreateMemoryGame(MemoryGameViewModel viewModel)
        {
            List<string> pairs1 = viewModel.Pairs1.Split(",").Select(word => word.Trim()).ToList();
            List<string> pairs2 = viewModel.Pairs2.Split(",").Select(word => word.Trim()).ToList();
            this.memoryGameGenerator.makeWordSet(pairs1, pairs2, viewModel.Title);
            return RedirectToAction("SolveMemoryGame", "Games", new { title =  viewModel.Title });
        }

        [HttpGet("wordSearches")]
        public IActionResult GetWordSearches()
        {
            List<string> wordSets = wordSearchGenerator.getWordSets();
            return View(wordSets);
        }

        [HttpGet("wordSearches/{title}")]
        public IActionResult SolveWordSearch([FromRoute] string title) 
        {
            List<string> words = wordSearchGenerator.getWordList(title);
            char[,] wordSearch = wordSearchGenerator.GenerateWordSearch(words);
            Tuple<char[,], List<string>> game = new Tuple<char[,], List<string>>(wordSearch, words);

            return View(game);
        }

        [HttpGet("memory/{title}")]
        public IActionResult SolveMemoryGame([FromRoute] string title)
        {
            Dictionary<string, string> memoryGame = memoryGameGenerator.GetPairs(title);
            return View(memoryGame);
        }
    }
}
  