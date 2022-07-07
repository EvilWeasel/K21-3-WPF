using MVVM.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string middleName;
        private string lastName;

        public MainWindowViewModel()
        {
            FirstName = "Dave";
            MiddleName = "Hackerman";
            LastName = "Jones";
            ClearCommand = new DelegateCommand(
                (o) => !String.IsNullOrEmpty(FirstName) || 
                    !String.IsNullOrEmpty(MiddleName) ||
                    !String.IsNullOrEmpty(LastName),
                (o) => { this.FirstName = ""; this.MiddleName = ""; this.LastName = ""; }
            );

        }
        // DelegateCommand usage
        public DelegateCommand ClearCommand { get; set; }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    // Because this method of raising the event is pretty tedious, we can create our own method
                    /*
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FullName)));
                    */
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullName));
                }
            }
        }


        public string MiddleName
        {
            get => middleName; set
            {
                if (middleName != value)
                {
                    middleName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullName));
                }

            }
        }
        public string LastName
        {
            get => lastName; set
            {
                if (lastName != value)
                {
                    lastName = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(FullName));
                }
            }
        }


        /// <summary>
        /// Hier sollte initial darauf hingewiesen werden, dass wenn die Daten über das 
        /// </summary>
        public string FullName => $"{FirstName}, {MiddleName}, {LastName}";

        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
