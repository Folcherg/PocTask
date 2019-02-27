using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace PocTask
{
    /// <summary>
    /// Interaction logic for TestPause.xaml
    /// </summary>
    public partial class TestPause : UserControl
    {
        public ObservableCollection<string> List { get; }

        private PauseTokenSource pts = new PauseTokenSource();

        public TestPause()
        {
            List = new ObservableCollection<string>();

            InitializeComponent();                       
            Loaded += Main_Loaded;            
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            var list = new List<string>();
            for (int i = 1; i < 1000; i++)
            {
                list.Add($"test {i}");
            }

            ProcessFiles(list, pts.Token);
        }

        public async void ProcessFiles(IEnumerable<string> files, PauseToken pauseToken)
        {
            foreach (var file in files)
            {
                await pauseToken.WaitWhilePausedAsync();
                await ProcessAsync(file);
            }
        }

        private Task ProcessAsync(string file)
        {
            return Task.Factory.StartNew(() => { Thread.Sleep(500); Dispatcher.BeginInvoke((Action)delegate () { List.Add(file); }); });
        }

        private void Pause(object sender, RoutedEventArgs e)
        {
            pts.IsPaused = true;
        }

        private void Resume(object sender, RoutedEventArgs e)
        {
            pts.IsPaused = false;
        }
    }
}
