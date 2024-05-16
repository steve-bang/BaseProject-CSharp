namespace SBase.Helper
{
    /// <summary>
    /// This is the class collection helper common.
    /// </summary>
    public class CollectionHelper
    {
        /// <summary>
        /// Checks the collection is null or empty.
        /// </summary>
        /// <typeparam name="T">The type class generic.</typeparam>
        /// <param name="collections">The collections.</param>
        /// <returns>Returns true if the collection is null or empty, otherwise false.</returns>
        public static bool IsEmptyOrNull<T>(ICollection<T> collections)
        {
            return collections == null || collections.Count == 0;
        }

        /// <summary>
        /// Checks if a list has values or not.
        /// </summary>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <param name="colections">The list object.</param>
        /// <returns>Return false if the list is not null and has elements, otherwise true.</returns>
        public static bool IsEmptyOrNull<T>(IEnumerable<T> colections)
        {
            return colections == null  || colections.Count() == 0;
        }

        /// <summary>
        /// Checks if a list has values or not.
        /// </summary>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <param name="colections">The list object.</param>
        /// <returns>Return true if the list is not null and has elements, otherwise false.</returns>
        public static bool IsPresent<T>(ICollection<T> collections)
        {
            return collections != null && collections.Count > 0;
        }

        /// <summary>
        /// Checks if a list has values or not.
        /// </summary>
        /// <typeparam name="T">The type of the list.</typeparam>
        /// <param name="colections">The list object.</param>
        /// <returns>Return true if the list is not null and has elements, otherwise false.</returns>
        public static bool IsPresent<T>(IEnumerable<T> colections)
        {
            return colections.Any();
        }

        /// <summary>
        /// Shuffle the list of the item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> items)
        {
            if (IsEmptyOrNull(items))
                return Enumerable.Empty<T>();

            Random random = new Random();

            return items.OrderBy<T, int>((item) => random.Next());
        }
    }
}
