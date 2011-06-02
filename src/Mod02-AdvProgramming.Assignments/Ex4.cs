namespace Mod02_AdvProgramming.Assignments {
	using System;
	using System.Collections.Generic;

	public class Ex4
	{
		public struct Pair<T, U>
		{
			private T First { get; set; }
			private U Second { get; set; }

			public static Pair<T, U> MakePair(T t, U u)
			{
				return new Pair<T, U>(){First = t, Second = u};
			}
		}

		public static IEnumerable<Pair<T, int>> CountRepeated<T>(IEnumerable<T> seq)
		{
			if (seq == null)
				yield break;

			T previous = default(T);
			var count = 0;
			var isfirst = true;

			foreach (var item in seq)
			{
				if (isfirst)
				{
					isfirst = false;
				}
				else{
					if (previous.Equals(item))
						count++;
					else
					{
						if (count > 0)
						{
							yield return Pair<T, int>.MakePair(previous, count);
						}
						count = 0;
					}
				}
				previous = item;
			}
			
		}
	}
}