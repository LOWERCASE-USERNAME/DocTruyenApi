namespace DocTruyenApi.Utils
{
    public class UsernameGenerator
    {
        private static readonly string[] Adjectives = { "Quick", "Happy", "Bright", "Silly", "Brave", "Clever", "Wise", "Kind" };
        private static readonly string[] Nouns = { "Tiger", "Eagle", "Wizard", "Knight", "Falcon", "Bear", "Lion", "Panther" };

        public static string GenerateUsername()
        {
            Random random = new Random();
            string adjective = Adjectives[random.Next(Adjectives.Length)];
            string noun = Nouns[random.Next(Nouns.Length)];
            int number = random.Next(100, 1000); // Generate a random number between 100 and 999

            return $"{adjective}{noun}{number}";
        }
    }
}
