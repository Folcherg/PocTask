using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PocTask
{
    class ContextMain : INotifyPropertyChanged
    {
        public ContextMain()
        {
            ProcessTests = new ProcessTest[]
            {
                new ProcessTest(){ Name="Pause", Data = new TestPause() },
            };
        }

        public IEnumerable<ProcessTest> ProcessTests { get; }

        private ProcessTest _selectprocess;
        public ProcessTest SelectProcess
        {
            get => _selectprocess;
            set
            {
                if (value != _selectprocess)
                {
                    _selectprocess = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string nameproperty = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameproperty));

    }

    class ProcessTest
    {
        public string Name { get; set; }
        public object Data { get; set; }
    }
}
