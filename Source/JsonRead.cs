using System;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows;

namespace FolderOpenerGUI
{
    public class JsonRead
    {
        /// <summary>the main "path.json"</summary>
        public JsonNode pathNode;

        public JsonRead()
        {
            // create a settings thing
            var settings = new JsonDocumentOptions()
            {
                // Allows comments at the file, since it will skip these
                CommentHandling = JsonCommentHandling.Skip,
                // Allow trailing commas on the file. Is this really useful? I feel i should not.
                AllowTrailingCommas = true,
            };

            try
            {
                // gets the content from the file
                var filePath = File.ReadAllText("path.json");
                // assigns the field
                pathNode = JsonNode.Parse(filePath, documentOptions: settings);
            }
            catch (Exception exception)
            // instead of throwing a exception like normally does, i create a box that says the error
            { MessageBox.Show(exception.Message, $"Error! {exception} thrown", MessageBoxButton.OK, MessageBoxImage.Error); return; }
        }

        /// <summary>
        /// Gets the categories of the <c>path.json</c> file
        /// </summary>
        /// <returns>a list that contains all the keys</returns>
        public List<string> GetCategoriesKeys()
        {
            // creates a temporary list
            var keys = new List<string>();

            // a loop, that treats the Json file as JsonObject
            foreach (var kvp in pathNode.AsObject() )
                // adds the current key to list
                keys.Add(kvp.Key);

            // returns the list
            return keys;
        }
        /// <summary>
        /// almost same as the <see cref="GetCategoriesKeys"></see>, but gets the Path array keys instead. <br/>
        /// Within a given "category" field, which needs to be <c>JsonObject</c>
        /// </summary>
        /// <param name="fieldName">the given field to find the arrays</param>
        /// <returns>returns a list with all the Path keys</returns>
        public List<string> GetPathKeys(string fieldName)
        {
            // creates a temporary list
            var keys = new List<string>();

            if (pathNode[fieldName] != null)
            {
                // a loop inside of the category
                foreach (var paths in pathNode[fieldName].AsObject() )
                    // adds the keys to the temporary field
                    keys.Add(paths.Key);
            }
            // return the keys
            return keys;
        }
        /// <summary>
        /// Basically the same as <see cref="GetPathKeys(string)"/> <br/>
        /// But gets the actual array values of it
        /// </summary>
        /// <param name="fieldName">The category field given to find the arrays</param>
        /// <returns>a list with the arrays containing paths</returns>
        public List<JsonArray> GetPathValues(string fieldName)
        {
            // creates a temporary list
            var keys = new List<JsonArray>();

            if (pathNode[fieldName] != null)
            {
                // a loop inside of the category
                foreach (var paths in (JsonObject)pathNode[fieldName] )
                    // adds the values to the temporary list
                    keys.Add((JsonArray)paths.Value);
            }

            // return the keys
            return keys;
        }
    }
}
