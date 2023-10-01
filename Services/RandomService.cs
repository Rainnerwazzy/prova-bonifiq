using ProvaPub.Interfaces;

namespace ProvaPub.Services
{
	public class RandomService: IRandomService
    {
        private int seed;
        private Random random;

        public RandomService()
		{
			seed = Guid.NewGuid().GetHashCode();
            random = new Random(seed);
        }

		public int GetRandom()
		{
            return random.Next(100);
        }

	}
}
