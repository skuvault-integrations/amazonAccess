using System.Collections.Generic;
using System.Linq;

namespace AmazonAccess.Misc
{
	public static class LinqExtensions
	{
		public static IEnumerable< IEnumerable< T > > Split< T >( this IEnumerable< T > list, int parts )
		{
			var i = 0;
			var splits = from item in list
				group item by i++ % parts
				into part
				select part.AsEnumerable();
			return splits;
		}
	}
}