using AceAttitude.Common.Exceptions;

namespace AceAttitude.Services.Games
{
    public class StoryCardsPicker
    {
        private const int cardCount = 30;

        private Random randomizer = new Random();

        public int HandSize {  get; set; } 

        public int[] GenerateCardIndexList()
        {
            int[] cardIndexList = new int[HandSize];

            for (int i = 0; i < HandSize; i++)
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
