using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FolderOpenerGUI.Helpers
{
    public static class WpfHelpers
    {
        /// <summary>
        /// Adds all the elements from <c>"otherCollection"</c>
        /// </summary>
        /// <typeparam name="T">a type of item that will be added</typeparam>
        /// <param name="collection">the collection of items</param>
        /// <param name="otherCollection">the other collection that will be used to add</param>
        public static void AddRange<T>(this ItemCollection collection, IEnumerable<T> otherCollection)
        {
            // goes for each item on the other collection
            foreach (var item in otherCollection)
                // adds this item to the collection
                collection.Add(item);
        }
    }
}
