using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ImageDisplay.ViewModel
{
    public class ImageDisplayViewModel : INotifyPropertyChanged
    {
        private string _imageUrl;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ImageURL
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
                OnPropertyChanged(nameof(ImageURL));
            }
        }

        public ImageDisplayViewModel()
        {

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
