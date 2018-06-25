using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SearchService {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        IndexingService service = new IndexingService();
        WordStorage storage = new WordStorage();

        public MainWindow() {
            InitializeComponent();
            service.OnNewWord += storage.AddWord;
        }

        private async void buttonIndex_Click(object sender, RoutedEventArgs e) {
            // Even though the next line might seem excessive,
            // keep it for Part 3 - without it you may run into certain problems
            // related to parallel programming
            buttonIndex.IsEnabled = false;
            Search_button.IsEnabled = false;
            string directory = textBoxDirectory.Text;
            await Task.Factory.StartNew(() => service.Index(directory));
            service.Index(directory);
            buttonIndex.IsEnabled = true;
            Search_button.IsEnabled = true;
            MessageBox.Show("Indexing complete");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Result_listbox.ItemsSource = storage.GetFiles(word_textbox.Text);
        }
    }
}
