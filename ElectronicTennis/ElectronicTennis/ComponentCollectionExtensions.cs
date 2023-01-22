using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicTennis
{
    internal static class ComponentCollectionExtensions
    {
        public static IList<T> GetComponents<T>(this GameComponentCollection components) where T: GameComponent
        {
            return components.Where(component => component is T)
                             .Select(component => (T)component)
                             .ToList();
        }
    }
}
