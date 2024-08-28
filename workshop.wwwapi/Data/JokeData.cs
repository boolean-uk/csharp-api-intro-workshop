using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class JokeData
    {
        private static List<Joke> _jokes = new List<Joke>();
        public static void Seed()
        {
            _jokes = new List<Joke>()
            {
                new Joke(){Id=1, Text="There are only 10 types of people in this world: those who understand binary and those who don't..", Rating=10 },
                new Joke(){Id=2, Text="The best thing about a Boolean is that even if you are wrong, you are only off by a bit." },
                new Joke(){Id=3, Text="Why don't jokes work in octal? Because 7 10 11", Rating=0 },
                new Joke(){Id=4, Text="Number of days since I have encountered an array index error: -1.", Rating=5 },
            };        
        }
        public static List<Joke> GetJokes()
        {
            return _jokes;
        }
        public static Joke? GetById(int id)
        {
            return _jokes.FirstOrDefault(j => j.Id==id);
        }

        public static Joke GetRandomJoke()
        {
            Joke result = null;
            Random random = new Random();
            int index = random.Next(0,_jokes.Count-1);
            return _jokes[index];
            
        }
        public static List<Joke> GetLongJokes()
        {
            return _jokes.Where(j => j.Text.Length > 50).ToList();
        }
        public static int DeleteJoke(int id)
        {
            return _jokes.RemoveAll(j => j.Id==id);
        }

        public static List<Joke> GetByRating(int rating)
        {
            return _jokes.Where(j => j.Rating >= rating).ToList();
        }
        public static Joke AddJoke(Joke entity)
        {
            if (_jokes.Any(x => x.Text == entity.Text)) return null;//check if its in there?
            
            entity.Id = _jokes.Max(x => x.Id) + 1; //find maximum id in collection and add 1

            _jokes.Add(entity);
            
            return entity;

        }
    }
}
