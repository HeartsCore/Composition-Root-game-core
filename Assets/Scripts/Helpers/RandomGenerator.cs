using System;
using System.Collections.Generic;
using System.Linq;


namespace TestAssigment.Helpers
{
	public static class RandomGenerator
	{
		#region Methods
		public static int GenerateBuffsCount(int minCount, int maxCount)
		{
			return new Random().Next(minCount, maxCount);
		}

		public static List<int> GenerateListNumBuffs(int count, bool allowDuplicateBuffs)
		{
			IEnumerable<int> source;
			if (allowDuplicateBuffs)
			{
				List<int> list = new List<int>();
				while (list.Count < count)
				{
					list.Add(new Random().Next(0, count));
				}
				source = list;
			}
			else
			{
				HashSet<int> hashSet = new HashSet<int>();
				while (hashSet.Count < count)
				{
					hashSet.Add(new Random().Next(0, count));
				}
				source = hashSet;
			}
			return Enumerable.ToList<int>(source);
		}
        #endregion
    }
}
