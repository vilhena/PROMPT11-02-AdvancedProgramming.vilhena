using System.Collections;

namespace Mod02_AdvProgramming.Assignments {
	using System;
	using System.Collections.Generic;

	public class Ex3 {
		public class FibonacciSequence : IEnumerable<int>, IEnumerator<int>
		{
			private int? _limit;

			private int _n_1 = 0;
			private int _n_2 = 0;

			public FibonacciSequence()
			{
				
			}

			public FibonacciSequence(int limit)
			{
				_limit = limit;
			}

			#region Implementation of IEnumerable

			public IEnumerator<int> GetEnumerator()
			{
				return this;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			#endregion

			public int Current
			{
				get { return _n_2;}
			}

			public void Dispose()
			{
				throw new NotImplementedException();
			}

			object IEnumerator.Current
			{
				get { return this.Current; }
			}

			public bool MoveNext()
			{
				if (_n_1 == 0)
				{
					_n_1++;
				}
				else
				{
					var newValue = _n_1 + _n_2;
					_n_2 = _n_1;
					_n_1 = newValue;
				}

				if (!_limit.HasValue)
					return true;
				
				return _limit-- > 0;
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}
	}
}