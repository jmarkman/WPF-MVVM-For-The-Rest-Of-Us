using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IntroToBinding.ViewModel
{
    public class DemoViewModel : INotifyPropertyChanged
    {
        // The field which will hold the value we want to display in the TextBlock
        private string _text;

        // Implementation of the INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// This is the property for the "_text" field
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        // ctor
        public DemoViewModel()
        {
            Text = "Hello World";
        }

        // Implementation of the INotifyPropertyChanged interface
        /// <summary>
        /// Allows the bindings defined within XAML to stay synchronized with any C# class the
        /// <see cref="INotifyPropertyChanged"/> interface happens to be implemented on.
        /// </summary>
        /// <param name="propertyName">The name of the property bound to the XAML element</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
