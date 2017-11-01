using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MediaMvvmcrossForms.Models
{
    public class MenuItem : INotifyPropertyChanged
    {
        private string title;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get => title;
            set
            {
                if (title?.Equals(value) ?? false)
                {
                    return;
                }

                title = value;
                OnPropertyChanged();
            }
        }

        public Type ViewModelType { get; set; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}