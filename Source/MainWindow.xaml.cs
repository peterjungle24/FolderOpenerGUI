using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security.RightsManagement;
using System.Text;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FolderOpenerGUI
{
    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow : Window
    {
        /// <summary>creates a new instance</summary>
        private JsonRead json = new();

        public MainWindow()
        {
            // initializes everything
            InitializeComponent();
            // starts by adding all the categories to the listView
            categoryList.Items.AddRange(json.GetCategoriesKeys() );
        }

        private void categoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((pathList.Items.Count > 0))
                pathList.Items.Clear();

            // gets the removed selected, which is the category key
            string category = (string)categoryList.SelectedItem;
            // gets the paths with this category
            List<string> pathKeys = json.GetPathKeys(category);

            // and then adds to list
            foreach (var key in pathKeys)
                pathList.Items.Add(key);
        }
        private void pathList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // gets the select item (which is a key for the paths)
            var key = (string)pathList.SelectedItem;

            // if the string is NOT null or empty
            if (!string.IsNullOrEmpty(key) )
            {
                // gets the paths as a array
                var paths = (JsonArray)json.pathNode[(string)categoryList.SelectedItem][key];
                // if the paths is empty, then just finishes
                if (paths.Count == 0) return;

                // does a loop on the paths
                for (int i = 0; i < paths.Count; i ++)
                {
                    // gets the current item of the loop
                    string item = (string)paths[i];
                    // replaces the / to \\ in case there are
                    item = item.Replace('/', '\\');

                    // and then it opens the folder
                    Process.Start("explorer", (string)item);
                }
            }
        }
    }
}