using System;
using System.Collections.Generic;
using System.Linq;

namespace KD.DependencyFactory
{
    /// <summary>
    /// Dependency injection factory.
    /// </summary>
    public class DependencyFactory
    {
        /// <summary>
        /// Saved types.
        /// </summary>
        private static readonly IDictionary<Type, Type> Types = new Dictionary<Type, Type>();

        private DependencyFactory()
        {
        }

        /// <summary>
        /// Register new type in dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        public static void Register<TKey, TValue>()
        {
            Types.Add(typeof(TKey), typeof(TValue));
        }

        /// <summary>
        /// Returns new instance of the specified TKey type from dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <returns></returns>
        public static TKey Resolve<TKey>()
        {
            var keyType = typeof(TKey);
            var outputTypePair = Types.FirstOrDefault(type => type.Key == keyType);

            if (outputTypePair.Key == null || outputTypePair.Value == null)
            {
                throw new Exception("Cannot resolve type.");
            }

            var outputType = outputTypePair.Value;

            if (!keyType.IsAssignableFrom(outputType))
            {
                throw new Exception("Cannot resolve type.");
            }

            return (TKey) Activator.CreateInstance(outputType);
        }
    }
}