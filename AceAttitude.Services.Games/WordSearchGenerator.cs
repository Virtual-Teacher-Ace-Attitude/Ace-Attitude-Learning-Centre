using AceAttitude.Common.Exceptions;
using System.Drawing;

namespace AceAttitude.Services.Games
{
    public class WordSearchGenerator
    {
        private char[,] board = new char[15,15];
        private Random randomizer = new Random();

        private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        //The dictionary contains every placed character with a list of the coordinate of every instance of that character on the grid.
        private Dictionary<char, List<Tuple<int, int>>> placedLetters = new Dictionary<char, List<Tuple<int, int>>>();

        private static Dictionary<string, List<string>> wordLists = new Dictionary<string, List<string>>()
{
    { "colors", new List<string> { "black", "blue", "pink", "green", "red", "yellow", "orange", "purple", "white" } },
    { "animals", new List<string> { "dog", "cat", "elephant", "lion", "tiger", "bear", "monkey", "giraffe", "zebra" } },
    { "places in town", new List<string> { "school", "hospital", "library", "park", "restaurant", "bank", "pharmacy", "market", "cinema" } },
    { "food", new List<string> { "apple", "banana", "pizza", "burger", "salad", "cake", "pasta", "chocolate", "sandwich" } },
    { "actions", new List<string> { "run", "jump", "swim", "dance", "sing", "play", "climb", "laugh", "sleep" } },
    { "places in nature", new List<string> { "forest", "mountain", "beach", "river", "lake", "waterfall", "cave", "valley", "desert" } }
};


        public WordSearchGenerator() 
        {

        }

        public char[,] GenerateWordSearch(List<string> words)
        {
            foreach (string word in words)
            {
                bool connected = TryConnectWord(word);
                if (!connected)
                {
                    bool placed = false;
                    for (int i = 0; i < 100; i++)
                    {
                        int x = randomizer.Next(board.GetLength(0));
                        int y = randomizer.Next(board.GetLength(1));
                        int[] directionOrder = ShuffleOrder(8);
                        for (int j = 0; j < 8; j++)
                        {
                            placed = PlaceWord(word, x, y, directionOrder[j]);
                            if (placed)
                            {
                                break;
                            }
                        }
                        if (placed)
                        {
                            break;
                        }
                    }

                }
            }
            FillEmptyCells();
            return board;
        }

        private bool TryConnectWord(string word)
        {
            int[] letterOrder = ShuffleOrder(word.Length);
            for (int i = 0; i < word.Length; i++)
            {

                int letterPosition = letterOrder[i];
                char letter = word[letterPosition];
                if (placedLetters.ContainsKey(letter))
                {
                    foreach (Tuple<int, int> coordinates in placedLetters[letter])
                    {
                        int x = coordinates.Item1;
                        int y = coordinates.Item2;
                        for (int j = 0; j < 8; j++)
                        {
                            int[] directionOrder = ShuffleOrder(8);
                            switch (directionOrder[j])
                            {
                                case 0:
                                    if (PlaceWord(word, x - letterPosition, y, j))
                                    {
                                        return true;
                                    }
                                    break;
                                case 1:
                                    if (PlaceWord(word, x + letterPosition, y, j))
                                    {
                                        return true;
                                    }
                                    break;
                                case 2:
                                    if (PlaceWord(word, x, y - letterPosition, j))
                                    {
                                        return true;
                                    }
                                    break;
                                case 3:
                                    if (PlaceWord(word, x, y + letterPosition, j))
                                    {
                                        return true;
                                    }
                                    break;
                                case 4:
                                    if (PlaceWord(word, x - letterPosition, y - letterPosition, j))
                                    {
                                        return true;
                                    }
                                    break;
                                case 5:
                                    if (PlaceWord(word, x + letterPosition, y - letterPosition, j))
                                    {
                                        return true;
                                    }
                                    break;
                                case 6:
                                    if (PlaceWord(word, x - letterPosition, y + letterPosition, j))
                                    {
                                        return true;
                                    }
                                    break;
                                case 7:
                                    if (PlaceWord(word, x + letterPosition, y + letterPosition, j))
                                    {
                                        return true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void FillEmptyCells()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '\0')
                    {
                        board[i, j] = CapitalLetters[randomizer.Next(CapitalLetters.Length)];
                    }
                }
            }
        }

        //Directions:
        //0 -> left-right
        //1 -> right-left
        //2 -> up-down
        //3 -> down-up
        //4 -> up-down right diagonal
        //5 -> down-up right diagonal
        //6 -> up-down left diagonal
        //7 -> down-up left diagonal
        private bool PlaceWord(string word, int x, int y, int direction)
        {
            int dx = 0, dy = 0;

            switch (direction)
            {
                case 0: dx = 1; break;
                case 1: dx = -1; break;
                case 2: dy = 1; break;
                case 3: dy = -1; break;
                case 4: dx = 1; dy = 1; break;
                case 5: dx = 1; dy = -1; break;
                case 6: dx = -1; dy = 1; break;
                case 7: dx = -1; dy = -1; break;
            }

            if (!IsValidPlacement(word, x, y, dx, dy))
            {
                return false;
            }

            int counter = 0;

            while (counter < word.Length)
            {
                char currentChar = word[counter];

                if (!placedLetters.ContainsKey(currentChar))
                {
                    placedLetters.Add(currentChar, new List<Tuple<int, int>>());
                }
                if (board[y, x] == '\0')
                {
                    placedLetters[currentChar].Add(new Tuple<int, int>(x, y));
                }

                board[y, x] = currentChar;

                x += dx;
                y += dy;

                counter++;
            }
            return true;

        }

        private bool IsValidPlacement(string word, int x, int y, int dx, int dy)
        {
            int counter = 0;
            while (counter < word.Length)
            {
                if (IsOutOfBounds(x, y) || IsOccupiedSpace(word[counter], x, y))
                {
                    return false;
                }
                x += dx;
                y += dy;
                counter++;
            }
            return true;

        }

        private bool IsOutOfBounds(int x, int y)
        {
            if (x < 0 || x >= board.GetLength(0) || y < 0 || y >= board.GetLength(1))
            {
                return true;
            }
            return false;
        }

        private bool IsOccupiedSpace(char c, int x, int y)
        {
            if (board[y, x] == '\0' || c == board[y, x])
            {
                return false;
            }
            return true;
        }

        private int[] ShuffleOrder(int length)
        {
            int[] order = new int[length];
            List<int> temp = new List<int>(length);
            for (int i = 0; i < length; i++)
            {
                temp.Add(i);
            }
            for (int i = 0; i < length; i++)
            {
                int position = randomizer.Next(temp.Count);
                order[i] = temp[position];
                temp.RemoveAt(position);
            }
            return order;

        }


        public List<string> getWordList(string title)
        {
            if (!wordLists.ContainsKey(title))
            {
                throw new InvalidUserInputException($"The word list '{title}' is currently not in the game.");
            }
            return new List<string>(wordLists[title]);
        }

        public List<string> getWordSets()
        {
            return wordLists.Keys.ToList();
        }

        public void addWordList(string title, List<string> wordList)
        {
            if (wordLists.ContainsKey(title))
            {
                throw new InvalidUserInputException($"There is already a word search with the title '{title}'.");
            }
            wordLists.Add(title, wordList);
        }
    }
}