using System.Reflection;

namespace SBase.Helper
{
    /// <summary>
    /// This is the class object helper common.
    /// </summary>
    public class ObjectHelper
    {
        /// <summary>
        /// Checks the object is null.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Returns true if the object was null, otherwise false.</returns>
        public static bool IsNull(object obj)
        { 
            return obj == null; 
        }

        /// <summary>
        /// Checks the object is none null.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>Returns true if the object was not null, otherwise false.</returns>
        public static bool IsPresent (object obj)
        { 
            return obj != null; 
        }

        /// <summary>
        /// Copies properties from the source object to the destination object.
        /// </summary>
        /// <typeparam name="T">The type of the objects.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="destination">The destination object.</param>
        public static void CopyProperties<T>(T source, T destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source), "Source object cannot be null");
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination), "Destination object cannot be null");
            }

            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => prop.CanRead && prop.CanWrite);

            foreach (var property in properties)
            {
                var value = property.GetValue(source, null);
                property.SetValue(destination, value, null);
            }
        }
    }
}
