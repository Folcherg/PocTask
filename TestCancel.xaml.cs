using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PocTask
{
    /// <summary>
    /// Interaction logic for TestCancel.xaml
    /// </summary>
    public partial class TestCancel : UserControl
    {
        public ObservableCollection<string> List { get; }

        // Define the cancellation token.
        CancellationTokenSource source = new CancellationTokenSource();
        CancellationToken token;

        public TestCancel()
        {
            List = new ObservableCollection<string>();
            token = source.Token;

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
            
            ProcessFiles(list);
        }

        public async void ProcessFiles(IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                if (token.IsCancellationRequested)
                {
                    await Dispatcher.BeginInvoke((Action)delegate () { List.Add("\rProcess ANNULER!\r"); });
                    break;
                }
                await ProcessAsync(file);
            }
        }

        private Task ProcessAsync(string file)
        {
            return Task.Factory.StartNew(() => { Thread.Sleep(500); Dispatcher.BeginInvoke((Action)delegate () { List.Add(file); }); }, token);            
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            source?.Cancel();
        }
    }
}
