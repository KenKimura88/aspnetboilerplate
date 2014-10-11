using System;
using Abp.Collections.Extensions;

namespace Abp.Application.Navigation
{
    /// <summary>
    /// Defines extension methods for <see cref="IHasMenuItems"/>.
    /// </summary>
    public static class HasMenuItemsExtensions
    {
        /// <summary>
        /// Searches and gets a <see cref="MenuItem"/> by it's unique name.
        /// Throws exception if can not find.
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="name">Unique name of the source</param>
        public static MenuItem GetItemByName(this IHasMenuItems source, string name)
        {
            var item = GetItemByNameOrNull(source, name);
            if (item == null)
            {
                throw new ArgumentException("There is no source item with given name: " + name, "name");
            }

            return item;
        }

        /// <summary>
        /// Searches all menu items (recursively) in the source and gets a <see cref="MenuItem"/> by it's unique name.
        /// Returns null if can not find.
        /// </summary>
        /// <param name="source">Source object</param>
        /// <param name="name">Unique name of the source</param>
        public static MenuItem GetItemByNameOrNull(this IHasMenuItems source, string name)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (source.Items.IsNullOrEmpty())
            {
                return null;
            }

            foreach (var subItem in source.Items)
            {
                if (subItem.Name == name)
                {
                    return subItem;
                }

                var subItemSearchResult = GetItemByNameOrNull(subItem, name);
                if (subItemSearchResult != null)
                {
                    return subItemSearchResult;
                }
            }

            return null;
        }
    }
}