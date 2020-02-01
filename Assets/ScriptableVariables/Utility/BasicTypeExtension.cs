using System.Collections.Generic;
using System.Linq;

namespace GGJ2020.Variables
{
    public static partial class BasicTypeExtension
    {
        /// <summary>
        /// Gets a unique value in the given list priorizing the given value.
        /// </summary>
        public static uint GetUniqueValue(this IEnumerable<uint> aValueEnumerable, uint aValue = uint.MinValue)
        {
            uint uniqueValue = aValue;

            var orderedValues = aValueEnumerable.OrderBy(value => value);
            foreach (var value in orderedValues)
            {
                int comparison = uniqueValue.CompareTo(value);
                if (comparison > 0)
                    continue;
                else if (comparison == 0)
                    uniqueValue = uniqueValue + 1;
                // 1st smaller value means "uniqueValue" isn't used yet.
                else
                    break;
            }

            return uniqueValue;
        }
    }
}
