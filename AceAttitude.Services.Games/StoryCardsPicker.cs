using AceAttitude.Common.Exceptions;

namespace AceAttitude.Services.Games
{
    public class StoryCardsPicker
    {
        private const int cardCount = 30;

        private const int minHandSize = 3;

        private const int maxHandSize = 7;

        private readonly int handSize;

        private Random randomizer = new Random();

        public StoryCardsPicker(int handSize)
        {
            if (handSize < minHandSize || handSize > maxHandSize)
            {
                throw new InvalidUserInputException($"Hand size cannot be higher than {maxHandSize} or lower than {minHandSize}.");
            }
            this.handSize = handSize;
        }

        public int[] GenerateCardIndexList()
        {
            int[] cardIndexList = new int[handSize];

            for (int i = 0; i < handSize; i++)
            {
                int nextCardIndex = randomizer.Next(1, cardCount + 1);
                if (cardIndexList.Contains(nextCardIndex))
                {
                    i--;
                    continue;
                }
                cardIndexList[i] = nextCardIndex;

            }

            return cardIndexList;
        }



    }
}
