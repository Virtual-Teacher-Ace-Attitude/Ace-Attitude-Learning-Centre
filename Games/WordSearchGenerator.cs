

namespace Games
{
    public class WordSearchGenerator
    {
        private char[,] board;
        private Random randomizer = new Random();

        private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public WordSearchGenerator(int size)
        {
            this.board = new char[size, size];
        }

        public char[,] GenerateWordSearch(List<string> words)
        {
            if (words.Count > board.GetLength(0))
            {
                throw new ArgumentException("Please choose a number of words less than the board length.");
            }

            foreach (string word in words)
            {
                if (IsNotWord(word) || IsTooLong(word))
                {
                    throw new ArgumentException($"The word {word} is either too long or contains invalid characters!");
                }

                PlaceWord(word);
            }

            FillEmptyCells();
            return board;
        }

        private bool IsNotWord(string word)
        {
            return word.Any(c => !char.IsLetter(c));
        }

        private bool IsTooLong(string word)
        {
            return word.Length > board.GetLength(0);
        }

        private void PlaceWord(string word)
        {
            bool wordPlaced = false;
            int attempts = 0;

            while (!wordPlaced && attempts < 100)
            {
                int startRow = randomizer.Next(board.GetLength(0));
                int startCol = randomizer.Next(board.GetLength(0));
                int direction = randomizer.Next(4);  // 0: horizontal, 1: vertical, 2: diagonal down, 3: diagonal up

                switch (direction)
                {
                    case 0:
                        wordPlaced = PlaceHorizontally(startRow, startCol, word);
                        break;
                    case 1:
                        wordPlaced = PlaceVertically(startRow, startCol, word);
                        break;
                    case 2:
                        wordPlaced = PlaceDiagonallyDown(startRow, startCol, word);
                        break;
                    case 3:
                        wordPlaced = PlaceDiagonallyUp(startRow, startCol, word);
                        break;
                }

                attempts++;
            }

            if (!wordPlaced)
            {
                // Handle the case when a word couldn't be placed after multiple attempts
                Console.WriteLine($"Failed to place the word: {word}");
            }
        }

        private bool PlaceHorizontally(int startRow, int startCol, string word)
        {
            int endCol = startCol + word.Length - 1;

            if (endCol >= board.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (board[startRow, startCol + i] != '\0' && board[startRow, startCol + i] != word[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < word.Length; i++)
            {
                board[startRow, startCol + i] = word[i];
            }

            return true;
        }

        private bool PlaceVertically(int startRow, int startCol, string word)
        {
            int endRow = startRow + word.Length - 1;

            if (endRow >= board.GetLength(0))
            {
                return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (board[startRow + i, startCol] != '\0' && board[startRow + i, startCol] != word[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < word.Length; i++)
            {
                board[startRow + i, startCol] = word[i];
            }

            return true;
        }

        private bool PlaceDiagonallyDown(int startRow, int startCol, string word)
        {
            int endRow = startRow + word.Length - 1;
            int endCol = startCol + word.Length - 1;

            if (endRow >= board.GetLength(0) || endCol >= board.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (board[startRow + i, startCol + i] != '\0' && board[startRow + i, startCol + i] != word[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < word.Length; i++)
            {
                board[startRow + i, startCol + i] = word[i];
            }

            return true;
        }

        private bool PlaceDiagonallyUp(int startRow, int startCol, string word)
        {
            int endRow = startRow - word.Length + 1;
            int endCol = startCol + word.Length - 1;

            if (endRow < 0 || endCol >= board.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (board[startRow - i, startCol + i] != '\0' && board[startRow - i, startCol + i] != word[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < word.Length; i++)
            {
                board[startRow - i, startCol + i] = word[i];
            }

            return true;
        }

        private void FillEmptyCells()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '\0')
                    {
                        char letter = CapitalLetters[randomizer.Next(CapitalLetters.Length)];
                        board[i, j] = letter;
                    }
                }
            }
        }

        public void PrintBoard()
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(this.board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
