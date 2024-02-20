namespace AceAttitude.Services.Games
{
    public class MemoryGameGenerator
    {
        private static Dictionary<string, Dictionary<string, string>> games = new Dictionary<string, Dictionary<string, string>>()
            {
                {
                    "Irregular Verbs",
                    new Dictionary<string, string>()
                    {
                        { "do", "did" },
                        { "have", "had" },
                        { "make", "made" },
                        { "sing", "sang" },
                        { "cut", "cut" } 
                    }
                }
            };


        public void makeWordSet(List<string> keys, List<string> values, string title)
        {
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            for (int i = 0; i < keys.Count; i++)
            {
                pairs.Add(keys[i], values[i]);
            }

            games.Add(title, pairs);
        }


        public Dictionary<string, string> GetPairs(string title)
        {
            return new Dictionary<string, string>(games[title]);
        }
    }
}
